import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Usuario } from 'src/app/Models/IUsuario.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //TODO TRAER ESTOS DATOS DEL BACKEND
  usuario!: Usuario; 
  saldo!: number;
  depositForm!:FormGroup;
  sendForm!:FormGroup;

  constructor(private fb:FormBuilder) {
    this.depositForm = this.fb.group({
      monto:['',[Validators.required, Validators.min(1)]],
      cuenta:['',[Validators.required, Validators.minLength(12)]]
    })
    this.sendForm = this.fb.group({
      monto:['',[Validators.required, Validators.min(1)]],
      cuenta:['',[Validators.required, Validators.minLength(12)]]
    })
   }

  ngOnInit(): void {
  }

  depositar():void{
    //todo generar el deposito
    console.log(this.depositForm.value);
  }

  enviarDinero():void{
    //todo generar el envio
    console.log(this.sendForm.value);
  }

}
