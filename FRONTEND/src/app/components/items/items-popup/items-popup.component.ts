import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ComponentBase } from '../../base/base.component';
import { ItemRequest } from '../../../shared/models/itemRequest.model';
import { ItemService } from '../../../shared/services/Item.service';

@Component({
  selector: 'app-items-popup',
  templateUrl: './items-popup.component.html',
  styleUrls: ['./items-popup.component.css']
})
export class ItemsPopupComponent extends ComponentBase implements OnInit {
  @Output() public close: EventEmitter<boolean> = new EventEmitter();
  @Output() public eventInsert: EventEmitter<any> = new EventEmitter();
  public tituloModal: string;
  public requestentity: ItemRequest = new ItemRequest();

  constructor(
    public service: ItemService,
    public override toastr: ToastrService,
    public override router: Router,
    private dateAdapter: DateAdapter<Date>) {
    super(router, toastr);
    this.tituloModal = "Mantenimiento Item";
  }

  ngOnInit(): void {
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
    this.requestentity = new ItemRequest();
  }

  closeModal($event: boolean) {
    this.close.emit($event);
  }
}
