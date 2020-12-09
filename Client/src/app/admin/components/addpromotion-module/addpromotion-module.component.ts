import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addpromotion-module',
  templateUrl: './addpromotion-module.component.html',
  styleUrls: ['./addpromotion-module.component.scss']
})
export class AddpromotionModuleComponent implements OnInit {

  constructor(private service: HttpService) { }

  pname: string;

  description: string;

  productName: string;

  productId: string;

  dog: string;

  initDate: Date;

  finishDate: Date;

  discount: number = 0;

  gvdescription: string = "";

  products;

  dogSelected : boolean;

  info;

  ngOnInit(): void {
    this.service.getProducts().subscribe(res => {
      this.products = res;
    });
  }

  dogChange(){
    if(this.dog=="Promotion"){
      this.dogSelected=true;
    }else{
      this.dogSelected = false;
    }
  }

  getName(){
    for(var x = 0; x < this.products.length; x++){
      if(this.products[x].id == this.productId){
        this.productName = this.products[x].name;
      }
    }
  }

  addPromotion(){
    this.info = {
      name: this.pname,
      descripcion: this.description,
      nombreDelProd: this.productName,
      idProd: this.productId,
      Discount: this.dogSelected,
      Percentage: this.discount,
      Descrip: this.gvdescription,
      FechaIn: this.initDate,
      FechaFin: this.finishDate 
    }
    console.log(this.info);  
    this.service.postPromotion(this.info).subscribe(res => {
      console.log(res);
    });
  }

}
