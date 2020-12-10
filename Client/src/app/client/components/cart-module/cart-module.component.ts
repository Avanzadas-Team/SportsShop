import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-module',
  templateUrl: './cart-module.component.html',
  styleUrls: ['./cart-module.component.scss']
})
export class CartModuleComponent implements OnInit {

  constructor(private service : HttpService) { }

  cart;
  id;
  info;

  ngOnInit(): void {
    
    this.id = localStorage.getItem("id");
    this.service.getCart(this.id).subscribe(res =>{
      this.cart = res
    });
    console.log(this.id);
  }

  createPurchase(){
    this.info = {
      articles: this.cart,
      userId: this.id
    }
    console.log(this.info);
    this.service.createBought(this.info).subscribe(res => {
      console.log(res);
    })  
  }

  deleteToCart(prod){
    console.log(prod.prodId)
    this.service.deleteProdToCart(this.id,prod.prodId).subscribe(res => {
      console.log(res);
      this.cart = res;
    });
  }

  updateProd(prod){
    var info = {
      productId: prod.prodId,
      quantity: prod.quantity
    }
    console.log(info);
    this.service.UpdateProdInCart(this.id,info).subscribe(res => {
      console.log(res);
    })
  }

}
