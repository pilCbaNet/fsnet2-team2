import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Auth/auth.service';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!:FormGroup;
  token!:any;
  listaUsuarios:Usuario[]=[]

  constructor(private fb:FormBuilder, private authService:AuthService, private route:Router, private usuarioService:UsuarioService) {
    this.loginForm = this.fb.group({
      email:['',[Validators.required,Validators.email, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,3}$')]],
      password:['',[Validators.required]]
    }) 
   }

  ngOnInit(): void {
    this.usuarioService.getUsuarios().subscribe((data)=>this.listaUsuarios = data);
  }


  login():void{
    let usuarioLogeado = this.listaUsuarios.find(user => user.email == this.loginForm.value.email && user.terms == true);
    if (!usuarioLogeado){
      alert("El mail ingresado no corresponde a un usuario activo")
    }
    else if(usuarioLogeado?.password == this.loginForm.value.password){
      this.token = usuarioLogeado?.email
      this.usuarioService.usuarioLogeado=usuarioLogeado;
      sessionStorage.setItem('token', JSON.stringify(this.token));
      this.route.navigate(['/home']);       
      this.loginForm.reset()
    }
    else{
      alert("La contraseña ingresada es incorrecta")
    }
  }

  

}
