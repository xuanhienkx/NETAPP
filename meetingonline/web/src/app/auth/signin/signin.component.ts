import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenService } from 'src/app/@core/services/authen.service';
import { AppSettings, GetRoute, Route } from 'src/app/@core/utils/app-constants';
import { ActivatedRoute, Params } from '@angular/router';
import { AuthService, SocialUser, GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';

@Component({
  selector: 'vip-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SignInComponent implements OnInit {
  frm: FormGroup;
  submitted = false;
  redirectDelay = 0;
  showMessages: any = {};
  strategy = '';

  urlRoute = AppSettings;
  errors: string[] = [];
  messages: string[] = [];
  user: any = {};
  rememberMe = false;
  params: Params;
  constructor(
    private fb: FormBuilder,
    private authenService: AuthenService,
    private routeActive: ActivatedRoute,
    private socialAuthService: AuthService
  ) {
    this.frm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.routeActive
      .queryParams
      .subscribe(async params => {
        this.params = params;
      });
  }

  get frmcontrol() {
    return this.frm.controls;
  }

  route(route: Route) {
    return GetRoute(route);
  }

  onSubmit() {
    this.authenService.singIn(this.frm.value.userName, this.frm.value.password, this.params);
  }

  socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform === 'facebook') {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    } else if (socialPlatform === 'google') {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }

    this.socialAuthService.signIn(socialPlatformProvider)
      .then((user: SocialUser) => {
        if (user) {
          console.log(socialPlatform + ' sign in data : ', user);
          this.authenService.oAuthSingIn(user, this.params);
        }
      });
  }
}
