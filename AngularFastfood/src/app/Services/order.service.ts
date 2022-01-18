import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Order, ClassOrder } from '../Models/Order'

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orderUrl = 'api/orders';
  order: Order

  constructor(
    private http: HttpClient
  ) { }

  httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  GetOrder(): Observable<Order> {
    const url = `${this.orderUrl}`;
    return this.http.get<Order>(url, this.httpOptionsJson)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
      )
  }
}
