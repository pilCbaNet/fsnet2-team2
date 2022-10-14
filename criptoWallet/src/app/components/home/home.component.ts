import { Component, OnInit } from '@angular/core';
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

  constructor() { }

  ngOnInit(): void {
  }

}
