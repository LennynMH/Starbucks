import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ComponentBase } from '../../base/base.component';
import { OrdenService } from 'src/app/shared/services/orden.service';
import { ItemService } from 'src/app/shared/services/Item.service';
import { OrdenRequest } from 'src/app/shared/models/ordenRequest.model';
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
  public requestentity: OrdenRequest = new OrdenRequest();

  constructor(
    public serviceOrden: OrdenService,
    public serviceItem: ItemService,
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

  onCargarMateriaPrima() {
    // this.serviceMateriaPrima.Listar().subscribe(
    //   (response) => {
    //     this.lisMateriaPrima = response.data;
    //   },
    //   (error) => {
    //     this.ManageErrors(error);
    //   });
  }

  onSubmit(form: NgForm) {
    this.InsertModal(form)
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
