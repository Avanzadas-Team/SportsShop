import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { RegisterModuleComponent } from './components/register-module/register-module.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [RegisterModuleComponent],
  imports: [
    CommonModule,
    ClientRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports : [
    RegisterModuleComponent
  ],
  providers : [
  ],
  bootstrap: [
    RegisterModuleComponent
  ]
})
export class ClientModule {  }
