import { Component } from '@angular/core';
import { MeetingAccess } from 'src/app/@core/models/meeting.model';
import { LoggedInUser, User } from 'src/app/@core/models/user.model';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { MeetingRole } from 'src/app/@core/models/meeting-role.model';
import { NbDialogService } from '@nebular/theme';
import { MemberDialogComponent } from './member-dialog/member-dialog.component';
import { Observable, of, } from 'rxjs';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { map, takeUntil } from 'rxjs/operators';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { Occurrence } from 'src/app/@core/models/common';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { MeetingBaseComponent } from '../shares/meeting-base.component';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';

@Component({
  selector: 'vip-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent
  extends MeetingBaseComponent {

  filteredUser$: Observable<User[]>;
  currentUser: LoggedInUser;
  members: User[];
  roles: MeetingRole[];
  rolesForm: FormGroup;
  showroles = 'none';
  thisRoleSelect = false;
  constructor(
    appState: AppStateProvider,
    meetingInfo: MeetingInfoService,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private userInfo: UserInfoService,
    private fb: FormBuilder,
    private notifier: NotificationService,
    private dialogService: NbDialogService
  ) {
    super(appState, meetingInfo);

    this.currentUser = this.userInfo.user;
  }
  protected onMeetingLoaded() {
    this.loadData();
  }

  private loadData() {
    this.mt.openedDate = (this.mt?.openedDate as Occurrence)?.value;

    if (this.mt) {
      this.api.getObject<User[]>(`user/member-access/${this.mt?.id}`)
        .pipe(
          map(r => {
            this.members = r;
            this.filteredUser$ = of(r);
          })
        ).subscribe();

      this.api.getObject<MeetingRole[]>(`meetingrole/${this.mt?.type}/false`)
        .subscribe(result => {
          this.roles = result;
          this.rolesForm = this.fb.group({
            userId: [null],
            roles: this.fb.array(this.roles.map(x => this.fb.control(false)))
          });
        });
    }
  }

  buildRoleNames(meetingAccess: MeetingAccess): string {
    const roleName = this.roles
      ?.filter(r => meetingAccess?.meetingRoles?.includes(r.id))
      ?.map<string>(x => x.name);
    return roleName?.join('|');
  }

  openAddMemberDialog() {
    const dlgRef = this.dialogService.open(MemberDialogComponent, {
      context: {
        mt: this.mt,
        roles: this.roles,
        members: this.members
      }
    });

    dlgRef.componentRef.instance.memberAdded$
      .pipe(
        takeUntil(dlgRef.onClose),
        map((m: User) => {
          const idx = this.members.findIndex(x => x.id === m.id);
          if (idx !== -1) {
            this.members[idx] = m;
          } else {
            this.members.push(m);
          }
          this.filteredUser$ = of(this.members);
        })
      )
      .subscribe();
  }

  onChangeList(value: string) {
    this.filteredUser$ = of(this.members.filter(x => x.userName.toLowerCase().includes(value?.toLowerCase())));
  }

  delMember(id: string) {
    this.confirm.confirm('member.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `user/${id}/meeting-access/${this.mt?.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              const i = this.members.findIndex(x => x.id === id);
              this.members.splice(i, 1);
              this.filteredUser$ = of(this.members);
              this.notifier.success('member.delete.success', 'member.delete.title', true);
            }
          });
        }
      })
      .catch((e) => console.log(e));

  }

  lockMember(id: string, isLocked?: boolean) {
    const url = `user/${id}/meeting-access/${this.mt?.id}/lock/${isLocked}`;
    this.api.patchToReturn<boolean>(url, null).subscribe(rs => {
      const member = this.members.find(x => x.id === id);
      member.meetingAccesses?.filter(x => x.meetingId === this.mt?.id)
        .forEach(x => x.isLocked = isLocked && rs);
      this.filteredUser$ = of(this.members);

      if (isLocked) {
        this.notifier.warning(`member.lock.success`, `member.lock.title`, true);
      } else {
        this.notifier.success(`member.unlock.success`, `member.unlock.title`, true);
      }
    });
  }

  showRolePopover(member: User) {
    const values = this.roles.map(x => member.meetingAccesses[0].meetingRoles?.includes(x.id));

    this.rolesForm.controls.roles.reset();
    this.rolesForm.controls.userId.setValue(member.id);
    this.rolesForm.controls.roles.setValue(values);
  }

  updateSelectedMemberRoles() {
    const url = `user/${this.rolesForm.controls.userId.value}/meeting-access/${this.mt?.id}`;
    const roleIds: string[] = [];
    this.rolesForm.controls.roles.value.forEach((val, idx) => {
      if (val) {
        roleIds.push(this.roles[idx].id);
      }
    });

    if (roleIds.length === 0) {
      this.delMember(this.rolesForm.controls.userId.value);
      return;
    }

    this.api.putToReturn<boolean>(url, { meetingRoles: roleIds }).subscribe(rs => {
      if (rs) {
        const member = this.members.find(x => x.id === this.rolesForm.controls.userId.value);
        member.meetingAccesses[0].meetingRoles = roleIds;
        this.filteredUser$ = of(this.members);
        this.notifier.success('member.grantAccess.success', 'member.grantAccess.title', true);
      }
    });
  }
}
