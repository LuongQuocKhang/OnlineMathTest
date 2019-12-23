import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  public loginModel = {
    email: '' as string,
    password: '' as string,
    rememberMe: false as boolean
  }
  constructor(private http: HttpClient) {

  }

  ngOnInit() {
  }
  public login() {
    this.http.post('/account/login', this.loginModel).subscribe(
      (response) => {
        console.log("Logged in");
      })
  }
}
