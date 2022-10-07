import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!:FormGroup;

  constructor(private fb:FormBuilder ) {
    this.loginForm = this.fb.group({
      email:new FormControl('',[Validators.required, Validators.email]),
      password: new FormControl('',[Validators.required])
    })
    
   }
  ngOnInit(): void {
  }

  
  login()
  {
    return console.log(this.loginForm.value);
    //todo navegar al inicio si la clave es correcta
  }

}
