import { HttpService } from './../../../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-module',
  templateUrl: './cart-module.component.html',
  styleUrls: ['./cart-module.component.scss']
})
export class CartModuleComponent implements OnInit {
  id = "";
  constructor(private service : HttpService) { }

  cart; 
  ngOnInit(): void {
    this.service.getCart(this.id).subscribe(res =>
      this.cart = res);
  }

}
