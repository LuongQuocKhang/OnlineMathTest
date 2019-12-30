import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
@Component({
  selector: 'app-mcq-detail',
  templateUrl: './mcq-detail.component.html',
  styleUrls: ['./mcq-detail.component.css']
})
export class McqDetailComponent implements OnInit {
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
    this.http.get('/MCQ/GetMCQById?id=' + this.mcqId).subscribe(
      (response: any) => {
        this.model = response.data;
    })
  }
}
