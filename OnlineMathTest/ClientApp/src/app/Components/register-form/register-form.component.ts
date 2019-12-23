import { Component, OnInit } from '@angular/core';

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
  }
  constructor() { }

  ngOnInit() {
  }
  public onSubmit() {

  }
}
