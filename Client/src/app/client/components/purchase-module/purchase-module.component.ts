import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-module',
  templateUrl: './purchase-module.component.html',
  styleUrls: ['./purchase-module.component.scss']
})
export class PurchaseModuleComponent implements OnInit {

  constructor(private service : HttpService) { }

  products;
  product;
  quantity = 0;
  info;
  id;

  ngOnInit(): void {
    this.id = localStorage.getItem("id");
    this.service.getProducts().subscribe(res => {
      this.products = res;
    });
  }

  addToCart(product){
    this.product = {
      productId: product.id,
      quantity: this.quantity
    }
    console.log(this.product);
    this.service.AddToCart(this.product, this.id).subscribe(res => {
      console.log(res);
    });
  }
}
