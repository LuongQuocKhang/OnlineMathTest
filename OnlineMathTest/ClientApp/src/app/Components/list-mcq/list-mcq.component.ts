import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";
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
    this.router.navigate(['/mcqdetail/', item.id]);
  }
}
