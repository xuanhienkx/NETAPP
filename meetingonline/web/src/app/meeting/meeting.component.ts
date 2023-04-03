import { Component, OnInit, OnDestroy } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { NavigationGuard } from '../@core/services/navigation.guard';
import { TranslateService } from '@ngx-translate/core';
import { AppSettings, GetMenu } from '../@core/utils/app-constants';
import { Subscription } from 'rxjs';
import { MeetingInfoService } from '../@core/services/meeting-info.service';
import { AppStateProvider } from '../@core/services/app-state.provider';
import { AuthenService } from '../@core/services/authen.service';
import { isNullOrUndefined } from 'util';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../@core/services/api.service';
import { Meeting } from '../@core/models/meeting.model';

@Component({
  selector: 'vip-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.scss']
})
export class MeetingManageComponent implements OnInit, OnDestroy {
  private logout$: Subscription;

  menu: NbMenuItem[] = [];

  constructor(
    private navigator: NavigationGuard,
    private localizer: TranslateService,
    private meetingInfo: MeetingInfoService,
    private appState: AppStateProvider,
    private authService: AuthenService,
    private route: ActivatedRoute,
    private api: ApiService
  ) {
    Promise.resolve(this.loadMeetingInfo())
      .finally(() => {
        setTimeout(() => {
          this.loadMenu();
        }, 300);
      });

  }

  loadMenu() {
    this.menu = GetMenu('meeting', [
      AppSettings.MEETING_LIST,
      AppSettings.MEETING_INFO,
      AppSettings.MEETING_MEMBER,
      AppSettings.MEETING_DOCUMENT,
      AppSettings.MEETING_MATTER,
      AppSettings.MEETING_HOLDER,
      AppSettings.MEETING_ATTENDEE,
      AppSettings.MEETING_DELEGATE,
      AppSettings.MEETING_DELEGATE_INFO,
      AppSettings.MEETING_VOTE,
      AppSettings.MEETING_VOTE_RESULT
    ], this.localizer, this.navigator);

  }

  ngOnDestroy(): void {
    this.logout$?.unsubscribe();
    this.meetingInfo.meeting = null;
  }

  ngOnInit(): void {
    const self = this;
    this.logout$ = this.appState.logout$.subscribe({
      next: (msg) => {
        self.authService.logout({
          message: msg?.message,
          extras: {
            queryParams: {
              returnUrl: window.location.pathname,
              id: self.meetingInfo.meeting?.id,
              params: msg?.extras?.queryParams?.params
            }
          }
        });
      }
    });
  }

  private loadMeetingInfo() {
    if (isNullOrUndefined(this.meetingInfo.meeting)) {
      // load from db
      const param = this.route.queryParams.subscribe(
        params => {
          if (params?.id) {
            this.api.getObject<Meeting>(`meeting/${params.id}`).subscribe(
              mt => {
                if (mt) {

                  this.meetingInfo.meeting = mt;
                } else {
                  this.gotoMeetingList();
                }
              });
          } else {
            this.gotoMeetingList();
          }
        });

      // only subcribe once
      param.unsubscribe();
    } else {
      this.appState.meeting$.next(this.meetingInfo.meeting);
    }
  }

  private gotoMeetingList() {
    this.navigator.navigate(AppSettings.MEETING_SETTING, {
      message: {
        msg: 'errors.meetingNotFound', title: 'Common.commonErrorTitle'
      }
    });
  }
}
