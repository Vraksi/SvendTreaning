import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

//
@Injectable({
    // declares that this service should be created
    // by the root application injector.
    providedIn: 'root',
})
export class Header{
    httpOptions = {
        // withCredentials is needed to send the cookie, because it is be default set to false.
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }), withCredentials: true
      }

};