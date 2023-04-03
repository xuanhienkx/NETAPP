import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { trigger, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'vip-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss'],
  animations: [
    trigger('fade', [
      transition('void => *', [
        style({ opacity: 0 }),
        animate(5000, style({ opacity: 1 }))
      ])
    ])
  ]
})
export class SpinnerComponent {
  isLoading: Subject<boolean> = this.appState.spinner$;
  constructor(private appState: AppStateProvider) {

  }
}
