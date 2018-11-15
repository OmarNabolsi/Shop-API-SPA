import { Product } from './../models/Product';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { CartItem } from '../models/CartItem';

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

  addCartItem(cartId, productId) {
    return this.http.post(this.baseUrl + 'shop/cart/' + cartId, { productId: productId });
  }

  removeCartItem(cartItemId) {
    return this.http.delete(this.baseUrl + 'shop/cartItem/' + cartItemId);
  }

  getCartItems(userId) {
    return this.http.get(this.baseUrl + 'shop/cart/' + userId).pipe(
      map((data: any) => {
        const cartItems: CartItem[] = [];
        for (const item of data.cartItems) {
          const cItem: CartItem = {
            id: item.id,
            quantity: item.quantity,
            cartId: item.cartId,
            productId: item.productId
          };
          cartItems.push(cItem);
        }
        return cartItems;
      }),
      map(cartItems => {
        for (const item of cartItems) {
          this.http.get(this.baseUrl + 'shop/product/' + item.productId)
            .subscribe((productData: any) => {
              item.product = {
                id: productData.id,
                title: productData.title,
                imageUrl: productData.imageUrl,
                price: productData.price,
                description: productData.description,
                userId: productData.userId
              };
            }, err => console.log(err));
        }
        return cartItems;
      })
    );
  }

  postOrder(cart) {
    return this.http.post(this.baseUrl + 'shop/order', cart);
  }
}
