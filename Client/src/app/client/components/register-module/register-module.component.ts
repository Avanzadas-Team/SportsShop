import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-module',
  templateUrl: './register-module.component.html',
  styleUrls: ['./register-module.component.scss']
})
export class RegisterModuleComponent implements OnInit {

  constructor() { }

  name :string;

  birthdate : Date;

  sexuality : string;

  uname : string;

  pass : string;

  lname : string;

  info;


  ngOnInit(): void {
  }

  onUnameChange(){
    console.log("Revisando nombre de usuario");
  }

  register(){
  this.info = {nombre: this.name, apellido: this.lname, nombreUsuario: this.uname, contrasena: this.pass, birthdate: this.birthdate, sexo: this.sexuality}
    console.log(this.info);
  }

}
