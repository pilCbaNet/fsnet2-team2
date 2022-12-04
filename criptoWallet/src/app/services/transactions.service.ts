import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {

  url:string = 'http://localhost:3000/movimientos/';

  constructor(private http:HttpClient) { }

  getTrasactions():Observable<any>{
    return this.http.get(this.url)
  }

}
