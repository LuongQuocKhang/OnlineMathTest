import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { SharedService } from "../../Services/sharedService";
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public mcqs = [] as any;
  constructor(private http: HttpClient, private sharedService: SharedService,
    private router: Router, private route: ActivatedRoute) {
    sharedService.checkAdmin();
  }

  ngOnInit() {
    this.getAll();
  }
  public getAll() {
    this.http.get('/MCQ/GetMCQs').subscribe(
      (response: any) => {
        this.mcqs = response.data;
      }
    )
  }

  public viewDetail(item: any) {
    window.location.href = 'r' + '/#/mcq/mcqdetail/' + item.id;
  }

  public viewMore() {
    this.router.navigate(['/mcq/listmcq/']);
  }

  public viewAllMcq(id: any) {
    this.router.navigate(['/mcq/listmcqbyquestion', id]);
  }
  public viewAllMcqByLevel(id: any) {
    this.router.navigate(['/mcq/listmcqbylevel', id]);
  }
}
