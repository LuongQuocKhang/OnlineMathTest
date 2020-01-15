import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";
@Component({
  selector: 'app-admin-user-edit',
  templateUrl: './usermanagement.edit.component.html',
  styleUrls: ['./usermanagement.edit.component.css']
})
export class EditUserManagementComponent implements OnInit {
  public roles = [] as any;
  private sub: any;
  public userId = 0;
  public user = {} as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.sub = this.route.params.subscribe(params => {
      this.userId = params['id'];
    });
  }

  ngOnInit() {
  }
  public getRoles() {
    this.http.get('/adminpage/usermanagemanet/getRoles')
      .subscribe((response: any) => {
        if (response.success) {
          this.roles = response.data;
        }
      })
  }
  public getUserById(id: any) {
    this.http.get('/adminpage/usermanagement/getUserById?Id=' + id)
      .subscribe((response: any) => {
        if (response.success) {
          this.user = response.data;
        }
      })
  }
}
