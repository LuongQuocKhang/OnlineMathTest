import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";


@Component({
  selector: 'app-mcqquestion-edit',
  templateUrl: './mcqquestion.edit.component.html',
  styleUrls: ['./mcqquestion.edit.component.css']
})
export class EditMcqQuestionComponent implements OnInit {
  private sub: any;
  public questionId = 0;
  public question = {} as any;
  public questionTypes = [] as any;
  public levels = [] as any;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.questionId = params['id'];
    });
    this.getQuestionById(this.questionId);
    this.getAllQuestionType();
    this.getAllLevel();
  }

  ngOnInit() {
  }
  public getQuestionById(questionId: any) {
    this.http.get('/adminpage/mcqquestion/getQuestionById?questionId=' + questionId)
      .subscribe((response: any) => {
        if (response.success) {
          this.question = response.data
        }
      })
  }
  public getAllQuestionType() {
    this.http.get('/adminpage/mcqquestion/getAllQuestionType')
      .subscribe((response: any) => {
        if (response.success) {
          this.questionTypes = response.data;
        }
      })
  }
  public getAllLevel() {
    this.http.get('/adminpage/mcqquestion/getAllLevel')
      .subscribe((response: any) => {
        if (response.success) {
          this.levels = response.data;
        }
      })
  }
  public updateQuestion() {
    this.http.post('/adminpage/mcqquestion/updateQuestion', this.question)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Cập nhật thành công', 'SUCCESS');
          this.router.navigate(['/adminpage/mcqquestion']);
        }
        else {
          this.sharedService.show('Xảy ra lỗi khi cập nhật', 'ERROR');
        }
      })
  }
}
