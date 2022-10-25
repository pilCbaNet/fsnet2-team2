import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuardGuard } from './Auth/guard.guard';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { QuienesSomosComponent } from './components/quienes-somos/quienes-somos.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { TransactionComponent } from './components/transaction/transaction.component';

const routes: Routes = [
  { path:'', component:LoginComponent},
  { path: 'home', component: HomeComponent, canActivate:[GuardGuard]},
  { path: 'login', component:LoginComponent},
  { path: 'registration', component:RegistrationComponent},
  { path: 'transactions', component: TransactionComponent, canActivate:[GuardGuard]},
  { path: 'quienes-somos', component: QuienesSomosComponent, canActivate:[GuardGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
