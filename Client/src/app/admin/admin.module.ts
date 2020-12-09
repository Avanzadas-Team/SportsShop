import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AddArticleModuleComponent } from './components/add-article-module/add-article-module.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddpromotionModuleComponent } from './components/addpromotion-module/addpromotion-module.component';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from '../http.service';
import { SearchClientComponent } from './components/search-client/search-client.component';


@NgModule({
  declarations: [AddArticleModuleComponent, AddpromotionModuleComponent, SearchClientComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AdminRoutingModule,
    AutocompleteLibModule,
    HttpClientModule
  ],
  exports: [
    AddArticleModuleComponent,
    AddpromotionModuleComponent
  ],
  providers: [
    HttpService
  ],
  bootstrap: [
    AddArticleModuleComponent,
    AddpromotionModuleComponent
  ]
})
export class AdminModule { }
