import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoggedUser } from '../Models/ILoggedUser.model';
import { Usuario } from '../Models/IUsuario.model';

@Injectable({
  providedIn: 'root'
})


export class UsuarioService {

  url:string = environment.url;
  usuarioLogeado!:Usuario;

  constructor(private http:HttpClient) { }

  crearUsuario(usuario:Usuario):Observable<any>{
    return this.http.post<any>("https://localhost:7155/api/Clientes", usuario);
  }

  getUsuarios():Observable<Usuario[]>{
    return this.http.get<Usuario[]>("https://localhost:7155/api/Clientes");
  }

  getUsuariobyId(id:number):Observable<any>{
    return this.http.get("https://localhost:7155/api/Clientes/"+id);
  }

  getUsuariobyEmail(body:LoggedUser):Observable<any>{
    return this.http.post<any>("https://localhost:7155/api/Clientes/Login",body);
  }

  updateUsuario(id:number, usuario:Usuario):Observable<any>{
    return this.http.put("https://localhost:7155/api/Clientes/"+id, usuario);
  }

  deleteUsuario(id:number):Observable<any>{
    return this.http.delete("https://localhost:7155/api/Clientes/"+id);
  }

}
