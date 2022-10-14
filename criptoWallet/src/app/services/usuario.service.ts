import { Injectable } from '@angular/core';
import { Usuario } from '../Models/IUsuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  usuario!:Usuario

  constructor() { }

  setUsuario(usuario:Usuario){
    this.usuario = usuario;
  }

  getUsuario(){
    return this.usuario;
  }


}
