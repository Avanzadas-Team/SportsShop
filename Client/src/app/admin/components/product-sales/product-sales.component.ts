import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-product-sales',
  templateUrl: './product-sales.component.html',
  styleUrls: ['./product-sales.component.scss']
})
export class ProductSalesComponent implements OnInit {

  constructor(private http: HttpService) { }

  prods$: any;

  ngOnInit(): void {
    this.GetProducts();
  }

  GetProducts(): void {
    this.http.GetProdAq().subscribe(data => {
      this.prods$ = data;
    });
  }

}
