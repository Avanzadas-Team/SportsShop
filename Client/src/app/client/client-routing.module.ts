import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterModuleComponent } from './components/register-module/register-module.component';

const routes: Routes = [
  {path : 'register', component : RegisterModuleComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
