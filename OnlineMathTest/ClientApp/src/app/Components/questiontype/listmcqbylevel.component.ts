import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
@Component({
  selector: 'app-list-mcq-level',
  templateUrl: './listmcqbylevel.component.html',
  styleUrls: ['./listmcqbylevel.component.css']
})
export class ListMcqByQuestionLevelComponent implements OnInit {
  private sub: any;
  public questionTypeId = 0;
  public mcqs = [] as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.questionTypeId = params['id'];
    });
  }

  ngOnInit() {
    this.getAll();
  }
  public getAll() {
    this.http.get('/MCQ/getAllMcqByLevel?id=' + this.questionTypeId).subscribe(
      (response: any) => {
        console.log(response);
        this.mcqs = response.data;
      }
    )
  }
}
