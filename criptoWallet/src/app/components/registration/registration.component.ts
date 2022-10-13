import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  regForm:FormGroup;

  constructor(private fb:FormBuilder) {
    this.regForm = this.fb.group({
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required, Validators.minLength(6)]],
      password2:['',[Validators.required, Validators.minLength(6)]],
      address:['',[Validators.required]],
      city:['',[Validators.required]],
      terms:['',[Validators.requiredTrue]]
    })
   }

  ngOnInit(): void {
  }

}
