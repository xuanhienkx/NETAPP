import { Component, OnInit } from '@angular/core';
import { Route, GetRoute, AppSettings } from 'src/app/@core/utils/app-constants';
import { Router } from '@angular/router';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { LoggedInUser, MeetingGroup } from 'src/app/@core/models/user.model';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { Result } from 'src/app/@core/models/common';

@Component({
  selector: 'vip-meeting-group',
  templateUrl: './meeting-group.component.html',
  styleUrls: ['./meeting-group.component.scss']
})
export class MeetingGroupComponent implements OnInit {

  public groups: MeetingGroup[];
  urlRoute = AppSettings;
  CurentUser: LoggedInUser;

  constructor(
    private router: Router,
    private userInfo: UserInfoService,
    private notifier: NotificationService,
    private confirm: ConfirmationDialogService,
    private api: ApiService) {

  }

  ngOnInit(): void {
      this.groups = this.userInfo.user.meetingGroups;
      this.CurentUser = this.userInfo.user;
  }

  route(route: Route) {
    return GetRoute(route);
  }

  delete(groupId: string) {
    this.confirm.confirm('meetingGroup.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          this.api.delete(`user/meeting-group/${groupId}`).subscribe((res: Result<boolean>) => {
            if (res.succeeded) {
              const idx = this.groups.findIndex(g => g.id === groupId);
              this.groups.splice(idx, 1);
              this.CurentUser.meetingGroups = this.groups;
              this.userInfo.user = this.CurentUser;
              this.notifier.success('meetingGroup.delete.success', 'meetingGroup.delete.title', true);
            } else {
              this.notifier.error(res.errors);
            }
          });
        }
      })
      .catch((e) => console.log(e));

  }

  addGroup() {
    this.router.navigate([GetRoute(this.urlRoute.MEETING_GROUP_EDIT)]);
  }

}
