import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from 'src/app/Services/AuthenticationService';
@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  public userRegistration = {
    name: '' as string,
    email: '' as string,
    password: '' as string,
    comfirmPassword: '' as string,
    firstName: '' as string,
    lastName: '' as string,
    userName: '' as string,
    returnUrl: '' as string
  }
  public returnUrl = '' as string;
  model: any = {};
  loading = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private http: HttpClient) {

  }
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.userRegistration.returnUrl = this.returnUrl;
  }
  register() {
    this.loading = true;
    this.authenticationService.register(this.userRegistration)
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.loading = false;
        });
  }
}
