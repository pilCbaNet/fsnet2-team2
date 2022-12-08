import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cuenta } from '../Models/ICuenta.mode.';
import { CuentaActiva } from '../Models/ICuentaActivs.model';

@Injectable({
  providedIn: 'root'
})

export class CuentaService {

  cuentaUsuarioActivo!:CuentaActiva[];
  url = environment.url
  cuentaUrl:string = 'https://localhost:7155/api/Cuentas';

  constructor(private http:HttpClient) { }

  createCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.post<Cuenta>("https://localhost:7155/api/Cuentas", cuenta);
  }

  getUCuenta(id:number):Observable<Cuenta>{
    return this.http.get<Cuenta>("https://localhost:7155/api/Cuentas/"+id);
  }

  updateCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.put<Cuenta>("https://localhost:7155/api/Cuentas/"+cuenta.numeroDeCuenta, cuenta)
  }

  deleteCuenta(cuenta:Cuenta):Observable<Cuenta>{
    return this.http.delete<Cuenta>("https://localhost:7155/api/Cuentas/"+cuenta.id)
  }
}
