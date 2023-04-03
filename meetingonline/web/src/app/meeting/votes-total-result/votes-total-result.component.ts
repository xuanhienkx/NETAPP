import { Component } from '@angular/core';
import { MeetingBaseComponent } from '../shares/meeting-base.component';
import { ApiService } from 'src/app/@core/services/api.service';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { ElectionMatter, Meeting } from 'src/app/@core/models/meeting.model';

@Component({
  selector: 'vip-votes-total-result',
  templateUrl: './votes-total-result.component.html',
  styleUrls: ['./votes-total-result.component.scss']
})
export class VotesTotalResultComponent
  extends MeetingBaseComponent {

  electionMatters: ElectionMatter[];
  constructor(
    private api: ApiService,
    appState: AppStateProvider,
    meetingInfo: MeetingInfoService,
  ) {
    super(appState, meetingInfo);

  }
  protected onMeetingLoaded() {
    if (this.meetingInfo.meeting) {
      this.api.getObject<Meeting>(`meeting/${this.meetingInfo.meeting?.id}`, false).subscribe(
        mt => {
          if (mt) {
            this.meetingInfo.meeting = mt;
            this.electionMatters = mt?.electionMatters ?? [];
          }
        });
    }
  }
}
