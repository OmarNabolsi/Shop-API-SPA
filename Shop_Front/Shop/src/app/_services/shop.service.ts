import { Product } from './../models/Product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get(this.baseUrl + 'shop/products').pipe(
      map((data: any[]) => {
        const products: Product[] = [];
        for (const item of data) {
          const product: Product = {
            id: item.id,
            title: item.title,
            price: item.price,
            imageUrl: item.imageUrl,
            description: item.description,
            userId: item.userId
          };
          products.push(product);
        }
        return products;
      })
    );
  }

  getProductById(id) {
    return this.http.get(this.baseUrl + 'shop/product/' + id).pipe(
      map((data: any) => {
        const product: Product = {
          id: data.id,
          title: data.title,
          imageUrl: data.imageUrl,
          price: data.price,
          description: data.description,
          userId: data.userId
        };
        return product;
      })
    );
  }
}
