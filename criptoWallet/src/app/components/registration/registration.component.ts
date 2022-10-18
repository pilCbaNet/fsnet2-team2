import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  //TODO: ESTA LISTA DEBERIA ESTAR EN EL BACKEND
  listaUsuarios: Usuario[] = [];

  regForm:FormGroup;

  constructor(private fb:FormBuilder, private usuarioService:UsuarioService) {
    this.regForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required, Validators.minLength(6)]],
      password2:['',[Validators.required, Validators.minLength(6)]],
      address:['',[Validators.required]],
      city:['',[Validators.required]],
      terms:['',[Validators.required]]
    })
   }

  ngOnInit(): void {
  }

  registrarUsuario(){

    if(this.regForm.valid && this.regForm.value.password == this.regForm.value.password2){
      let usuario:Usuario = {
        nombre: this.regForm.get('name')?.value,
        apellido: this.regForm.get('lastName')?.value,
        email: this.regForm.get('email')?.value,
        password: this.regForm.get('password')?.value,
        address: this.regForm.get('address')?.value,
        city: this.regForm.get('city')?.value,
        terms: this.regForm.get('terms')?.value,
        usuarioRegistrado:{
          email: this.regForm.get('email')?.value,
          password: this.regForm.get('password')?.value
        }
      }
      this.usuarioService.crearUsuario(usuario).subscribe();
      console.log(usuario);
    } 
  }
}