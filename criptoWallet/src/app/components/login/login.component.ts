import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoggedUser } from 'src/app/Models/ILoggedUser.model';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { UsuarioActivo } from 'src/app/Models/IUsuarioActivo.model';
import { CuentaService } from 'src/app/services/cuenta.service';
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
  usuarioActivo!:UsuarioActivo

  constructor(private fb:FormBuilder, private cuentaService:CuentaService ,private route:Router, private usuarioService:UsuarioService) {
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
        this.usuarioActivo = data;
        this.cuentaService.cuentaUsuarioActivo = this.usuarioActivo.cuentasBancaria
        this.token = this.usuarioActivo.nombre+"."+this.usuarioActivo.apellido
        sessionStorage.setItem('token', JSON.stringify(this.token))
        this.route.navigate(['/home']);
      }
      else{
        alert("Invalid email or password");
      }
    })
  }
}
