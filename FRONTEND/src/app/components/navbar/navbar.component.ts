import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuWebApi, RolesWebApi } from '../../shared/constant';
import { MenuService } from 'src/app/shared/services/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  public idRol: number = 0;
  public menuItems = [];
  public Usuario: string;
  public RolNombre: string;
  public isLoggedIn: boolean = false;

  constructor(public service: MenuService, private router: Router) { }

  ngOnInit(): void {
    //debugger;
    let usuario = JSON.parse(localStorage.getItem("SessionUsuario"));
    let isLogin = JSON.parse(localStorage.getItem("isLogin"));
    this.isLoggedIn = isLogin > 0 ? true : false;
    this.idRol = usuario.rol.idRol;
    this.Usuario = usuario.nombre.toUpperCase() + " " + usuario.apellido.toUpperCase();
    this.RolNombre = usuario.rol.descripcion.toUpperCase();
    this.menuItems = this.service.ListarMenuByRol(this.idRol);
  }

  public LogOut() {
    localStorage.removeItem("isLogin");
    localStorage.removeItem("SessionToken");
    this.router.navigate(['/Login']);
  }
}
