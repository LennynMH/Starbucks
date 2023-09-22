import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ComponentBase } from '../../base/base.component';
import { ItemRequest } from '../../../shared/models/itemRequest.model';
import { ItemService } from '../../../shared/services/Item.service';
import { MateriaPrimaService } from '../../../shared/services/MateriaPrima.service';
import { ItemMateriaPrima } from 'src/app/shared/entity/itemMateriaPrima.model';
import { MateriaPrima } from 'src/app/shared/entity/materiaPrima.model';

@Component({
  selector: 'app-items-popup',
  templateUrl: './items-popup.component.html',
  styleUrls: ['./items-popup.component.css']
})
export class ItemsPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();
  public tituloModal: string;
  public sizeModal: string;
  public idMateriaPrima: number = 0;
  public requestentity: ItemRequest = new ItemRequest();
  public requestItemMateriaPrima: ItemMateriaPrima = new ItemMateriaPrima();
  public listItemMateriaPrima: ItemMateriaPrima[] = [];
  public materiaPrima: MateriaPrima = new MateriaPrima();
  public lisMateriaPrima: MateriaPrima[] = [];
  public precioMateriaPrima: number = 0;
  public cantidadMateriaPrima: number = 0;

  constructor(
    public service: ItemService,
    public serviceMateriaPrima: MateriaPrimaService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "Mantenimiento Item";
    this.sizeModal = "modal-lg";
  }

  ngOnInit(): void {
    this.onCargarMateriaPrima();
    this.Initialize();
  }

  Initialize() {
    let id = localStorage.getItem("id");
    if (id) {
      this.service.Select(id).subscribe(
        (response) => {
          debugger;
          if (response.success) {
            let datos = response.data;
            this.requestentity.idItem = datos.item.idItem;
            this.requestentity.descripcion = datos.item.descripcion;
            this.requestentity.costoTotal = datos.item.costoTotal;
            this.listItemMateriaPrima = datos.itemMateriaPrima;
            console.log(`datos: ${JSON.stringify(datos)}`);
          }
        },
        (error) => {
          this.ManageErrors(error);
        });
      localStorage.removeItem("id");
    }
    else {
      this.requestentity = new ItemRequest();
    }
  }

  onCargarMateriaPrima() {
    this.serviceMateriaPrima.Listar().subscribe(
      (response) => {
        this.lisMateriaPrima = response.data;
      },
      (error) => {
        this.ManageErrors(error);
      });
  }

  onChangeMateriaPrima(value: any) {
    //debugger;
    this.idMateriaPrima = value;
    var materia = this.lisMateriaPrima.find(x => x.idMateriaPrima == value);
    this.materiaPrima = materia;
    this.precioMateriaPrima = 0;
    //this.cantidadMateriaPrima =materia.cantidad;
    this.cantidadMateriaPrima = 1;
    //console.log(`materia: ${JSON.stringify(materia)}`);;
  }

  Delete(idItemMateriPrima: number, idMateriaPrima: number) {
    //debugger;
    this.listItemMateriaPrima = this.listItemMateriaPrima.filter((value, key) => {
      return value.materiaPrima.idMateriaPrima != idMateriaPrima;
    });

    if (this.listItemMateriaPrima.length > 0) {
      this.requestentity.costoTotal = this.listItemMateriaPrima.map(a => a.precio).reduce(function (a, b) {
        return a + b;
      });
    }
    else { this.requestentity.costoTotal = 0; }
  }

  onclickAgregar() {
    //debugger;
    var materiaPrima: ItemMateriaPrima = new ItemMateriaPrima();
    if (this.idMateriaPrima == 0) {
      this.toastr.error("selecione materia prima");
    } else if (this.precioMateriaPrima == 0) {
      this.toastr.error("ingrese precio");
    }
    else {
      var validaitem = this.listItemMateriaPrima.find(x => x.materiaPrima.idMateriaPrima == this.idMateriaPrima);
      if (validaitem) {
        this.toastr.error("la materia prima ya esta agregada");
      } else {
        this.requestItemMateriaPrima.materiaPrima = null;
        materiaPrima.materiaPrima = this.materiaPrima;
        materiaPrima.precio = this.precioMateriaPrima;
        materiaPrima.cantidad = this.cantidadMateriaPrima;
        this.listItemMateriaPrima.push(materiaPrima);
        this.requestentity.costoTotal = this.listItemMateriaPrima.map(a => a.precio).reduce(function (a, b) {
          return a + b;
        });
      }
    }
  }

  onSubmit(form: NgForm) {
    this.InsertModal(form)
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }

  InsertModal(form: NgForm) {
    this.requestentity.listItemMateriaPrimaEntity = this.listItemMateriaPrima;
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new ItemRequest();
  }
}
