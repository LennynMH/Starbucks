import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../base/base.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrdenResponse } from 'src/app/shared/models/ordenResponse.model';
import { OrdenService } from 'src/app/shared/services/orden.service';
import { EstadosWebApi } from 'src/app/shared/constant';
import * as moment from "moment";
import { Estado } from 'src/app/shared/entity/estado.model';
import { Usuario } from 'src/app/shared/entity/usuario.model';

@Component({
  selector: 'app-orden-actualizar',
  templateUrl: './orden-actualizar.component.html',
  styleUrls: ['./orden-actualizar.component.css']
})
export class OrdenActualizarComponent extends ComponentBase implements OnInit {
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
    let request: OrdenResponse = new OrdenResponse();
    request.estado = new Estado();
    request.estado.idEstado = parseInt(EstadosWebApi.Creado);
    request.empleado = new Usuario();
    request.empleado.idUsuario = 0;
    this.list = [];
    this.service.Listar(request).subscribe(
      (response) => {
        this.list = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  Asignar(id: number) {
    debugger;
    // if (confirm('¿Desea deshabilitar el registro?')) {
    //   this.service.Delete(id, parseInt(EstadosWebApi.Eiminado)).subscribe(
    //     (response) => {
    //       try {
    //         if (response.success) {
    //           this.Listar();
    //           this.toastr.success("Deshabilitación exitosa");
    //         }
    //       }
    //       catch (error) {
    //         this.toastr.error("Error en la deshabilitación");
    //       }
    //     },
    //     (error) => {
    //       this.ManageErrors(error);
    //     });
    // }
  }

  getFormat(date) {
    return moment(date).format("DD/MM/YYYY");
  }
}
