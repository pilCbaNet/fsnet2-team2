import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cuenta } from 'src/app/Models/ICuenta.mode.';
import { CuentaActiva } from 'src/app/Models/ICuentaActivs.model';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { CuentaService } from 'src/app/services/cuenta.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  usuario!: Usuario; 
  depositForm!:FormGroup;
  sendForm!:FormGroup;
  cuenta:CuentaActiva={
    monto: 0,
    idCliente:0,
    numero_de_cuenta: 0,
    alias:"",
    cbu:0,
    idCuenta:0,
    estado:true,
    transacciones:[]
  }

  constructor(private fb:FormBuilder, private cuentaService:CuentaService) {
    this.depositForm = this.fb.group({
      monto:['',[Validators.required, Validators.min(1)]],
      cuenta:['',[Validators.required, Validators.minLength(9)]]
    })
    this.sendForm = this.fb.group({
      monto:['',[Validators.required, Validators.min(1)]],
      cuenta:['',[Validators.required, Validators.minLength(9)]]
    })
   }

  ngOnInit(): void {
    this.cuenta = this.cuentaService.cuentaUsuarioActivo[0];
    console.log(this.cuenta)

  }

  depositar():void{
    if (this.cuenta.numero_de_cuenta == this.depositForm.get('cuenta')?.value){
       this.cuenta.monto+=this.depositForm.get('monto')?.value
    document.getElementById('depositClose')?.click();
    
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
  }

  enviarDinero():void{
    if (this.cuenta.numero_de_cuenta == this.sendForm.get('cuenta')?.value){
      this.cuenta.monto-=this.sendForm.get('monto')?.value
   document.getElementById('sendClose')?.click();

   }
   else {
     alert("La cuenta ingresada es incorrecta!")
   }
  }

}
