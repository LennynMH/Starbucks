import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdenActualizarPopupComponent } from './orden-actualizar-popup.component';

describe('OrdenActualizarPopupComponent', () => {
  let component: OrdenActualizarPopupComponent;
  let fixture: ComponentFixture<OrdenActualizarPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdenActualizarPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdenActualizarPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
