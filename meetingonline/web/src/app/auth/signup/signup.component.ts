import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { CustomValidationService } from 'src/app/@core/services/custom-validation.service';
import { AppSettings, GetRoute, Route } from 'src/app/@core/utils/app-constants';
import { NavigationGuard } from 'src/app/@core/services/navigation.guard';

@Component({
  selector: 'vip-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  entity: any;
  urlRoute = AppSettings;
  constructor(
    private fb: FormBuilder,
    private api: ApiService,
    private customValidator: CustomValidationService,
    private navigator: NavigationGuard
  ) {

  }
  route(route: Route) {
    return GetRoute(route);
  }
  ngOnInit(): void {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      displayName: ['', [
        Validators.required,
        Validators.maxLength(120),
        Validators.minLength(3)],
        this.customValidator.userNameValidator.bind(this.customValidator)],
      readOfServiceCheck: [false, Validators.requiredTrue],
    },
      {
        validator: this.customValidator.MatchPassword('password', 'confirmPassword'),
      }
    );

  }
  get f() {
    return this.form.controls;
  }

  register(form) {
    this.submitted = true;
    if (!this.form.valid) {
      return;
    }
    const url = 'auth/sign-up';
    const body = {
      displayName: form.value.displayName,
      email: form.value.email
    };
    this.api.post(url, body)
      .subscribe(() => {
        this.navigator.navigate(AppSettings.SUCCESS, { extras: { queryParams: { stype: 'signup' } } });
      });
  }
}
