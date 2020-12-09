import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  private devURL: string = "https://localhost:44383/";
  private prodURL: string = "https://mymovierest.azurewebsites.net/"
  private dummyURL = "https://jsonplaceholder.typicode.com/users";
  postResponse: string;
  putResponse: string;


  GetAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.devURL + "adminquery/users");
  }

  GetUserHistory(id: string) {
    return this.http.get(this.devURL + "adminquery/history/" + id);
  }

  register(info) {
    return this.http.post("https://localhost:44383/admin/users/username", info);
  }

  postArticle(info) {
    return this.http.post("https://localhost:44383/admin/product", info);
  }

  postImage(id, image) {
    return this.http.post("https://localhost:44383/admin/productimages/" + id, image);
  }

  getProducts() {
    return this.http.get("https://localhost:44383/adminquery/products/");
  }

  postPromotion(info) {
    return this.http.post("https://localhost:44383/admin/promotion", info);
  }

  AddToCart(info, id) {
    console.log(info);
    return this.http.post("https://localhost:44383/admin/cart/" + id, info);
  }

  getCart(id) {
    return this.http.get("https://localhost:44383/admin/cart/" + id);
  }

  deleteProdToCart(id, idProd) {
    return this.http.delete("https://localhost:44383/admin/cart/" + id + "/" + idProd);
  }

  UpdateProdInCart(id, prod) {
    return this.http.put("https://localhost:44383/admin/cart/" + id, prod);
  }

  createBought(info) {
    return this.http.put("https://localhost:44383/client/bought", info);
  }
}
