import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Login, ClassLogin } from '../Models/Login'

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl = 'api/orders';
  login: Login 

  constructor(
    private http: HttpClient
  ) { }

  httpOptionsJson = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  ToLogin(email: string, password: string): Observable<Login> {
    const url = `${this.loginUrl}VerifyPassword/?email=${email}&password=${password}`;
    return this.http.get<Login>(url, this.httpOptionsJson)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
      )
  }
  
  ToRegister(email: string, password: string, verifyPassword: string): Observable<Login> {
    const url = `${this.loginUrl}VerifyPassword/?email=${email}&password=${password}`;
    return this.http.get<Login>(url, this.httpOptionsJson)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
    
      )

  }


}
