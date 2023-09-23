import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ComponentBase } from '../../base/base.component';
import { OrdenService } from 'src/app/shared/services/orden.service';
import { ItemService } from 'src/app/shared/services/Item.service';
import { OrdenRequest } from 'src/app/shared/models/ordenRequest.model';
import { ItemResponse } from 'src/app/shared/models/itemResponse.model';
import { OrdenItem } from 'src/app/shared/entity/ordenItem.model';
import { UsuarioResponse } from 'src/app/shared/models/usuarioResponse.model';
@Component({
  selector: 'app-ordenes-popup',
  templateUrl: './ordenes-popup.component.html',
  styleUrls: ['./ordenes-popup.component.css']
})
export class OrdenesPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();

  public tituloModal: string;
  public sizeModal: string;
  public idItem: number = 0;

  public requestentity: OrdenRequest = new OrdenRequest();
  public lisItem: ItemResponse[] = [];
  public listOrdenItem: OrdenItem[] = [];
  public item: ItemResponse = new ItemResponse();

  public precioItem: number = 0;
  public cantidadItem: number = 0;
  public usuarioResponse: UsuarioResponse = new UsuarioResponse();
  public idOrden: number = 0;
  constructor(
    public serviceOrden: OrdenService,
    public serviceItem: ItemService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.sizeModal = "modal-lg";
    this.dateAdapter.setLocale('en-GB');
  }

  ngOnInit(): void {
    this.idOrden = parseInt(localStorage.getItem("id") == null ? "0" : localStorage.getItem("id"));
    this.tituloModal = this.idOrden == 0 ? "crear orden" : "actualizar orden";
    this.usuarioResponse = JSON.parse(localStorage.getItem("SessionUsuario"));
    this.onCargarItem();
    this.Initialize();
  }

  Initialize() {
    let id = localStorage.getItem("id");
    if (id) {
      this.serviceOrden.Select(id).subscribe(
        (response) => {
          //debugger;
          if (response.success) {
            let datos = response.data;
            this.requestentity = datos.orden;
            this.listOrdenItem = datos.ordenItem;
            //console.log(`datos: ${JSON.stringify(datos)}`);
          }
        },
        (error) => {
          this.ManageErrors(error);
        });
      localStorage.removeItem("id");
    }
    else {
      this.requestentity = new OrdenRequest();
    }
  }

  onCargarItem() {
    this.serviceItem.Listar({}).subscribe(
      (response) => {
        this.lisItem = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  onSubmit(form: NgForm) {
    if (this.listOrdenItem.length > 0) {
      this.InsertModal(form)
    }
    else {
      this.toastr.error("falta agregar detalles");
    }
  }

  onChangeItem(value: any) {
    //debugger;
    this.idItem = value;
    var item = this.lisItem.find(x => x.idItem == value);
    this.item = item;
    //console.log(`materia: ${JSON.stringify(materia)}`);;
  }

  onclickAgregar() {
    //debugger;
    var ordenItem: OrdenItem = new OrdenItem();
    if (this.idItem == 0) {
      this.toastr.error("selecione items");
    }
    else {
      var validaitem = this.listOrdenItem.find(x => x.item.idItem == this.idItem);
      if (validaitem) {
        this.toastr.error("la materia prima ya esta agregada");
      } else {
        ordenItem.item = this.item;
        ordenItem.tiempoItem = 5;
        ordenItem.precio = this.precioItem;
        ordenItem.cantidad = this.cantidadItem;
        this.listOrdenItem.push(ordenItem);
      }
    }
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }

  InsertModal(form: NgForm) {
    this.requestentity.usuario = this.usuarioResponse; //{ idUsuario: this.usuarioResponse.idUsuario };
    this.requestentity.listOrdenItem = this.listOrdenItem;
    this.requestentity.tiempoOrden = this.listOrdenItem.map(a => a.tiempoItem).reduce(function (a, b) {
      return a + b;
    });
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new OrdenRequest();
  }

  Delete(idOrdenItem: number, idItem: number) {
    //debugger;
    this.listOrdenItem = this.listOrdenItem.filter((value, key) => {
      return value.item.idItem != idItem;
    });
    if (this.listOrdenItem.length > 0) {
      this.requestentity.tiempoOrden = this.listOrdenItem.map(a => a.tiempoItem).reduce(function (a, b) {
        return a + b;
      });
    }
  }
}
