import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Router, Params } from '@angular/router';
import { LoggedInUser } from 'src/app/@core/models/user.model';
import { UserRole } from 'src/app/@core/utils/auth-constant';
import { UserInfoService } from './user-info.service';
import { NavigationGuard } from './navigation.guard';
import { AppSettings } from '../utils/app-constants';
import { MessageExtras } from '../models/common';
import { SocialUser } from 'angularx-social-login';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {
  constructor(
    private api: ApiService,
    private router: Router,
    private navigator: NavigationGuard,
    private userInfo: UserInfoService,
  ) { }

  oAuthSingIn(socialUser: SocialUser, params: Params) {
    const url = 'auth/oauth-sign-in';
    this.logIn(url, socialUser, params);
  }

  singIn(userName: string, password: string, params: Params) {
    const url = 'auth/sign-in';
    const body = { userName, password };
    this.logIn(url, body, params);
  }

  private logIn(url: string, body: any, params: Params) {
    this.api.postToReturn<LoggedInUser>(url, body).subscribe(u => {
      if (u) {
        this.userInfo.user = u;

        const returnUrl = params?.returnUrl;
        if (returnUrl) {
          this.router.navigate([returnUrl], { queryParams: { id: params?.id } });
        } else {
          if (this.userInfo.user.role === UserRole[UserRole.USER]) {
            window.location.href = window.location.origin;
          } else {
            this.navigator.navigate(AppSettings.ADMIN, { extras: { queryParams: params } });
          }
        }
      }
    });
  }

  async verify(body: any) {
    const url = 'auth/verify';
    return await this.api.putToReturn<boolean>(url, body).toPromise();
  }

  async resetPassword(body: any) {
    const url = 'auth/reset-password';
    const result = await this.api.putToReturn<boolean>(url, body).toPromise();

    if (result) {
      this.navigator.navigate(AppSettings.SIGNIN);
    }
    return result;
  }

  async forgot(email: string) {
    const url = 'auth/reset-passcode/' + email;
    const result = await this.api.getObject<boolean>(url).toPromise();

    if (result) {
      this.navigator.navigate(AppSettings.SUCCESS, { extras: { queryParams: { stype: 'forgot' } } });
    }
    return result;
  }

  // After clearing localStorage redirect to login screen
  async logout(extras?: MessageExtras) {
    console.log('>>>>>>>>>>LOG OUT<<<<<<<<<<<<<', extras);

    const rs = await this.api.deleteToReturn<boolean>('auth/sign-out').toPromise()
      .catch(() => {
        console.log('Logout error');
      });
    this.userInfo.user = null;
    this.navigator.navigate(AppSettings.SIGNIN, extras);
  }
}
