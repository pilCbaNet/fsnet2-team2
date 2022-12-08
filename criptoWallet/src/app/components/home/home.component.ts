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
  cuentaActiva!:CuentaActiva;


  constructor(private fb:FormBuilder, private cuentaService:CuentaService) {
    this.depositForm = this.fb.group({
      montoDeposito:['',[Validators.required, Validators.min(1)]],
      cuentaDeposito:['',[Validators.required, Validators.minLength(9)]]
    })
    this.sendForm = this.fb.group({
      montoEnvio:['',[Validators.required, Validators.min(1)]],
      cuentaEnvio:['',[Validators.required, Validators.minLength(9)]],
      cuentaReceptor:['',[Validators.required, Validators.minLength(9)]]
    })
   }

  ngOnInit(): void {
    this.cuentaActiva = this.cuentaService.cuentaUsuarioActivo[0]
    console.log(this.cuentaActiva)
  }

  depositar():void{
    if (this.cuentaActiva.numeroDeCuenta == parseInt(this.depositForm.get('cuentaDeposito')?.value)){
      
      this.cuentaActiva.monto+=this.depositForm.get('montoDeposito')?.value;
      document.getElementById('depositClose')?.click();
      let cuentaUpdate:Cuenta = {
        alias:this.cuentaActiva.alias,
        cbu:this.cuentaActiva.cbu,
        estado:this.cuentaActiva.estado,
        id:this.cuentaActiva.idCuenta,
        idCliente:this.cuentaActiva.idCliente,
        monto:this.cuentaActiva.monto,
        numeroDeCuenta:this.cuentaActiva.numeroDeCuenta
      }
      console.log(cuentaUpdate);
      this.cuentaService.updateCuenta(cuentaUpdate).subscribe(()=>alert("Deposit made saccessfully!"));
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
  }

  enviarDinero():void{
    if (this.cuentaActiva.numeroDeCuenta == parseInt(this.sendForm.get('cuentaEnvio')?.value)){
      
      this.cuentaActiva.monto-=this.sendForm.get('montoEnvio')?.value;
      document.getElementById('sendClose')?.click();
      let cuentaUpdate:Cuenta = {
        alias:this.cuentaActiva.alias,
        cbu:this.cuentaActiva.cbu,
        estado:this.cuentaActiva.estado,
        id:this.cuentaActiva.idCuenta,
        idCliente:this.cuentaActiva.idCliente,
        monto:this.cuentaActiva.monto,
        numeroDeCuenta:this.cuentaActiva.numeroDeCuenta
      }
      console.log(cuentaUpdate);
      this.cuentaService.updateCuenta(cuentaUpdate).subscribe(()=>alert("Transfer made saccessfully!"));
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
   }

}
