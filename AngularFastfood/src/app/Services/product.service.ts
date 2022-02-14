import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Login, ClassLogin } from '../Models/Login';
import { Product } from '../Models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productURL = 'api/products';
  products: Product

  constructor(
    private http: HttpClient
  ) { }

  httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }), withCredentials: true
  }

  GetProducts(): Observable<Product[]>{
    const url = `${this.productURL}`;
    return this.http.get<Product[]>(url, this.httpOptionsJson)
     .pipe(
       tap(res => console.log('HTTP res: ', res))
     )
  }
}
