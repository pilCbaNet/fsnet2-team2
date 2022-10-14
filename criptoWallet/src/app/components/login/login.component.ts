import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Auth/auth.service';
import usuarioMock from 'src/app/Mocks/usuario.mock';
import { Usuario } from 'src/app/Models/IUsuario.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!:FormGroup;
  token!:any;

  usuarioPrueba!:Usuario

  constructor(private fb:FormBuilder, private authService:AuthService, private route:Router ) {
    this.loginForm = this.fb.group({
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required]]
    })
    
   }
  ngOnInit(): void {
    this.usuarioPrueba = usuarioMock;
    console.log(this.usuarioPrueba);
  }

  // "email": "eve.holt@reqres.in",
  // "password": "cityslicka"

  
  login():void{
    this.authService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe((data)=>{
      this.token=data;
      sessionStorage.setItem('token', JSON.stringify(this.token));
      this.route.navigate(['/home']);       
      this.loginForm.reset()
    })
  }

}
