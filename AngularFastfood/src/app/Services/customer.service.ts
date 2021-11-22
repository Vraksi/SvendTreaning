import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Login, ClassLogin } from '../Models/Login'

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private loginUrl = 'api/orders';
  login: Login 

  constructor(
    private http: HttpClient
  ) { }
}
