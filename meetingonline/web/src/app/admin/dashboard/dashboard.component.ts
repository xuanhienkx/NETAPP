import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vip-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  message: string;

  private ping$: Subscription;
  constructor() {
  }

  ngOnDestroy(): void {
    if (this.ping$) {
      this.ping$.unsubscribe();
    }
  }

  ngOnInit(): void {

    // const self = this;

    // this.message$ = {
    //   next: (msg) => {
    //     self.message = self.message + '<br/>' + msg;
    //     console.log(this.message);
    //   },
    //   error: (err) => this.message = this.message + '</br>' + err,
    //   complete: () => this.message = 'COMPLETED: ' + this.message
    // };

    // this.message = 'Hello!<br/> Let do it!';
    // this.ping$ = this.hub.subscribePing(this.message$);
  }

  update(msg?: string) {
    this.message = this.message + '<br/>' + msg;
  }
}
