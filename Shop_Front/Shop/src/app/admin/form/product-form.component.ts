import { Product } from './../../models/Product';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  product: Product;
  prodId: string;
  @Input() path: string;

  constructor(private route: ActivatedRoute
    , private router: Router
    , private adminService: AdminService) {}

  ngOnInit() {
    this.product = new Product();
    if (this.path === 'edit') {
      this.prodId = this.route.snapshot.params['id'];
      this.adminService.getProduct(this.prodId).subscribe(prod => {
        this.product = prod;
      }, err => {
        console.log(err);
      });
    }
  }

  saveProduct() {
    if (this.path === 'edit') {
      this.adminService.putProduct(this.product).subscribe(result => {
        this.router.navigate(['admin-products']);
      }, err => {
        console.log(err);
      });
    } else {
      const prod = {
        title: this.product.title,
        imageUrl: this.product.imageUrl,
        price: this.product.price,
        description: this.product.description,
        userId: '1'
      };
      this.adminService.postProduct(prod).subscribe(result => {
        this.router.navigate(['admin-products']);
      }, err => console.log(err));
    }
  }
}
