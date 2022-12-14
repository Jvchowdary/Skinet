import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

const routes:Routes=[
  {path:'shop',component : ShopComponent},
  {path:'shop/:id',component : ProductDetailsComponent},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
    //CommonModule
  ],
  exports:[RouterModule]
})
export class ShopRoutingModule { }
