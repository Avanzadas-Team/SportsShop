import { PurchaseModuleComponent } from './components/purchase-module/purchase-module.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterModuleComponent } from './components/register-module/register-module.component';
import { CartModuleComponent } from './components/cart-module/cart-module.component';

const routes: Routes = [
  {path : 'register', component : RegisterModuleComponent},
  {path : 'createPurchase', component : PurchaseModuleComponent},
  {path : 'completePurchase', component : CartModuleComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
