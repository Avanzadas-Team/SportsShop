import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartModuleComponent } from './cart-module.component';

describe('CartModuleComponent', () => {
  let component: CartModuleComponent;
  let fixture: ComponentFixture<CartModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartModuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
