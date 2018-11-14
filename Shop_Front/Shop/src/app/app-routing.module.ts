import { ProductDetailsComponent } from './shop/products/product-details/product-details.component';
import { ProductListComponent } from './shop/products/product-list/product-list.component';
import { ShopComponent } from './shop/shop/shop.component';
import { EditProductComponent } from './admin/edit-product/edit-product.component';
import { AdminProductsComponent } from './admin/products/products.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddProductComponent } from './admin/add-product/add-product.component';
import { CartComponent } from './shop/cart/cart.component';
import { OrdersComponent } from './shop/orders/orders.component';

const routes: Routes = [
  {path: 'admin-products/edit/:id', component: EditProductComponent},
  {path: 'admin-add-products', component: AddProductComponent},
  {path: 'admin-products', component: AdminProductsComponent},
  {path: 'shop', component: ShopComponent},
  {path: 'shop-products/details/:id', component: ProductDetailsComponent},
  {path: 'shop-products', component: ProductListComponent},
  {path: 'shop-cart', component: CartComponent},
  {path: 'shop-orders', component: OrdersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

