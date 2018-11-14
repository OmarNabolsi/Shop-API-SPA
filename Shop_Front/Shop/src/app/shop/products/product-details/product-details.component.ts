import { ShopService } from './../../../_services/shop.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from './../../../models/Product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;

  constructor(
    private route: ActivatedRoute,
    private shopService: ShopService
  ) {}

  ngOnInit() {
    this.product = new Product();
    const paramId = this.route.snapshot.params['id'];
    this.shopService.getProductById(paramId).subscribe(
      product => {
        this.product = product;
      },
      err => console.log(err)
    );
  }
}
