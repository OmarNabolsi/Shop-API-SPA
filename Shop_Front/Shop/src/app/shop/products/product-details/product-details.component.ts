import { ShopService } from './../../../_services/shop.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from './../../../models/Product';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
  paramId: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shopService: ShopService
  ) {}

  ngOnInit() {
    this.product = new Product();
    this.paramId = this.route.snapshot.params['id'];
    this.shopService.getProductById(this.paramId).subscribe(
      product => {
        this.product = product;
      },
      err => console.log(err)
    );
  }

  addToCart() {
    this.shopService.addCartItem('1', this.paramId).subscribe(result => {
      this.router.navigate(['shop-products']);
    }, err => console.log(err));
  }
}
