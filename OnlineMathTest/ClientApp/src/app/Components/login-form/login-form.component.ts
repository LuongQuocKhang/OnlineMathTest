import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from 'src/app/Services/AuthenticationService';
import { SharedService } from 'src/app/Services/sharedService';
@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  public loading = false;
  public loginModel = {
    userName: '' as string,
    password: '' as string,
    rememberMe: false as boolean,
    returnUrl: '' as string
  }
  returnUrl: string;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sharedService: SharedService,
    private authenticationService: AuthenticationService,
    private http: HttpClient) { }

  ngOnInit() {
    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.loginModel.returnUrl = this.returnUrl;
  }

  login() {
    if (this.sharedService.currentUser == null) {
      this.loading = true;
      this.authenticationService.login(this.loginModel)
        .subscribe(
          (response: any) => {
            if (response.success) {
              let user = response.data;
              if (this.isAdmin(user)) {
                this.router.navigate(['/dashboard']);
              }
              this.sharedService.getCurrentUser();
              this.router.navigate([this.returnUrl]);
            }
          },
          error => {
            this.loading = false;
          });
    }
  }
  public isAdmin(user: any): boolean {
    if (user.role == 'Admin') return true;
    return false;
  }
}

