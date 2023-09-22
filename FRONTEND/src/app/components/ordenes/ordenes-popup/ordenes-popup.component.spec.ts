import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdenesPopupComponent } from './ordenes-popup.component';

describe('OrdenesPopupComponent', () => {
  let component: OrdenesPopupComponent;
  let fixture: ComponentFixture<OrdenesPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdenesPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdenesPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
