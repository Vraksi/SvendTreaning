import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Login, ClassLogin } from '../Models/Login'

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl = 'api/Register/';
  login: Login 

  constructor(
    private http: HttpClient
  ) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }), withCredentials: true
  }

  ToLogin(email: string, password: string): Observable<Login> {
    let login = new ClassLogin();
    login.email = email;
    login.password = password;
    const url = `${this.loginUrl}login`;
    return this.http.post<Login>(url, login, this.httpOptions)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
      )
  }
  
  ToRegister(email: string, password: string, verifyPassword: string): Observable<Login> {
    const url = `${this.loginUrl}VerifyPassword/?email=${email}&password=${password}`;
    return this.http.get<Login>(url, this.httpOptions)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
    
      )

  }


}
