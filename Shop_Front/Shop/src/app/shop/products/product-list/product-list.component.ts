import { ShopService } from '../../../_services/shop.service';
import { Product } from '../../../models/Product';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private shopService: ShopService,
    private router: Router) {}

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts().subscribe(
      products => {
        this.products = products;
      },
      err => console.log(err)
    );
  }

  addToCart(id) {
    this.shopService.addCartItem('1', id).subscribe(result => {
      // this.router.navigate(['shop-products']);
      alert('Product is added to the cart.');
    }, err => console.log(err));
  }
}
