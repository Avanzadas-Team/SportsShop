import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  private devURL: string = "https://localhost:44383/";
  private prodURL = "https://avanzadas-proyecto-3-server.azurewebsites.net/";
  postResponse: string;
  putResponse: string;


  GetAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(this.prodURL + "adminquery/users");
  }

  GetUserHistory(id: string) {
    return this.http.get(this.prodURL + "adminquery/history/" + id);
  }

  GetProdAq() {
    return this.http.get<any[]>(this.prodURL + "adminquery/aqproducts");
  }

  GetClientsInCommon(id: string) {
    return this.http.get(this.prodURL + "adminquery/common/" + id);
  }

  GetProdsToSearch() {
    return this.http.get<any[]>(this.prodURL + "adminquery/prods");
  }

  async GetProductInfo(id: string): Promise<any> {
    var request = this.http.get(this.prodURL + "adminquery/product/" + id);
    return request;
  }

  register(info) {
    return this.http.post(this.prodURL + "admin/users/username", info);
  }

  postArticle(info) {
    return this.http.post(this.prodURL + "admin/product", info);
  }

  postImage(id, image) {
    return this.http.post(this.prodURL + "admin/productimages/" + id, image);
  }

  getProducts() {
    return this.http.get(this.prodURL + "adminquery/products/");
  }

  postPromotion(info) {
    return this.http.post(this.prodURL + "admin/promotion", info);
  }

  AddToCart(info, id) {
    console.log(info);
    return this.http.post(this.prodURL + "admin/cart/" + id, info);
  }

  getCart(id) {
    return this.http.get(this.prodURL + "admin/cart/" + id);
  }

  deleteProdToCart(id, idProd) {
    return this.http.delete(this.prodURL + "admin/cart/" + id + "/" + idProd);
  }

  UpdateProdInCart(id, prod) {
    return this.http.put(this.prodURL + "admin/cart/" + id, prod);
  }

  createBought(info) {
    return this.http.put(this.prodURL + "client/bought", info);
  }

  checkUserName(username) {
    return this.http.get(this.prodURL + "admin/username/" + username);
  }

  login(info) {
    return this.http.post(this.prodURL + "admin/login", info);
  }
}
