import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { RegisterModuleComponent } from './components/register-module/register-module.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PurchaseModuleComponent } from './components/purchase-module/purchase-module.component';
import { CartModuleComponent } from './components/cart-module/cart-module.component';


@NgModule({
  declarations: [RegisterModuleComponent, PurchaseModuleComponent, CartModuleComponent],
  imports: [
    CommonModule,
    ClientRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports : [
    RegisterModuleComponent,
    PurchaseModuleComponent
  ],
  providers : [
  ],
  bootstrap: [
    RegisterModuleComponent,
    PurchaseModuleComponent
  ]
})
export class ClientModule {  }
