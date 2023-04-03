import { Component, OnDestroy, Input } from '@angular/core';
import { MeetingSummary } from 'src/app/@core/models/meeting.model';
import { takeWhile } from 'rxjs/operators';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingSummaryType } from '../meeting.types';

@Component({
  selector: 'vip-meeting-summary',
  templateUrl: './meeting-summary.component.html',
  styleUrls: ['./meeting-summary.component.scss']
})
export class MeetingSummaryComponent implements OnDestroy {
  @Input() type: MeetingSummaryType;
  private destroy = false;

  summary: MeetingSummary = { shares: 0, votes: 0, holders: 0, checkIn: 0, attendConfirmed: 0, checkInVotes: 0 };
  constructor(private appState: AppStateProvider) {
    const self = this;
    this.appState.meetingSummary$.pipe(takeWhile(() => !this.destroy))
      .subscribe(summary => {
        if (summary) {
          self.summary = summary;
        } else {
          self.summary = { shares: 0, votes: 0, holders: 0, checkIn: 0, attendConfirmed: 0, checkInVotes: 0 };
        }
      });
  }

  ngOnDestroy(): void {
    this.destroy = true;
  }
}
