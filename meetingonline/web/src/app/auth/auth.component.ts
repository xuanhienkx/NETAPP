
import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'vip-auth',
  styleUrls: ['./auth.component.scss'],
  templateUrl: './auth.component.html'
})
export class AuthComponent {

  // showcase of how to use the onAuthenticationChange method
  constructor(private location: Location) {
  }

  back() {
    this.location.back();
    return false;
  }

}
