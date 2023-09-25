import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ComponentBase } from '../../base/base.component';
import { OrdenRequest } from 'src/app/shared/models/ordenRequest.model';
import { UsuarioResponse } from 'src/app/shared/models/usuarioResponse.model';
import { UsuarioService } from 'src/app/shared/services/usuario.service';
import { OrdenService } from 'src/app/shared/services/orden.service';
import { Rol } from 'src/app/shared/entity/rol.model';
import { EstadosWebApi, RolesWebApi } from 'src/app/shared/constant';
import { Usuario } from 'src/app/shared/entity/usuario.model';
import { Estado } from 'src/app/shared/entity/estado.model';
@Component({
  selector: 'app-orden-actualizar-popup',
  templateUrl: './orden-actualizar-popup.component.html',
  styleUrls: ['./orden-actualizar-popup.component.css']
})
export class OrdenActualizarPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();

  public requestentity: OrdenRequest = new OrdenRequest();
  public tituloModal: string;
  public sizeModal: string;
  public idOrden: number = 0;

  public listEmpleado: UsuarioResponse[] = [];
  public idEmpleado: number = 0;

  constructor(
    public serviceUsuario: UsuarioService,
    public serviceOrden: OrdenService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "Asignar Empleado";
    this.sizeModal = "";
  }

  ngOnInit(): void {
    this.idOrden = parseInt(localStorage.getItem("id"));
    this.onCargarEmpleado();
  }

  onCargarEmpleado() {
    //debugger;
    let request = { idRol: parseInt(RolesWebApi.Empleado) };
    this.serviceUsuario.Listar(request).subscribe(
      (response) => {
        this.listEmpleado = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  onChangeEmpleado(value: any) {
    //debugger;
    this.idEmpleado = value;
    //console.log(`materia: ${JSON.stringify(materia)}`);;
  }

  onSubmit(form: NgForm) {
    if (this.idEmpleado > 0) {
      this.InsertModal(form)
    }
    else {
      this.toastr.error("falta agregar detalles");
    }
  }

  InsertModal(form: NgForm) {
    this.requestentity.idOrden = this.idOrden;
    this.requestentity.empleado = new Usuario();
    this.requestentity.empleado.idUsuario = this.idEmpleado;
    this.requestentity.estado = new Estado();
    this.requestentity.estado.idEstado = parseInt(EstadosWebApi.Asignado);
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new OrdenRequest();
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }
}
