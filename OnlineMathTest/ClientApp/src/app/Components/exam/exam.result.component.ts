import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";

declare var $: any;
@Component({
  selector: 'app-exam-result',
  templateUrl: './exam.result.component.html',
  styleUrls: ['./exam.result.component.css']
})
export class ExamResultComponent implements OnInit {
  private sub: any;
  public model = {} as any;
  public mcqId = 0 as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.mcqId = params['id'];
    });
    this.getMCQById();
  }

  ngOnInit() {

  }
  public getMCQById() {
    this.http.get('/MCQ/GetExamResultById?id=' + this.mcqId).subscribe(
      (response: any) => {
        this.model = response.data;
      })
  }
  ngAfterViewInt() {

  }
 
}
