import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vip-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  submitted = false;
  constructor() { }

  ngOnInit(): void {
  }
  resetPass() {

  }
}
