import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpromotionModuleComponent } from './addpromotion-module.component';

describe('AddpromotionModuleComponent', () => {
  let component: AddpromotionModuleComponent;
  let fixture: ComponentFixture<AddpromotionModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddpromotionModuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddpromotionModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
