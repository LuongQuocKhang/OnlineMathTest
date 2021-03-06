import { Component, Inject, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from "../../Services/sharedService";
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from 'src/app/Services/AuthenticationService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OnlineMathTest - agnualr';

  public currentUser = {} as any;
  constructor(private router: Router, private sharedService: SharedService, private http: HttpClientModule,
    private authenticationService: AuthenticationService, private cdRef: ChangeDetectorRef) {
    this.getCurrentUser();
  }
  ngAfterViewInit() {
    this.cdRef.detectChanges();
  }
  public getCurrentUser() {
    if (localStorage.getItem('currentUser')) {
      this.currentUser = localStorage.getItem('currentUser');
    }
  }

  public logout() {
    this.authenticationService.logout();
    this.router.navigate(['']);
    window.location.href = '/';
  }
}
