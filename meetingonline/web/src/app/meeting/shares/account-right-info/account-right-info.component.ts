import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Holder, Attendee } from 'src/app/@core/models/meeting.model';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { takeWhile } from 'rxjs/operators';

export declare type AccountRightInfoType = 'full' | 'info' | 'vote' | 'admin';

@Component({
  selector: 'vip-account-right-info',
  templateUrl: './account-right-info.component.html',
  styleUrls: ['./account-right-info.component.scss']
})

export class AccountRightInfoComponent implements OnDestroy {
  @Input() type: AccountRightInfoType;
  @Input() hideTitle = false;
  @Input() account?: Holder | Attendee;
  delegatedVotes = 0;
  availableVotes = 0;
  delegatingVotes = 0;
  totalVotes = 0;
  private destroy = false;
  constructor(private appState: AppStateProvider) {
    const self = this;
    if (this.account) {

      this.loadData(this.account);
    } else {
      this.appState.accountSummary$.pipe(takeWhile(() => !this.destroy))
        .subscribe(account => {
          console.log(account);

          if (account) {
            self.loadData(account);
            self.account = account;
          }
        });
    }


  }

  ngOnDestroy(): void {
    this.destroy = true;
  }

  loadData(account: Holder | Attendee) {

    switch (this.type) {
      case 'vote':
      case 'admin':
        const attendee = account as Attendee;
        this.delegatedVotes = attendee?.sharedVotes;
        this.delegatingVotes = attendee?.delegatingVotes;
        this.totalVotes = attendee?.totalVotes;
        break;
      case 'info':
      case 'full':
      default:
        const holder = account as Holder;
        this.delegatedVotes = holder?.delegatedVotes;
        this.availableVotes = holder?.availableVotes;
        this.delegatingVotes = holder?.ownedVotes - holder?.availableVotes;
        this.totalVotes = holder?.delegatedVotes + holder?.availableVotes;
        break;

    }
  }

  get showAvailableVotes() {
    return this.type !== 'vote';
  }

  get showTotalVotes() {
    return this.type !== 'info';
  }

  get showDelegatedVotes() {
    return this.type !== 'info';
  }
}
