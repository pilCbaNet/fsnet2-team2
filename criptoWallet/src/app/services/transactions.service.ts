import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovimientosGet } from '../Models/IMovimientoGet.model';


@Injectable({
  providedIn: 'root'
})
export class TransactionsService {

  url:string = 'https://localhost:7155/api/Transacciones';
  movimientos:MovimientosGet[]=[]

  constructor(private http:HttpClient) { }

  getTrasactions():Observable<MovimientosGet[]>{
    return this.http.get<MovimientosGet[]>(this.url)
  }

}
