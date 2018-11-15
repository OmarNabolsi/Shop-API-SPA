import { ShopService } from './../../_services/shop.service';
import { CartItem } from './../../models/CartItem';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = [];

  constructor(private shopService: ShopService) {}

  ngOnInit() {
    this.getCartItems();
  }

  getCartItems() {
    this.shopService.getCartItems('1').subscribe(cartItems => {
      this.cartItems = cartItems;
    }, err => console.log(err));
  }

  removeCartItem(id) {
    this.shopService.removeCartItem(id).subscribe(result => {
      this.getCartItems();
    }, err => console.log(err));
  }

  orderNow() {
    const cart = {
      userId: '1',
      cartItems: this.cartItems
    };
    this.shopService.postOrder(cart).subscribe(order => {
      this.getCartItems();
      console.log(order);
    }, err => console.log(err));
  }
}
