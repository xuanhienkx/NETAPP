import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenService } from 'src/app/@core/services/authen.service';
import { AppSettings, GetRoute, Route } from 'src/app/@core/utils/app-constants';

@Component({
  selector: 'vip-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  submitted = false;
  frm: FormGroup;
  urlRoute = AppSettings;
  constructor(private fb: FormBuilder, private auth: AuthenService) { }

  route(route: Route) {
    return GetRoute(route);
  }
  get f() {
    return this.frm.controls;
  }
  ngOnInit(): void {
    this.frm = this.fb.group({
      email: ['', [Validators.required]]
    });
  }
  requestPass(form) {
    this.auth.forgot(form.value.email);
  }
}
