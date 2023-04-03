import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; 
import { SharedModule } from '../@core/shared.module';
import { AuthComponent } from './auth.component';

import { 
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbIconModule,
  NbInputModule,
  NbLayoutModule,
} from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { AuthBlockComponent } from './auth-block/auth-block.component';
import { SignInComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { SuccessPageComponent } from './success-page/success-page.component';
import { VerifyComponent } from './verify/verify.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
  declarations: [
    AuthComponent,
    SignInComponent,
    SignupComponent,
    AuthBlockComponent,
    SuccessPageComponent,
    VerifyComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    ChangePasswordComponent

  ],
  imports: [
    NbCardModule,
    NbCheckboxModule,
    NbInputModule,
    NbButtonModule,
    FormsModule,
    NbIconModule,
    SharedModule,
    AuthRoutingModule,
    NbLayoutModule,
    ReactiveFormsModule,
    ThemeModule
  ]

})
export class AuthModule { }
