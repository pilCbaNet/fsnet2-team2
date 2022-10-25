import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  token:string | null = null;

  constructor() { }

  ngOnInit(): void {
    this.token = sessionStorage.getItem('token')
    console.log(this.token);
  }

  logout(){
    sessionStorage.removeItem('token')
    
  }

}
