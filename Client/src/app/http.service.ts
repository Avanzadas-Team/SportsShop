import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  private devURL: string = "http://localhost:44383/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"
  postResponse: string;
  putResponse: string;

  register(info){
    return this.http.post("https://localhost:44383/admin/users/username",info);
  }

  postArticle(info){
    return this.http.post("https://localhost:44383/admin/product",info);
  }

  postImage(id, image){
    return this.http.post("https://localhost:44383/admin/productimages/" + id, image);
  }

  getProducts(){
    return this.http.get("https://localhost:44383/admin/products/");
  }

  postPromotion(info){
    return this.http.post("https://localhost:44383/admin/promotion",info)
  }
}
