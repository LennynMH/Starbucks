import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '../base/base.component';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ItemService } from '../../shared/services/Item.service';
import { ItemResponse } from 'src/app/shared/models/itemResponse.model';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent extends ComponentBase implements OnInit {
  public isOpenModal: boolean;
  public list: ItemResponse[] = [];

  constructor(
    public service: ItemService,
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
