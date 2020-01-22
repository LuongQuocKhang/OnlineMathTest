import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../../Services/sharedService';
import { AuthenticationService } from 'src/app/Services/AuthenticationService';
declare var $: any;
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  constructor(private sharedService: SharedService,
    private authenticationService: AuthenticationService, private router: Router) {
    $(document).click(function (event) {
      $('.dropdown-menu').css("display", 'none');
    });

   
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  public clickProfile() {
    $('.dropdown-menu').css("display",'block');
  }

  public logout() {
    this.authenticationService.logout();
    window.location.href = '/';
  }

  public userProfile() {
    this.router.navigate(['/profile/', this.sharedService.currentUser.id]);
  }

  public stastistics() {
    this.router.navigate(['/statistic/', this.sharedService.currentUser.id]);
  }
}
