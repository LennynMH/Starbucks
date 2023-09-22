import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Credenciales } from '../../models/request/credenciales.model';
import { AuthService } from '../../services/auth.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public credenciales: Credenciales = new Credenciales();
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  constructor(
    public service: AuthService,
    private readonly router: Router,
    private readonly toastr: ToastrService,
  ) { }

  ngOnInit(): void {
  }

  public ObtainLoginHB() {
    //debugger;
    let params = this.credenciales;
    this.service.Autenticar(params).subscribe((response) => {
      if (response.success) {
        this.isLoggedIn = true;
        this.isLoginFailed = false;
        localStorage.setItem('SessionToken', JSON.stringify(response.data.token));
        localStorage.setItem('SessionUsuario', JSON.stringify(response.data.usuario));
        localStorage.setItem('isLogin', this.isLoggedIn == true ? "1" : "0");
        //console.log(`SessionToken: ${JSON.stringify(response.data.token)}`);
        this.redirectUser();
      }
      else {
        this.toastr.error("Error en autenticación");
      }
    });
  }
  private redirectUser(): void {
    this.router.navigate(['/Home']);
  }
}
