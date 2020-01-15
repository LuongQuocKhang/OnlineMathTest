import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";

@Component({
  selector: 'app-mcqquestion-add',
  templateUrl: './mcqquestion.add.component.html',
  styleUrls: ['./mcqquestion.add.component.css']
})
export class AddMcqQuestionComponent implements OnInit {
  public question = {} as any;
  public questionTypes = [] as any;
  public selectedType = {} as any;
  public levels = [] as any;
  public selectedLevel = {} as any;
  public answer = {
    A: "" as string,
    B: "" as string,
    C: "" as string,
    D: "" as string,
  }

  public answers = [] as any;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private sharedService: SharedService)
  {
    this.getAllQuestionType();
    this.getAllLevel();
  }

  ngOnInit() {
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
  public addQuestion() {
    this.answers = [] as any;
    for (let prop in this.answer) {
      let questionanswer = {
        choice: prop,
        answer: this.answer[prop],
      }
      this.answers.push(questionanswer);
    }
    this.question.questionType = this.selectedType;
    this.question.levelType = this.selectedLevel;

    this.question.answers = this.answers;
    this.http.post('/adminpage/mcqquestion/addQuestion', this.question)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Thêm thành công', 'SUCCESS');
          this.router.navigate(['/adminpage/mcqquestion']);
        }
        else {
          this.sharedService.show('Xảy ra lỗi khi thêm', 'ERROR');
        }
      })
  }
}
