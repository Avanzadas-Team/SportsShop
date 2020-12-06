import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addpromotion-module',
  templateUrl: './addpromotion-module.component.html',
  styleUrls: ['./addpromotion-module.component.scss']
})
export class AddpromotionModuleComponent implements OnInit {

  constructor() { }

  pname: string;

  description: string;

  productName: string;

  productId: string;

  dog: string;

  initDate: Date;

  finishDate: Date;

  info;

  ngOnInit(): void {
    //get productos
  }

  addPromotion(){
    this.info = {
      Nombre: this.pname,
      Descripcion: this.description,
      NombreDelProd: this.productName,
      idProd: this.productId,
      FechaIn: this.initDate,
      FechaFin: this.finishDate 
    }
    console.log(this.info);  
  }

}
