import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Auth/auth.service';
import { LoggedUser } from 'src/app/Models/ILoggedUser.model';
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
  usuarioLogeado!:Usuario

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
    let loggedUser:LoggedUser = {
      email:this.loginForm.get('email')?.value,
      password:this.loginForm.get('password')?.value
    }
    this.usuarioService.getUsuariobyEmail(loggedUser).subscribe((data) =>{
      if(data){
        this.usuarioLogeado = data;
        this.token = this.usuarioLogeado.nombre+"."+this.usuarioLogeado.apellido
        sessionStorage.setItem('token', JSON.stringify(this.token))
        this.route.navigate(['/home']);
      }
      else{
        alert("Invalid email or password");
      }
    })
  }
}
