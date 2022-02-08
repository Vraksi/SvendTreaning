import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Login, ClassLogin } from '../Models/Login'
import { Header } from './SharedHeader';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl = 'api/Register/';
  login: Login;

  constructor(
    private http: HttpClient,
    private headerOptions: Header
  ) { }

  httpOptions = {
    // withCredentials is needed to send the cookie, because it is be default set to false.
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }), withCredentials: true
  }

  ToLogOut(){
    const url = `${this.loginUrl}LogOut`;
    return this.http.get(url, this.headerOptions.generalHttpOptions)
      .pipe(
        tap(res => {
          console.log('You logged out')   
      }))
  }

  CheckIfLoggedOut(): Observable<boolean>{
    const url = `${this.loginUrl}CheckLogin`; 
    return this.http.get<boolean>(url, this.headerOptions.generalHttpOptions)
      .pipe(
        tap(res => console.log('HTTP Response from server', res))
      )
  }

  // Det er en post request for ikke at sende password i url'en
  ToLogin(email: string, password: string): Observable<Login> {
    let login = new ClassLogin();
    login.email = email;
    login.password = password;
    const url = `${this.loginUrl}login`;
    return this.http.post<Login>(url, login, this.headerOptions.generalHttpOptions)
      .pipe(
        tap(res => console.log('HTTP response:', res))
      )
  }
  
  // TODO skal laves om sådan at den ikke sender informationen igennem url'en
  ToRegister(email: string, password: string, verifyPassword: string): Observable<Login> {
    const url = `${this.loginUrl}VerifyPassword/?email=${email}&password=${password}`;
    return this.http.get<Login>(url, this.httpOptions)
      .pipe(
        tap(res => console.log('HTTP response:', res)),
      )

  }
}

export interface isLoggedIn{
  isLoggedIn: boolean;
}
