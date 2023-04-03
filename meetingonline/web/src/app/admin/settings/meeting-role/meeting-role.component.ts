import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { GetRoute, AppSettings, Route } from 'src/app/@core/utils/app-constants';
import { MeetingRole } from 'src/app/@core/models/meeting-role.model';
import { ApiService } from 'src/app/@core/services/api.service';
import { MeetingType } from 'src/app/@core/models/meeting.model';
import { localizeEnum } from 'src/app/@core/utils/utils';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';

@Component({
  selector: 'vip-meeting-role',
  templateUrl: './meeting-role.component.html',
  styleUrls: ['./meeting-role.component.scss']
})
export class MeetingRoleComponent implements OnInit {
  routeConfig: any = AppSettings;
  meetingTypes: any[];
  roles: MeetingRole[];
  meetingType: MeetingType = MeetingType.GeneralMeeting;

  constructor(
    private localizer: TranslateService,
    private router: Router,
    private notifier: NotificationService,
    private confirm: ConfirmationDialogService,
    private api: ApiService) {

    localizeEnum(MeetingType, 'enum.MeetingType', this.localizer)
      .subscribe(x => {
        this.meetingTypes = x;
      });
  }

  ngOnInit(): void {
    this.loadData(this.meetingType);
  }

  addRole() {
    this.router.navigate([GetRoute(AppSettings.MEETING_ROLE_EDIT)]);
  }

  edditRole(id: string) {
    this.router.navigate([GetRoute(AppSettings.MEETING_ROLE_EDIT)], { queryParams: { id } });
  }

  lockRole(role: MeetingRole, isLock: boolean) {
    this.api.patchToReturn<MeetingRole>(`meetingrole/${role.id}/lock/${isLock}`, null)
      .subscribe(result => {
        if (result != null) {
          role.isDisabled = isLock;
        }
      });
  }

  delete(role: MeetingRole) {
    this.confirm.confirm('meetingRole.delete.confirm')
      .then(async () => {
        const result = await this.api.deleteToReturn<boolean>(`meetingrole/${role.id}`).toPromise();

        if (result) {
          const idx = this.roles.findIndex(r => r.id === role.id);
          this.roles.splice(idx, 1);
          this.notifier.success('meetingRole.delete.success', 'meetingRole.delete.title', true);
        } else {
          this.notifier.error('meetingRole.delete.error');
        }
      });
  }

  loadData(type: MeetingType) {
    this.api.getObject<MeetingRole[]>(`meetingrole/${MeetingType[type]}/true`)
      .subscribe(result => {
        this.roles = result;
      });
  }

  route(route: Route): string {
    return GetRoute(route);
  }
}
