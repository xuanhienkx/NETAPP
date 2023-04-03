import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomValidationService } from 'src/app/@core/services/custom-validation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenService } from 'src/app/@core/services/authen.service';
import { AppSettings, GetRoute, Route } from 'src/app/@core/utils/app-constants';

@Component({
  selector: 'vip-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  frm: FormGroup;
  submitted = false;
  urlRoute = AppSettings;
  model: any;
  constructor(
    private routeAtive: ActivatedRoute,
    private fb: FormBuilder,
    private auth: AuthenService,
    private router: Router,
    private customValidator: CustomValidationService) {
    this.frm = this.fb.group({
      password: ['', Validators.compose([Validators.required, this.customValidator.patternValidator()])],
      confirmPassword: ['', [Validators.required]]
    },
      {
        validator: this.customValidator.MatchPassword('password', 'confirmPassword'),
      }
    );
  }
  
  route(route: Route) {
    return GetRoute(route);
  }
  get f() {
    return this.frm.controls;
  }

  ngOnInit(): void {
    this.routeAtive.queryParamMap.subscribe(queryParams => {
      this.model = {
        userId: queryParams.get('userId'),
        token: queryParams.get('token')
      };
    });
    if (!this.model.userId || !this.model.token) {
      this.router.navigate([GetRoute(AppSettings.ERROR)]);
    }
  }

  resetPass(form) {
    this.submitted = true;
    this.model.password = form.value.password;
    console.log(this.model);
    this.auth.resetPassword(this.model);

  }
}
