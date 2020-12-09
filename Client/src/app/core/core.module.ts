import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [HomeComponent, NavMenuComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavMenuComponent,
    HomeComponent
  ]
})
export class CoreModule { }
