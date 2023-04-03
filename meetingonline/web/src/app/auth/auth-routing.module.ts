import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './auth.component';
import { SignInComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { SuccessPageComponent } from './success-page/success-page.component';
import { VerifyComponent } from './verify/verify.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AppSettings } from '../@core/utils/app-constants';

export const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      {
        path: '', redirectTo: AppSettings.SIGNIN.Path, pathMatch: 'full'
      },
      {
        path: AppSettings.SIGNIN.Path, component: SignInComponent,
      },
      {
        path: AppSettings.SIGNUP.Path, component: SignupComponent,
      },
      {
        path: AppSettings.SUCCESS.Path, component: SuccessPageComponent,
      },
      {
        path: AppSettings.VERIFY.Path, component: VerifyComponent,
      },
      {
        path: AppSettings.FORGOT.Path, component: ForgotPasswordComponent,
      },
      {
        path: AppSettings.RESETPASSWORD.Path, component: ResetPasswordComponent,
      },  {
        path: AppSettings.CHANGEPASSWORD.Path, component: ChangePasswordComponent,
      }
    ],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
