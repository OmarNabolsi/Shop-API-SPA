import { ProductDetailsComponent } from './shop/products/product-details/product-details.component';
import { CartComponent } from './shop/cart/cart.component';
import { ProductListComponent } from './shop/products/product-list/product-list.component';
import { AddProductComponent } from './admin/add-product/add-product.component';
import { ShopComponent } from './shop/shop/shop.component';
import { NavComponent } from './navigation/nav.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AdminProductsComponent } from './admin/products/products.component';
import { EditProductComponent } from './admin/edit-product/edit-product.component';
import { FormsModule } from '@angular/forms';
import { ProductFormComponent } from './admin/form/product-form.component';
import { OrdersComponent } from './shop/orders/orders.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AdminProductsComponent,
    EditProductComponent,
    AddProductComponent,
    ProductFormComponent,
    ShopComponent,
    ProductListComponent,
    ProductDetailsComponent,
    CartComponent,
    OrdersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
