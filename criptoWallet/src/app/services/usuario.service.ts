import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Usuario } from '../Models/IUsuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  url:string = environment.url;
  clienteUrl:string = "Clientes/";
  usuarioLogeado?:Usuario;

  constructor(private http:HttpClient) { }

  crearUsuario(usuario:Usuario):Observable<any>{
    return this.http.post(this.url, usuario);
  }

  getUsuarios():Observable<Usuario[]>{
    return this.http.get<Usuario[]>("https://localhost:7155/api/Clientes");
  }

  getUsuariobyId(id:number):Observable<any>{
    return this.http.get(this.url+id);
  }

  getUsuariobyEmail(email:string):Observable<Usuario>{
    return this.http.post<Usuario>("https://localhost:7155/api/Clientes/GetByEmail",email);
  }

  updateUsuario(id:number, usuario:Usuario):Observable<any>{
    return this.http.put(this.url+id, usuario);
  }

  deleteUsuario(id:number):Observable<any>{
    return this.http.delete(this.url+id);
  }

}
