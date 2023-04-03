import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vip-intro',
  templateUrl: './intro.component.html',
  styleUrls: ['./intro.component.scss']
})
export class IntroComponent implements OnInit {
  public height: number;
  ngOnInit(): void {
    this.height = window.innerHeight - document.getElementById('header').clientHeight;
  }
}
