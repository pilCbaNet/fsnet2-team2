import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Cuenta } from 'src/app/Models/ICuenta.mode.';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { UsuarioActivo } from 'src/app/Models/IUsuarioActivo.model';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  listaUsuarios: Usuario[] = [];

  regForm:FormGroup;

  constructor(private fb:FormBuilder, private usuarioService:UsuarioService, private route:Router ) {
    this.regForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.minLength(3)]],
      email:['',[Validators.required,Validators.email, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,3}$')]],
      password:['',[Validators.required, Validators.minLength(6)]],
      password2:['',[Validators.required, Validators.minLength(6)]],
      dni:['',[Validators.required, Validators.minLength(8)]],
      address:['',[Validators.required]],
      city:['',[Validators.required]],
      terms:['',[Validators.required]]
    })
   }

  ngOnInit(): void {
  }

  registrarUsuario(){

    if(this.regForm.valid && this.regForm.value.password == this.regForm.value.password2){
      let usuario:UsuarioActivo = {
        idCliente: 0,
        nombre: this.regForm.get('name')?.value,
        apellido: this.regForm.get('lastName')?.value,
        email: this.regForm.get('email')?.value,
        password: this.regForm.get('password')?.value,
        domicilio: this.regForm.get('address')?.value,
        idLocalidad: parseInt(this.regForm.get('city')?.value),
        estado: this.regForm.get('terms')?.value,
        cuentasBancaria: []
      }
      this.usuarioService.crearUsuario(usuario).subscribe(()=>alert("New User has been successfully created!"));
      this.regForm.reset();
      this.route.navigate(['/login']);
    } 
  }
}