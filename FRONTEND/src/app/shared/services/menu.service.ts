import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { catchError, map } from 'rxjs';
import { ServiceBase } from './serviceBase.service';
import { IncomeWebApi, MenuWebApi, RolesWebApi } from '../constant';

@Injectable({ providedIn: 'root' })

export class MenuService extends ServiceBase {
  readonly baseURL = environment.api;

  constructor(private http: HttpClient) {
    super();
  }

  ListarMenuByRol(idrol: number) {
    var menuItems = [];
    if (idrol == Number.parseInt(RolesWebApi.Administrador)) {
      menuItems = MenuWebApi.Administrador;
    }
    else if (idrol == Number.parseInt(RolesWebApi.Usuario)) {
      menuItems = MenuWebApi.Usuario;
    }
    else if (idrol == Number.parseInt(RolesWebApi.Empleado)) {
      menuItems = MenuWebApi.Empleado;
    }
    else if (idrol == Number.parseInt(RolesWebApi.Supervisor)) {
      menuItems = MenuWebApi.Supervisor;
    }
    return menuItems;
  }
}
