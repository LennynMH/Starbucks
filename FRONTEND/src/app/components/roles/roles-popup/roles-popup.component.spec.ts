import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RolesPopupComponent } from './roles-popup.component';

describe('RolesPopupComponent', () => {
  let component: RolesPopupComponent;
  let fixture: ComponentFixture<RolesPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RolesPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RolesPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
