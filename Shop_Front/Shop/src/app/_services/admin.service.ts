import { Product } from './../models/Product';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUser() {
    return this.http.get(this.baseUrl + 'admin/users/' + 'omar');
  }

  getProducts() {
    return this.http.get(this.baseUrl + 'admin/users').pipe(map((data: any[]) => {
      const result = {
        user: { id: data[0].id, name: data[0].name, email: data[0].email },
        products: data[0].products
      };
      return result;
    }));
  }

  postProduct(prod: any) {
    return this.http.post(this.baseUrl + 'admin/products', prod);
  }

  getProduct(id) {
    return this.http.get(this.baseUrl + 'admin/products/user/' + id).pipe(
      map((data: any) => {
        const product: Product = {
          id: data.id,
          title: data.title,
          imageUrl: data.imageUrl,
          description: data.description,
          price: data.price,
          userId: data.userId
        };
        return product;
      })
    );
  }

  putProduct(prod: Product) {
    return this.http.put(this.baseUrl + 'admin/products/' + prod.id, prod);
  }

  deleteProduct(id) {
    return this.http.delete(this.baseUrl + 'admin/products/' + id);
  }
}
