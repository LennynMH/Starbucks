import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RolesWebApi } from '../../shared/constant';

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

  constructor(private router: Router) { }

  ngOnInit(): void {
    debugger;
    let usuario = JSON.parse(localStorage.getItem("SessionUsuario"));
    let isLogin = JSON.parse(localStorage.getItem("isLogin"));
    this.isLoggedIn = isLogin > 0 ? true : false;
    this.idRol = usuario.rol.idRol;
    this.Usuario = usuario.nombre + " - " + usuario.apellido;
    this.RolNombre = usuario.rol.descripcion;

    if (this.idRol == Number.parseInt(RolesWebApi.Administrador)) {
      this.menuItems = [
        {
          id: 1,
          text: 'Usuario',
          url: '/Home/Usuario',
        },
        {
          id: 2,
          text: 'Roles',
          url: '/Home/Roles',
        },
        {
          id: 3,
          text: 'Items',
          url: '/Home/Items',
        },
        {
          id: 4,
          text: 'Materia Prima',
          url: '/Home/MateriaPrima',
        },
        {
          id: 5,
          text: 'Ordenes',
          url: '/Home/Ordenes',
        },
        {
          id: 6,
          text: 'Facturas',
          url: '/Home/Facturas',
        },
      ]
    }
    else if (this.idRol == Number.parseInt(RolesWebApi.Usuario)) {
      this.menuItems = [
        {
          id: 3,
          text: 'Items',
          url: '/Home/Items',
        },
      ]
    }
    else if (this.idRol == Number.parseInt(RolesWebApi.Empleado)) {
      this.menuItems = [
        {
          id: 5,
          text: 'Ordenes',
          url: '/Home/Ordenes',
        },
      ]
    }
    else if (this.idRol == Number.parseInt(RolesWebApi.Supervisor)) {
      this.menuItems = [
        {
          id: 5,
          text: 'Ordenes',
          url: '/Home/Ordenes',
        },
        {
          id: 6,
          text: 'Facturas',
          url: '/Home/Facturas',
        },
      ]
    }
  }

  public LogOut() {
    localStorage.removeItem("isLogin");
    localStorage.removeItem("SessionToken");
    this.router.navigate(['/Login']);
  }
}
