import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    var user = localStorage.getItem('currentUser');
    var userJson = JSON.parse(user);
    if (userJson && userJson.role != "Admin") {
      return true;
    }
    else if (userJson && userJson.role == "Admin") {
      this.router.navigate(['/dashboard']);
    }
    else {
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    }
    return false;
  }
}
