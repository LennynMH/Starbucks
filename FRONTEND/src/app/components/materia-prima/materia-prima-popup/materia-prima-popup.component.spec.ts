import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MateriaPrimaPopupComponent } from './materia-prima-popup.component';

describe('MateriaPrimaPopupComponent', () => {
  let component: MateriaPrimaPopupComponent;
  let fixture: ComponentFixture<MateriaPrimaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MateriaPrimaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MateriaPrimaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
