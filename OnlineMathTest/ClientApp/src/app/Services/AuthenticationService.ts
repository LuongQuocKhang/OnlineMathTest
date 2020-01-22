import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, CanActivate } from '@angular/router';
import { SharedService } from './sharedService';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient, private router: Router, private sharedService: SharedService) { }

  login(model: any) {
    return this.http.post('/account/login', model)
      .map((response: any) => {
        // login successful if there's a jwt token in the response
        if (response.success) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(response.data));
        }
        else {
          this.sharedService.show("Đăng nhập không thành công", "ERROR");
        }
        return response;
      });
  }
  public register(model: any) {
    return this.http.post('/account/register', model, model)
      .subscribe((response: any) => {
        if (response.success) {
          this.login(model);
        }
        else {
          this.sharedService.show('Đăng ký không thành công', 'ERROR');
        }
      });
  }
  logout() {
    localStorage.removeItem('currentUser');
    this.sharedService.getCurrentUser();
  }
}
