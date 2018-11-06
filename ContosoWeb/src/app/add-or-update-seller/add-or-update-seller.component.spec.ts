import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrUpdateSellerComponent } from './add-or-update-seller.component';

describe('AddOrUpdateSellerComponent', () => {
  let component: AddOrUpdateSellerComponent;
  let fixture: ComponentFixture<AddOrUpdateSellerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrUpdateSellerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrUpdateSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
