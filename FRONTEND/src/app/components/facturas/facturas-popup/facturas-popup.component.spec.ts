import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturasPopupComponent } from './facturas-popup.component';

describe('FacturasPopupComponent', () => {
  let component: FacturasPopupComponent;
  let fixture: ComponentFixture<FacturasPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FacturasPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FacturasPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
