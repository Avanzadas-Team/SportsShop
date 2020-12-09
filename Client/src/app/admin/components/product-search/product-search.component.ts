import { ProductInfo } from './../../Models/ProductInfo';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscriber } from 'rxjs';
import { HttpService } from 'src/app/http.service';
import { Products } from '../../Models/Products';

@Component({
  selector: 'app-product-search',
  templateUrl: './product-search.component.html',
  styleUrls: ['./product-search.component.scss']
})
export class ProductSearchComponent implements OnInit {
  constructor(private http: HttpService, private formBuilder: FormBuilder) {
    this.searchForm = this.formBuilder.group({
      text: ['', Validators.required],
    })
  }

  prods$;
  productInfo: ProductInfo;
  isClicked: boolean;

  prodSelected: Products;
  searchForm: FormGroup;
  keyword = 'nameAndBrand';

  ngOnInit(): void {
    this.isClicked = false;
    this.prods$ = this.GetAllProducts();
  }

  GetAllProducts(): Observable<any[]> {
    return this.http.GetProdsToSearch();
  }

  async GetProdInfo(id: string) {
    var request = ((await this.http.GetProductInfo(id)).subscribe(data => {
      this.productInfo = data;
    }));
    return request;
  }
  async BtnClick() {
    this.isClicked = true;
    this.productInfo = (await this.GetProdInfo(this.prodSelected.id));
  }
}
