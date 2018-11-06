import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridSellerComponent } from './grid-seller.component';

describe('GridSellerComponent', () => {
  let component: GridSellerComponent;
  let fixture: ComponentFixture<GridSellerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridSellerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridSellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
