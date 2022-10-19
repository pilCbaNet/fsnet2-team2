import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cuenta } from '../Models/ICuenta.mode.';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  url:string = 'http://localhost:3000/cuenta/';

  constructor(private http:HttpClient) { }

  crearCuenta(cuenta:Cuenta):Observable<any>{
    return this.http.post(this.url, cuenta);
  }

  getUCuenta(id:number):Observable<any>{
    return this.http.get(this.url+id);
  }

  updateCuenta(id:number, cuenta:Cuenta):Observable<any>{
    return this.http.put(this.url+id, cuenta)
  }

}
