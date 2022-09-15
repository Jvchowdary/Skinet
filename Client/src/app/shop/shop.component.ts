import { Component, OnInit } from '@angular/core';
import { Iproduct } from '../Models/product';
import { ShopService } from './shop.service';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products:Iproduct[];

  constructor(private shpService: ShopService) { }

  ngOnInit()  {
      this.shpService.getProducts().subscribe(res=>{
          this.products=res.data;
      },err=>{
        console.log(err);
      });
  }

}
