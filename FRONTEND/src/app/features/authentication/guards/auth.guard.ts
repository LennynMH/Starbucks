import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";

@Injectable({ providedIn: 'root' })
export class AuthorizationGuard implements CanActivate {
  constructor(private router: Router) { }
  canActivate() {
    //debugger;
    let isvalid = localStorage.getItem('isLogin');
    //console.log(`isvalid: ${JSON.stringify(isvalid)}`);
    if (parseInt(isvalid) > 0) {
      return true;
    }
    else {
      this.router.navigate(['/Login']);
      return false;
    }
  }
}
