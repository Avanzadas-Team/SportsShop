import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

  constructor() { }

  role;

  ngOnInit(): void {
    this.role = localStorage.getItem("role");
  }

  logout(){
    location.reload();
    location.replace("/");
    localStorage.setItem("role","-1");
    localStorage.setItem("id","");
  }

}
