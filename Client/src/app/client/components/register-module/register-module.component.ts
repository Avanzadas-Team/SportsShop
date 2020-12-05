import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register-module',
  templateUrl: './register-module.component.html',
  styleUrls: ['./register-module.component.scss']
})
export class RegisterModuleComponent implements OnInit {

  constructor(private service : HttpService){}//private http: HttpClient) { }

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
    this.info = {Name: this.name,
                LName: this.lname, 
                Username: this.uname, 
                Password: this.pass, 
                Birthdate: this.birthdate, 
                Sex: this.sexuality,
                Cart: []};
    this.service.register(this.info).subscribe(r => {
      console.log("Respuesta",r);
    });
  }

}
