import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url:string = 'http://localhost:3000/posts/';

  constructor(private http:HttpClient) { }

  login(email:string, password:string){
    
    let body={
      email:email,
      password:password
    }

    return this.http.post('https://reqres.in/api/login', body);
  }

}
