import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../base/base.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioResponse } from 'src/app/shared/models/usuarioResponse.model';
import { UsuarioService } from '../../shared/services/usuario.service';
import { RolResponse } from 'src/app/shared/models/rolResponse.model';
import { RolService } from '../../shared/services/rol.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent extends ComponentBase implements OnInit {
  public isOpenModal: boolean;
  public list: UsuarioResponse[] = [];
  public listRol: RolResponse[] = [];
  public idRol: number = 0;

  constructor(
    public service: UsuarioService,
    public serviceRol: RolService,
    public override toastr: ToastrService,
    public override router: Router) {
    super(router, toastr);
  }

  ngOnInit(): void {
    this.ListarRol();
    this.Listar();
  }

  onChangeRol(value: any) {
    this.idRol = value;
  }

  Listar() {
    this.list = [];
    this.service.Listar({ idRol: this.idRol }).subscribe(
      (response) => {
        this.list = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  ListarRol() {
    this.listRol = [];
    this.serviceRol.Listar({}).subscribe(
      (response) => {
        this.listRol = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  Insert(params: any) {
    debugger;
    console.log(`params: ${JSON.stringify(params)}`);
    if (params.idUsuario !== 0) {
      this.service.Update(params).subscribe(
        (response) => {
          try {
            if (response.success) {
              this.Listar();
              this.toastr.success("Edición exitosa");
            }
          }
          catch (error) {
            this.toastr.error("Error en la edición");
          }
        },
        (error) => {
          this.ManageErrors(error);
        });
    }
    else {
      this.service.Insert(params).subscribe(
        (response) => {
          try {
            if (response.success) {
              this.Listar();
              this.toastr.success("Creación exitosa");
            }
          }
          catch (error) {
            this.toastr.error("Error en la inserción");
          }
        },
        (error) => {
          this.ManageErrors(error);
        });
    }
    this.isOpenModal = false;
  }

  Delete(id: number) {
    //debugger;
    if (confirm('¿Desea deshabilitar el registro?')) {
      this.service.Delete(id).subscribe(
        (response) => {
          try {
            if (response.success) {
              this.Listar();
              this.toastr.success("Deshabilitación exitosa");
            }
          }
          catch (error) {
            this.toastr.error("Error en la deshabilitación");
          }
        },
        (error) => {
          this.ManageErrors(error);
        });
    }
  }

  Update(id: number) {
    //debugger;
    localStorage.setItem("id", id.toString());
    this.isOpenModal = true;
  }

  OpenCreate() {
    this.isOpenModal = true;
  }
}
