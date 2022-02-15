import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
  providedIn: 'root'
})
export class CookieHelperService {
  decode: string;  
  constructor(private cookie: CookieService) { }

  //for at sætte bearertoken
  SetBearertoken(bearerToken: string)
  {
    this.cookie.set("doom", bearerToken);
  }

  //for at kunne få fat i den token der ligger gemt i cookies
  GetBearertoken() {
    var existing: any = this.cookie.get("doom");

    if (existing == null)
    {
      console.log("No bearerToken");
      
      return existing;
    }
    else
    {
      //console.log(`returned with token ${existing}`);
      
      return existing;
    }
  } 
}
