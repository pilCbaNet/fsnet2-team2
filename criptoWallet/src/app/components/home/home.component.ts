import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cuenta } from 'src/app/Models/ICuenta.mode.';
import { Usuario } from 'src/app/Models/IUsuario.model';
import { CuentaService } from 'src/app/services/cuenta.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //TODO TRAER ESTOS DATOS DEL BACKEND
  usuario!: Usuario; 
  depositForm!:FormGroup;
  sendForm!:FormGroup;
  cuenta:Cuenta={
    saldo: 0,
    numeroDeCuenta: "",
    id: 0
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
    this.cuentaService.getUCuenta(1).subscribe({
      next:(data)=>{
        this.cuenta=data;
      },
      error:(error)=>console.log(error)
      
    })

    
  }

  depositar():void{
    if (this.cuenta.numeroDeCuenta == this.depositForm.get('cuenta')?.value){
       this.cuenta.saldo+=this.depositForm.get('monto')?.value
    document.getElementById('depositClose')?.click();
    this.cuentaService.updateCuenta(this.cuenta.id, this.cuenta).subscribe()
    }
    else {
      alert("La cuenta ingresada es incorrecta!")
    }
   
  }

  enviarDinero():void{
    if (this.cuenta.numeroDeCuenta == this.sendForm.get('cuenta')?.value){
      this.cuenta.saldo-=this.sendForm.get('monto')?.value
   document.getElementById('sendClose')?.click();
   this.cuentaService.updateCuenta(this.cuenta.id, this.cuenta).subscribe()
   }
   else {
     alert("La cuenta ingresada es incorrecta!")
   }
  }

}
