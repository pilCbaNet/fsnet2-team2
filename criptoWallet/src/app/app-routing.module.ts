import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { TransactionComponent } from './components/transaction/transaction.component';

const routes: Routes = [
  { path:'', component:LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'login', component:LoginComponent},
  { path: 'registration', component:RegistrationComponent},
  { path: 'transactions', component: TransactionComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
