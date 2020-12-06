import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AddArticleModuleComponent } from './components/add-article-module/add-article-module.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddpromotionModuleComponent } from './components/addpromotion-module/addpromotion-module.component';


@NgModule({
  declarations: [AddArticleModuleComponent, AddpromotionModuleComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule
  ],
  exports: [
    AddArticleModuleComponent,
    AddpromotionModuleComponent
  ],
  bootstrap: [
    AddArticleModuleComponent,
    AddpromotionModuleComponent
  ]
})
export class AdminModule { }
