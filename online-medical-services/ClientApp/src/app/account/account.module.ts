import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountComponent } from '../account/account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { Route, RouterModule } from '@angular/router';


export const appRoutes: Route[] = [
  {
    path:'login',
    component:LoginComponent,
    data:{title:"Login to account"}
  },
  {
    path:'register',
    component:RegisterComponent,
    data:{title:"Register account"}
  },
  {
    path:'forgot-password',
    component:ForgotPasswordComponent,
    data:{title:"Forgot password"}
  },
  {
    path:':id/reset',
    component:ResetPasswordComponent,
    data:{title:"Reset Password"}
  }
]

@NgModule({
  declarations: [
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(appRoutes),
  ]
})
export class AccountModule { }
