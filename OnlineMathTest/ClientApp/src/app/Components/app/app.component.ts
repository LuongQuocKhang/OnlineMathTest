import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OnlineMathTest - agnualr';

  public currentUser = {} as any;
  constructor(private router: Router, private sharedService: SharedService) {
    this.getCurrentUser();
  }

  public getCurrentUser() {
    if (localStorage.getItem('currentUser')) {
      this.currentUser = localStorage.getItem('currentUser');
    }
  }
}
