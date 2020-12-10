import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonClientsComponent } from './common-clients.component';

describe('CommonClientsComponent', () => {
  let component: CommonClientsComponent;
  let fixture: ComponentFixture<CommonClientsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommonClientsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommonClientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
