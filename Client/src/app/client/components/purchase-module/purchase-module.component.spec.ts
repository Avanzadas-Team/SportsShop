import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseModuleComponent } from './purchase-module.component';

describe('PurchaseModuleComponent', () => {
  let component: PurchaseModuleComponent;
  let fixture: ComponentFixture<PurchaseModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseModuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
