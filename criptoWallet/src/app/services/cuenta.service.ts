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

  createCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.post<Cuenta>(this.url, cuenta);
  }

  getUCuenta(id:number):Observable<Cuenta>{
    return this.http.get<Cuenta>(this.url+id);
  }

  updateCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.put<Cuenta>(this.url+cuenta.id, cuenta)
  }

  deleteCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.delete<Cuenta>(this.url+cuenta.id)
  }
}
