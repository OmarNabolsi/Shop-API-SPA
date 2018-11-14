import { ShopService } from '../../../_services/shop.service';
import { Product } from '../../../models/Product';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private shopService: ShopService) {}

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
}
