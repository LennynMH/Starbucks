import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UsuarioService } from '../../../shared/services/usuario.service';
import { UsuarioRequest } from '../../../shared/models/usuarioRequest.model';
import { ComponentBase } from '../../base/base.component';
import { RolService } from '../../../shared/services/rol.service';
import { RolResponse } from '../../../shared/models/rolResponse.model';

@Component({
  selector: 'app-usuario-popup',
  templateUrl: './usuario-popup.component.html',
  styleUrls: ['./usuario-popup.component.css']
})

export class UsuarioPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();
  public tituloModal: string;
  public requestentity: UsuarioRequest = new UsuarioRequest();
  public listRol: RolResponse[] = [];

  constructor(
    public service: UsuarioService,
    public serviceRol: RolService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "Mantenimiento Usuario";
    this.dateAdapter.setLocale('en-GB');
  }

  ngOnInit(): void {
    this.ListarRol();
    this.Initialize();
  }

  Initialize() {
    //debugger;
    let id = localStorage.getItem("id");
    if (id) {
      this.service.Select(id).subscribe(
        (response) => {
          this.requestentity = response.data;
          this.requestentity.idRol = response.data = this.requestentity.rol.idRol;
        },
        (error) => {
          this.ManageErrors(error);
        });
      localStorage.removeItem("id");
    }
    else {
      this.requestentity = new UsuarioRequest();
    }
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

  onChangeRol(value: any) {
    this.requestentity.idRol = value;
  }

  onChangeSexo(value: any) {
    this.requestentity.sexo = value;
  }

  onSubmit(form: NgForm) {
    this.InsertModal(form)
  }

  InsertModal(form: NgForm) {
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new UsuarioRequest();
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }
}
