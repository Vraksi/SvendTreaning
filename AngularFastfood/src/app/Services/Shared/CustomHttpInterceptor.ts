import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieHelperService } from './cookie-helper.service';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
    constructor(public _cookieHelperService: CookieHelperService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const headers = req.headers
            .set('Content-Type', 'application/json')

            const authReq = req.clone({ headers, withCredentials: true });
        return next.handle(authReq);
    }
}