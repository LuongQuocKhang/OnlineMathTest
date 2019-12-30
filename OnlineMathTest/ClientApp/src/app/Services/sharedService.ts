import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

declare var toastr: any;
declare var rolePermission: any;
@Injectable()
export class SharedService {

  public currentUser = null;
  constructor(private http: HttpClient, private router: Router) {
    this.getCurrentUser();
  }
  public getCurrentUser() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }
  public checkAdmin() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (this.isAdmin()) {
      this.router.navigate(['/dashboard']);
    }
  }
  public isAdmin(): boolean {
    if (this.currentUser != null) {
      if (this.currentUser.role == 'Admin') return true;
    }
    return false;
  }
  show(code: any, type: any) {
    switch (type) {
      case 'ERROR':
        toastr.options = {
          closeButton: false,
          positionClass: 'toast-top-right',
          onclick: null,
          timeOut: 0,
          extendedTimeOut: 0
        };
        toastr["error"](code);
        break;
      case 'SUCCESS':
        toastr.options = {
          closeButton: false,
          positionClass: 'toast-top-right',
          onclick: null
        };
        if (code == null || code == undefined || code == '') {
          code = 'SCC_SAVE_SUCCESSFUL'
        }
        toastr["success"](code);
        break;
    }

  }
}
