import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddArticleModuleComponent } from './add-article-module.component';

describe('AddArticleModuleComponent', () => {
  let component: AddArticleModuleComponent;
  let fixture: ComponentFixture<AddArticleModuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddArticleModuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddArticleModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
