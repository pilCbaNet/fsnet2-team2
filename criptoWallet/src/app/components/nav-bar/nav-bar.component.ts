import { Component, DoCheck, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit, DoCheck{

  token:any;

  constructor() {}

  ngDoCheck(): void {
    this.token = sessionStorage.getItem('token');
  }

  ngOnInit(): void {
    
  }

  logout(){
    sessionStorage.removeItem('token')
  }

}
