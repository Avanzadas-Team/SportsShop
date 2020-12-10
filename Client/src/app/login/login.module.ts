import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { LoginModuleComponent } from './components/login-module/login-module.component';
import { FormsModule } from '@angular/forms';
import { HttpService } from '../http.service';


@NgModule({
  declarations: [LoginModuleComponent],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormsModule
  ],
  exports : [
    LoginModuleComponent
  ],
  providers : [
    HttpService
  ],
  bootstrap: [
    LoginModuleComponent
  ]
})
export class LoginModule { }
