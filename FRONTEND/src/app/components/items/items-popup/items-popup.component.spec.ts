import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemsPopupComponent } from './items-popup.component';

describe('ItemsPopupComponent', () => {
  let component: ItemsPopupComponent;
  let fixture: ComponentFixture<ItemsPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemsPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemsPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
