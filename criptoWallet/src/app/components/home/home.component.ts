import { Component, DoCheck, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cuenta } from 'src/app/Models/ICuenta.mode.';
import { CuentaActiva } from 'src/app/Models/ICuentaActivs.model';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { Transacciones } from 'src/app/Models/Transacciones.model';
import { CuentaService } from 'src/app/services/cuenta.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, DoCheck{

  usuario!: Usuario; 
  depositForm!:FormGroup;
  sendForm!:FormGroup;
  createForm!:FormGroup;
  changeForm!:FormGroup;
  cuentaActiva!:CuentaActiva;
  cuentasDeUsuario:CuentaActiva[] = []

  constructor(private fb:FormBuilder, private cuentaService:CuentaService, private usuarioService:UsuarioService) {

    this.depositForm = this.fb.group({
      montoDeposito:['',[Validators.required, Validators.min(1)]],
      cuentaDeposito:['',[Validators.required, Validators.minLength(9)]]
    });

    this.sendForm = this.fb.group({
      montoEnvio:['',[Validators.required, Validators.min(1)]],
      cuentaEnvio:['',[Validators.required, Validators.minLength(9)]],
      cuentaReceptor:['',[Validators.required, Validators.minLength(9)]]
    });

    this.createForm = this.fb.group({
      dni:['',[Validators.required, Validators.minLength(8), Validators.maxLength(9)]],
      alias:['',[Validators.required, Validators.minLength(5)]]
    });

    this.changeForm = this.fb.group({
      accountNumber: ['',[Validators.required, Validators.minLength(9)]]
    })

    this.cuentaActiva = this.cuentaService.cuentaUsuarioActivo[0];
   }

  ngDoCheck(): void {
    
    this.usuario = this.usuarioService.usuarioLogeado
  
  }

  ngOnInit(): void {
    
  }

  depositar():void{
    if (this.cuentaActiva.numeroDeCuenta == parseInt(this.depositForm.get('cuentaDeposito')?.value)){
      
      this.cuentaActiva.monto+=this.depositForm.get('montoDeposito')?.value;
      document.getElementById('depositClose')?.click();
      let cuentaUpdate:Transacciones = {
        alias:this.cuentaActiva.alias,
        cbu:this.cuentaActiva.cbu,
        estado:this.cuentaActiva.estado,
        idCuenta:this.cuentaActiva.idCuenta,
        idCliente:this.cuentaActiva.idCliente,
        monto:this.cuentaActiva.monto,
        numeroDeCuenta:this.cuentaActiva.numeroDeCuenta,
        transaccion:{
        monto: this.cuentaActiva.monto,
        cuentaDestino: "",
        cuentaOrigen: this.cuentaActiva.numeroDeCuenta.toString(),
        idCuenta: this.cuentaActiva.idCuenta,
        idTipoMovimientos: 2,
        }
      };
      this.cuentaService.updateCuenta(cuentaUpdate).subscribe(()=>alert("Deposit made saccessfully!"));
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
  }

  enviarDinero():void{
    if (this.cuentaActiva.numeroDeCuenta == parseInt(this.sendForm.get('cuentaEnvio')?.value)){
      if (this.cuentaActiva.monto <= this.sendForm.get('montoEnvio')?.value) {
        alert("No tienes suficiente dinero en tu cuenta");
      }
      else {
      this.cuentaActiva.monto-=this.sendForm.get('montoEnvio')?.value;
      let cuentaReceptor = this.sendForm.get('cuentaReceptor')?.value
      document.getElementById('sendClose')?.click();
        let cuentaUpdate:Transacciones = {
        alias:this.cuentaActiva.alias,
        cbu:this.cuentaActiva.cbu,
        estado:this.cuentaActiva.estado,
        idCuenta:this.cuentaActiva.idCuenta,
        idCliente:this.cuentaActiva.idCliente,
        monto:this.cuentaActiva.monto,
        numeroDeCuenta:this.cuentaActiva.numeroDeCuenta,
        transaccion:{
        monto: this.cuentaActiva.monto,
        cuentaDestino: cuentaReceptor,
        cuentaOrigen: this.cuentaActiva.numeroDeCuenta.toString(),
        idCuenta: this.cuentaActiva.idCuenta,
        idTipoMovimientos: 2,
        }
      };
      this.cuentaService.updateCuenta(cuentaUpdate).subscribe(()=>alert("Transfer made saccessfully!"));
      }
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
   }

   createAccount(){
    if(this.cuentasDeUsuario.length > 1){
      alert("You Cannot create another account")
    }
    else{
    let numeroDeCuentaNuevo = parseInt(9+this.createForm.get('dni')?.value)+1;
    
    let nuevaCuenta:Cuenta = {
      id: 0,
      idCliente: this.usuario.idCliente,
      numeroDeCuenta: numeroDeCuentaNuevo ,
      monto: 0,
      alias: this.createForm.get('alias')?.value,
      cbu: parseInt(9+this.createForm.get('dni')?.value),
      estado: false
      }
      this.cuentaService.createCuenta(nuevaCuenta).subscribe(()=>alert('Cuenta Creada con exito'))
    }
   }

   getCuentas(){
    this.cuentaService.getCuentabyId(this.usuario).subscribe((data)=>this.cuentasDeUsuario = data);
   }

   changeAccount(){
      this.cuentaService.getCuenta(parseInt(this.changeForm.get('accountNumber')?.value)).subscribe((data)=> this.cuentaActiva =data);
   }

}
