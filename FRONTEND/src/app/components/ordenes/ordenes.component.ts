import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../base/base.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrdenResponse } from 'src/app/shared/models/ordenResponse.model';
import { OrdenService } from 'src/app/shared/services/orden.service';
import { EstadosWebApi } from 'src/app/shared/constant';
import * as moment from "moment";

@Component({
  selector: 'app-ordenes',
  templateUrl: './ordenes.component.html',
  styleUrls: ['./ordenes.component.css']
})
export class OrdenesComponent extends ComponentBase implements OnInit {
  public isOpenModal: boolean;
  public list: OrdenResponse[] = [];

  constructor(
    public service: OrdenService,
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
    //debugger;
    console.log(`params: ${JSON.stringify(params)}`);
    if (params.idOrden !== 0) {
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
      params.estado = { idEstado: EstadosWebApi.Creado };
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
      this.service.Delete(id, parseInt(EstadosWebApi.Eiminado)).subscribe(
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
  getFormat(date) {
    return moment(date).format("DD/MM/YYYY");
  }
}
