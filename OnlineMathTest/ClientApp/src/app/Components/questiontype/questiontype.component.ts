import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
@Component({
  selector: 'app-questiontype',
  templateUrl: './questiontype.component.html',
  styleUrls: ['./questiontype.component.css']
})
export class QuestiontypeComponent implements OnInit {
  public questiontypes = [] as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.getAllQuestionType();
  }

  ngOnInit() {
  }
  public getAllQuestionType() {
    this.http.get('/mcq/getAllQuestionType/').subscribe(
      (response: any) => {
        this.questiontypes = response.data;
      })
  }
  public viewAllQuestion(id: any) {

  }
}
