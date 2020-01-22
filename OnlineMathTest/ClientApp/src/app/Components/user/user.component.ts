import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  private sub: any;
  public userId = 0;
  public user = {} as any;
  public roles = [] as any;

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.userId = params['id'];
    });
    this.getUserProfileById();
    this.getRoles();
  }

  ngOnInit() {
  }
  public getUserProfileById() {
    this.http.get('/user/GetUserProfileById?id=' + this.userId)
      .subscribe((response: any) => {
        if (response.success) {
          this.user = response.data;
        }
      })
  }
  public getRoles() {
    this.http.get('/user/getRoles')
      .subscribe((response: any) => {
        if (response.success) {
          this.roles = response.data;
        }
      })
  }
  public updateUser() {
    this.http.post('/user/updateUser', this.user)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Cập nhật thành công', 'SUCCESS');
          this.getUserProfileById();
        }
        else {
          this.sharedService.show('Xảy ra lỗi khi cập nhật', 'ERROR');
        }
      })
  }
}
