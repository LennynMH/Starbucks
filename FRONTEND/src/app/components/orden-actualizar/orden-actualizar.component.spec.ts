import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdenActualizarComponent } from './orden-actualizar.component';

describe('OrdenActualizarComponent', () => {
  let component: OrdenActualizarComponent;
  let fixture: ComponentFixture<OrdenActualizarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdenActualizarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdenActualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
