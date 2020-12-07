import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AddArticleModuleComponent } from './components/add-article-module/add-article-module.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AddArticleModuleComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule
  ],
  exports: [
    AddArticleModuleComponent
  ],
  bootstrap: [
    AddArticleModuleComponent
  ]
})
export class AdminModule { }
