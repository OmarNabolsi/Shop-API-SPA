import { AdminService } from './../../_services/admin.service';
import { Product } from './../../models/Product';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class AdminProductsComponent implements OnInit {
  prods: Product[] = [];

  constructor(private adminService: AdminService
    , private router: Router
    ) {}

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.adminService.getProducts().subscribe(
      result => {
        this.prods = result.products;
      },
      err => {
        console.log(err);
      }
    );
  }
  deleteProduct(id) {
    this.adminService
      .deleteProduct(id)
      .subscribe(result => {
        this.getProducts();
      }, err => console.log(err));
  }
}
