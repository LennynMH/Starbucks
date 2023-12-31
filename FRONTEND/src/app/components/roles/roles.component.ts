import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../base/base.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RolResponse } from 'src/app/shared/models/rolResponse.model';
import { RolService } from '../../shared/services/rol.service';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})

export class RolesComponent extends ComponentBase implements OnInit {
  public isOpenModal: boolean;
  public list: RolResponse[] = [];

  constructor(
    public service: RolService,
    public override toastr: ToastrService,
    public override router: Router) {
    super(router, toastr);
  }
  ngOnInit(): void {
    this.Listar();
  }

  Listar() {
    this.list = [];
    this.service.Listar({}).subscribe(
      (response) => {
        this.list = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  Insert(params: any) {
    console.log(`params: ${JSON.stringify(params)}`);
    if (params.idRol !== 0) {
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
    localStorage.setItem("id", id.toString());
    this.isOpenModal = true;
  }

  OpenCreate() {
    this.isOpenModal = true;
  }
}
