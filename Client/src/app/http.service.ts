import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  private devURL: string = "https://localhost:44383/";
  private prodURL = "";
  postResponse: string;
  putResponse: string;


  GetAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.devURL + "adminquery/users");
  }

  GetUserHistory(id: string) {
    return this.http.get(this.devURL + "adminquery/history/" + id);
  }

  GetProdAq() {
    return this.http.get<any[]>(this.devURL + "adminquery/aqproducts");
  }

  GetClientsInCommon(id: string) {
    return this.http.get(this.devURL + "adminquery/common/" + id);
  }

  register(info) {
    return this.http.post(this.devURL + "admin/users/username", info);
  }

  postArticle(info) {
    return this.http.post(this.devURL + "admin/product", info);
  }

  postImage(id, image) {
    return this.http.post(this.devURL + "admin/productimages/" + id, image);
  }

  getProducts() {
    return this.http.get(this.devURL + "adminquery/products/");
  }

  postPromotion(info) {
    return this.http.post(this.devURL + "admin/promotion", info);
  }

  AddToCart(info, id) {
    console.log(info);
    return this.http.post(this.devURL + "admin/cart/" + id, info);
  }

  getCart(id) {
    return this.http.get(this.devURL + "admin/cart/" + id);
  }

  deleteProdToCart(id, idProd) {
    return this.http.delete(this.devURL + "admin/cart/" + id + "/" + idProd);
  }

  UpdateProdInCart(id, prod) {
    return this.http.put(this.devURL + "admin/cart/" + id, prod);
  }

  createBought(info) {
    return this.http.put(this.devURL + "client/bought", info);
  }

  checkUserName(username) {
    return this.http.get("https://localhost:44383/admin/username/" + username);
  }
}
