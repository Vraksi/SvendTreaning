import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { Status, ClassStatus } from '../Models/Status'

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  private loginUrl = 'api/status';
  status: Status;

  constructor(
    private http: HttpClient
  ) { }

  
}
