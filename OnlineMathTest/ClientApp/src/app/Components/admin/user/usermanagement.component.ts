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
  public updateUser(id: any) {
    this.router.navigate(['/adminpage/usermanagement/edit', id]);
  }
  public deleteUser(user: any) {
    this.http.post('/adminpage/usermanagement/deleteUser', user)
      .subscribe((response: any) => {
        if (response.success) {
          this.sharedService.show('Xóa thành công', 'SUCCESS');
          this.getAllUser();
        }
        else {
          this.sharedService.show('Xóa không thành công', 'ERROR');
        }
      })
  }
}
