import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioPopupComponent } from './usuario-popup.component';

describe('UsuarioPopupComponent', () => {
  let component: UsuarioPopupComponent;
  let fixture: ComponentFixture<UsuarioPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuarioPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
