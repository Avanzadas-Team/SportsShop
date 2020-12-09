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
  quantity = 1;
  info;
  id = "5fcd310ead6b16e22cef3ea6";

  ngOnInit(): void {
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
