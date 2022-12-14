import { Component, DoCheck, OnInit } from '@angular/core';
import { MovimientosGet } from 'src/app/Models/IMovimientoGet.model';
import { CuentaActiva } from 'src/app/Models/ICuentaActivs.model';
import { CuentaService } from 'src/app/services/cuenta.service';
import { TransactionsService } from 'src/app/services/transactions.service';


@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit, DoCheck{

  cuentaActiva!:CuentaActiva;
  movimientos:MovimientosGet[]=[];
  listaDeMovimentos:MovimientosGet[]=[];

  constructor(private transactionService:TransactionsService, private cuenta:CuentaService ) {

  }
  ngDoCheck(): void {
    this.movimientos = this.listaDeMovimentos.filter(mov => mov.idCuenta == this.cuentaActiva.idCuenta);
  }

  ngOnInit(): void {
      this.transactionService.getTrasactions().subscribe((data)=>this.listaDeMovimentos=data)
      this.cuentaActiva = this.cuenta.cuentaUsuarioActivo[0];
  }

}
