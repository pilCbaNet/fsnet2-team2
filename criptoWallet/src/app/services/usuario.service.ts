import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../Models/IUsuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  url:string = 'http://localhost:3000/posts/';

  usuarioLogeado?:Usuario;

  constructor(private http:HttpClient) { }

  crearUsuario(usuario:Usuario):Observable<any>{
    return this.http.post(this.url, usuario);
  }

  getUsuarios():Observable<Usuario[]>{
    return this.http.get<Usuario[]>(this.url);
  }

  getUsuariobyId(id:number):Observable<any>{
    return this.http.get(this.url+id);
  }

  getUsuariobyEmail(email:string):Observable<any>{
    return this.http.get(this.url+"?email="+email);
  }

  updateUsuario(id:number, usuario:Usuario):Observable<any>{
    return this.http.put(this.url+id, usuario);
  }

  deleteUsuario(id:number):Observable<any>{
    return this.http.delete(this.url+id);
  }

}
