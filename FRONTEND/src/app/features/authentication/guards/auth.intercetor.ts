import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

//@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    debugger;
    return next.handle(this.addAuthToken(request));
  }
  addAuthToken(request: HttpRequest<any>) {
    debugger;
    const token = localStorage.getItem("SessionToken")!;
    console.log(`addAuthToken.token: ${JSON.stringify(token)}`);
    return request.clone({
      setHeaders: {
        Authorization: `Basic ${token}`
      }
    })
  }
}

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthorizationInterceptorGuard implements HttpInterceptor {
//   constructor(private router: Router) { }
//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
//     debugger;
//     const _token = localStorage.getItem("Token")!;
//     const apiReq = req.clone({
//       setHeaders: { Authorization: `Bearer ${_token}` }
//     });
//     return next.handle(apiReq);
//   }
// }
// import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// @Injectable()
// export class AuthorizationInterceptorGuard implements HttpInterceptor {
//   constructor() { }
//   token = localStorage.getItem('Token');
//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     debugger;
//     const auth = req.clone({ headers: new HttpHeaders().set(`Authorization`, `Bearer ${this.token}`) });
//     return next.handle(auth);
//   }
// }
