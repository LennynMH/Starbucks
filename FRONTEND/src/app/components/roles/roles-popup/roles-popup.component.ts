import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { RolService } from '../../../shared/services/rol.service';
import { RolRequest } from '../../../shared/models/rolRequest.model';
import { ComponentBase } from '../../base/base.component';

@Component({
  selector: 'app-roles-popup',
  templateUrl: './roles-popup.component.html',
  styleUrls: ['./roles-popup.component.css']
})
export class RolesPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();
  public tituloModal: string;
  public requestentity: RolRequest = new RolRequest();
  public fecha: any;

  constructor(
    public service: RolService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "Mantenimiento Roles";
    this.dateAdapter.setLocale('en-GB');
  }

  ngOnInit(): void {
    this.Initialize();
  }

  Initialize() {
    let id = localStorage.getItem("id");
    if (id) {
      this.service.Select(id).subscribe(
        (response) => {
          this.requestentity = response.data;
        },
        (error) => {
          this.ManageErrors(error);
        });
      localStorage.removeItem("id");
    }
    else {
      this.requestentity = new RolRequest();
    }
  }

  onSubmit(form: NgForm) {
    this.InsertModal(form)
  }

  InsertModal(form: NgForm) {
    debugger;
    this.eventInsert.emit(this.requestentity);
    this.ResetForm(form);
  }

  ResetForm(form: NgForm) {
    form.form.reset();
    this.requestentity = new RolRequest();
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }
}
