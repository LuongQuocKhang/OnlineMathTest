import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";

declare var $: any;

@Component({
  selector: 'app-list-mcq',
  templateUrl: './list-mcq.component.html',
  styleUrls: ['./list-mcq.component.css']
})

export class ListMcqComponent implements OnInit {
  private sub: any;
  public mcqs = [] as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
   
  }
 
  ngOnInit() {
    this.getAll();
  }
  public getAll() {
    this.http.get('/MCQ/GetMCQs').subscribe(
      (response: any) => {
        console.log(response);
        this.mcqs = response.data;
      }
    )
  }

  public viewDetail(item: any) {
    window.location.href = 'r'+ '/#/mcq/mcqdetail/' + item.id;
  }

  public search() {
    var seachQuery = {
      key: $("#searchQuery").val()
    };
    this.http.post('/mcq/search', seachQuery)
      .subscribe((response: any) => {
        if (response.success) {
          this.mcqs = response.data;
        }
      })
  }
}
