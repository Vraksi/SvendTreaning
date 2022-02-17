import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieHelperService } from './cookie-helper.service';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
    constructor(public _cookieHelperService: CookieHelperService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let token = localStorage.getItem("token"); 
        console.log("this is my token from local storage", token)
        const headers = req.headers
            .set('Content-Type', 'application/json')
            //.set('Authorization', `bearer ${token}`)

        console.log(headers)
        const authReq = req.clone({ headers });
        return next.handle(authReq);
    }
}