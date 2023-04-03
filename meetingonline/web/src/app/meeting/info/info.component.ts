import { Component } from '@angular/core';
import { Holder, Attendee, MeetingType } from 'src/app/@core/models/meeting.model';
import { MeetingBaseComponent } from '../shares/meeting-base.component';
import { ApiService } from 'src/app/@core/services/api.service';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { GetRoute, AppSettings } from 'src/app/@core/utils/app-constants';
import { Router } from '@angular/router';
import { isNullOrUndefined } from 'util';
import { TranslateService } from '@ngx-translate/core';
import { localizeEnum } from 'src/app/@core/utils/utils';

@Component({
  selector: 'vip-meeting-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class MeetingInfoComponent extends MeetingBaseComponent {

  roles: string;
  holder: Holder;
  attendee: Attendee;
  availableVotes = 0;
  delegatedVotes = 0;
  poweredVotes = 0;
  meetingTypeName = '';
  isGeneralMeeting = true;
  constructor(
    appState: AppStateProvider,
    meetingInfo: MeetingInfoService,
    private localizer: TranslateService,
    private api: ApiService,
    private notifier: NotificationService,
    private router: Router
  ) {
    super(appState, meetingInfo);
  }

  protected onMeetingLoaded() {
    this.isGeneralMeeting = this.mt.type === MeetingType[MeetingType.GeneralMeeting];
    Promise.resolve(this.loadHoderInfo())
      .then(() => this.loadLocalLize())
      .finally(() => setTimeout(() => {
        this.appState.accountSummary$.next(this.holder);
      }, 100));

  }
  loadLocalLize() {
    localizeEnum(MeetingType, 'enum.MeetingType', this.localizer)
      .subscribe(types => {
        if (types) {
          this.meetingTypeName = types[MeetingType[this.mt.type]].name;
        } else {
          this.meetingTypeName = this.mt.type.toString();
        }
      });
  }

  loadHoderInfo(): void {
    this.api.getObject<Holder>(`meeting/${this.mt?.id}/current-holder`)
      .subscribe(rs => {
        if (rs) {
          this.holder = rs;
          console.log('Info ---onMeetingLoaded==>', this.holder);

          this.poweredVotes = this.holder?.ownedVotes ?? 0 + this.holder?.delegatedVotes ?? 0 - this.holder?.delegatingVotes ?? 0;
          console.log('Info ---poweredVotes==>', this.poweredVotes);
          if (this.mt.isOwner) {
            this.roles = 'Owner';
          } else if (this.mt.userRoles) {
            this.roles = this.mt.userRoles.map(x => x.name).join(' - ');
          } else {
            this.roles = 'info.holder.title';
          }

        }
      });
  }


  get canCheckIn() {
    return this.canCloseMeetingSession && !this.canCheckOut && this.holder?.availableVotes > 0;
  }

  get canCheckOut() {
    return this.canCloseMeetingSession && !isNullOrUndefined(this.holder?.checkedInDate);
  }

  checkIn() {
    this.api.patchToReturn<Attendee>(`meeting/${this.mt?.id}/check-in`)
      .subscribe(r => {
        if (r) {
          this.attendee = r;
          this.holder.checkedInDate = r.checkedInDate ?? { value: new Date() };
          this.holder.availableVotes = 0;
          this.mt.summary.onlineCheckIn += 1;
          this.mt.summary.checkIn += 1;
          this.notifier.success('holder.confirm.success', 'holder.confirm.title', true);
          console.log('checkIn==>', this.holder);

          this.appState.accountSummary$.next(this.holder);

        }
      });
  }

  checkOut() {
    this.api.patchToReturn<Holder>(`meeting/${this.mt?.id}/check-out`)
      .subscribe(r => {
        if (r) {
          console.log('check-out==>', r);
          this.holder = r;
          this.mt.summary.onlineCheckIn -= 1;
          this.mt.summary.checkIn -= 1; 
          this.appState.accountSummary$.next(this.holder);
          this.notifier.success('holder.confirm.success', 'holder.confirm.title', true);
        }
      });
  }


  get canDelegate() {
    return this.canCloseMeetingSession && this.holder && this.holder?.availableVotes > 0;
  }

  delegate() {
    this.router.navigate([GetRoute(AppSettings.MEETING_DELEGATE_INFO)]);
  }
}
