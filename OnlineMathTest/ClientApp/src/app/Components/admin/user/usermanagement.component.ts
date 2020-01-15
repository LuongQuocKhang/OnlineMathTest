import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from "../../../Services/sharedService";
@Component({
  selector: 'app-admin-user',
  templateUrl: './usermanagement.component.html',
  styleUrls: ['./usermanagement.component.css']
})
export class UserManagementComponent implements OnInit {
  public users = [] as any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute,
    private sharedService: SharedService) {
    this.getAllUser();
  }

  ngOnInit() {
  }
  public getAllUser() {
    this.http.get('/adminpage/usermanagement/getAllUsers')
      .subscribe((response: any) => {
        if (response.success) {
          this.users = response.data;
        }
      })
  }
}
