import { HttpService } from 'src/app/http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-module',
  templateUrl: './login-module.component.html',
  styleUrls: ['./login-module.component.scss']
})
export class LoginModuleComponent implements OnInit {

  constructor(private http : HttpService) { }

  username : string;

  password : string;

  info;

  tipoU = "0";


  ngOnInit(): void {
    this.tipoU = localStorage.getItem("tipoU");
  }

  login(){
    this.http.login({username: this.username, password: this.password}).subscribe(r => {
      this.info = r;
      if(this.info != null){
        localStorage.setItem("role",this.info.role);
        localStorage.setItem("id", this.info.id);
        this.tipoU = localStorage.getItem("role");
        location.reload();
        console.log(this.tipoU);
      }
    });
    
  }

}
