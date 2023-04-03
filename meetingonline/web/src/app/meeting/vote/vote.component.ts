import { Component } from '@angular/core';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { Attendee, ElectionMatter } from 'src/app/@core/models/meeting.model';
import { MeetingBaseComponent } from '../shares/meeting-base.component';

@Component({
  selector: 'vip-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent extends MeetingBaseComponent {

  attendee: Attendee;
  items: ElectionMatter[];
  constructor(
    appState: AppStateProvider,
    meetingInfo: MeetingInfoService,
    private api: ApiService,
  ) {
    super(appState, meetingInfo);

  }

  protected onMeetingLoaded() {
    Promise.resolve(this.loadAttendee())
      .then(() => { this.items = this.mt?.electionMatters ?? []; })
      .finally(() => setTimeout(() => {

        this.appState.accountSummary$.next(this.attendee);
      }, 100));

  }

  private loadAttendee() {
    this.api.getObject<Attendee>(`meeting/${this.mt?.id}/current-attendee`)
      .subscribe(r => {
        this.attendee = r;
      });
  }
}
