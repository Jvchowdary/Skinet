import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../Models/Pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl:any="https://localhost:5001/api"
  constructor(private http:HttpClient) { }

  getProducts()
  {
    return this.http.get<IPagination>(this.baseUrl+'products');
  }

  getProductsId(id:number)
  {
    return this.http.get(this.baseUrl+'products'+id);
  }
}
