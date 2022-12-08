import { Component, OnInit } from '@angular/core';
import { Movimientos } from 'src/app/Models/IMovimientos';
import { TransactionsService } from 'src/app/services/transactions.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  movimientos:Movimientos[]=[]

  constructor(private transactionService:TransactionsService) { }

  ngOnInit(): void {

  }

}
