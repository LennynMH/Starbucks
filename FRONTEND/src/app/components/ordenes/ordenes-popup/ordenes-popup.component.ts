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

  constructor(
    public serviceOrden: OrdenService,
    public serviceItem: ItemService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "crear orden";
    this.sizeModal = "modal-lg";
  }

  ngOnInit(): void {
    this.onCargarItem();
    this.Initialize();
  }

  Initialize() {
    let id = localStorage.getItem("id");
    if (id) {
      this.serviceOrden.Select(id).subscribe(
        (response) => {
          debugger;
          if (response.success) {
            let datos = response.data;
            // this.requestentity.idItem = datos.item.idItem;
            // this.requestentity.descripcion = datos.item.descripcion;
            // this.requestentity.costoTotal = datos.item.costoTotal;
            // this.listItemMateriaPrima = datos.itemMateriaPrima;
            console.log(`datos: ${JSON.stringify(datos)}`);
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
    this.InsertModal(form)
  }

  onChangeItem(value: any) {
    //debugger;
    // this.idMateriaPrima = value;
    // var materia = this.lisMateriaPrima.find(x => x.idMateriaPrima == value);
    // this.materiaPrima = materia;
    // this.precioMateriaPrima = 0;
    // this.cantidadMateriaPrima = 1;
    //console.log(`materia: ${JSON.stringify(materia)}`);;
  }

  onclickAgregar() {
    //debugger;
    // var materiaPrima: ItemMateriaPrima = new ItemMateriaPrima();
    // if (this.idMateriaPrima == 0) {
    //   this.toastr.error("selecione materia prima");
    // } else if (this.precioMateriaPrima == 0) {
    //   this.toastr.error("ingrese precio");
    // }
    // else {
    //   var validaitem = this.listItemMateriaPrima.find(x => x.materiaPrima.idMateriaPrima == this.idMateriaPrima);
    //   if (validaitem) {
    //     this.toastr.error("la materia prima ya esta agregada");
    //   } else {
    //     this.requestItemMateriaPrima.materiaPrima = null;
    //     materiaPrima.materiaPrima = this.materiaPrima;
    //     materiaPrima.precio = this.precioMateriaPrima;
    //     materiaPrima.cantidad = this.cantidadMateriaPrima;
    //     this.listItemMateriaPrima.push(materiaPrima);
    //     this.requestentity.costoTotal = this.listItemMateriaPrima.map(a => a.precio).reduce(function (a, b) {
    //       return a + b;
    //     });
    //   }
    // }
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }

  InsertModal(form: NgForm) {
    //this.requestentity.listItemMateriaPrimaEntity = this.listItemMateriaPrima;
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new OrdenRequest();
  }

}
