import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!:FormGroup;
  token!:any;

  constructor(private fb:FormBuilder, private authService:AuthService, private route:Router ) {
    this.loginForm = this.fb.group({
      email:new FormControl('',[Validators.required, Validators.email]),
      password: new FormControl('',[Validators.required])
    })
    
   }
  ngOnInit(): void {
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
