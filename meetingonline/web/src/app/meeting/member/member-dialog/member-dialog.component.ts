import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Meeting } from 'src/app/@core/models/meeting.model';
import { ApiService } from 'src/app/@core/services/api.service';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { NbDialogRef, NbDialogService } from '@nebular/theme';
import { User, LoggedInUser } from 'src/app/@core/models/user.model';
import { Observable, of, Subject } from 'rxjs';
import { takeUntil, map, filter } from 'rxjs/operators';
import { isNullOrUndefined } from 'util';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { MeetingRole } from 'src/app/@core/models/meeting-role.model';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { uriEscape } from 'src/app/@core/utils/utils';
import { layerGroup } from 'leaflet';

@Component({
  selector: 'vip-meeting-member-dialog',
  templateUrl: './member-dialog.component.html',
  styleUrls: ['./member-dialog.component.scss']
})
export class MemberDialogComponent implements OnInit, OnDestroy {
  destroy$: Subject<void> = new Subject<void>();
  memberAdded$: Subject<User> = new Subject<User>();
  search$: Subject<string> = new Subject<string>();

  @Input() mt?: Meeting;
  @Input() roles: MeetingRole[];
  @Input() members: User[];

  selectedUser: User;
  selectedRoles: string;
  currentUser: LoggedInUser;
  filteredUser$: Observable<User[]>;

  frm: FormGroup;
  submitted = false;
  isQuering = false;

  constructor(
    private userInfo: UserInfoService,
    private fb: FormBuilder,
    private api: ApiService,
    private dialogService: NbDialogService,
    private notifier: NotificationService,
    protected dialogRef: NbDialogRef<MemberDialogComponent>
  ) {
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
    this.search$?.complete();
  }

  ngOnInit(): void {
    this.currentUser = this.userInfo.user;

    this.frm = this.fb.group({
      id: [null, Validators.required],
      roleId: [[], [Validators.nullValidator, Validators.required]],
      name: [''],
      role: this.fb.array(this.roles.map(r => this.fb.control(false)))
    });

    const self = this;
    this.search$.subscribe(s => {
      if (!isNullOrUndefined(s) && s?.length >= 2) {
        self.isQuering = true;
        const url = `user/search/${uriEscape(s)}/10`;
        self.api.getObject<User[]>(url, false).subscribe(users => {
          self.filteredUser$ = of(users);
          self.isQuering = false;
        });
      }
    });

    this.f.name.valueChanges.pipe(
      takeUntil(this.destroy$),
      filter(() => this.isQuering === false),
      map(s => self.search$.next(s)))
      .subscribe();

    this.f.role.valueChanges.pipe(
      takeUntil(this.destroy$)
    ).subscribe((r: boolean[]) => {
      const rs: MeetingRole[] = [];
      for (let i = 0; i < r.length; i++) {
        if (r[i]) {
          rs.push(this.roles[i]);
        }
      }
      this.f.roleId.setValue(rs.map(x => x.id));
      this.selectedRoles = rs.map(x => x.name).join(' | ');
    });
  }

  get f() {
    return this.frm.controls;
  }

  onClose() {
    this.dialogRef.close();
  }

  onSubmit(isNew?: boolean) {

    if (isNullOrUndefined(this.selectedUser)) {
      this.onMemberSelected(this.f.name.value);
    }

    if (this.frm.invalid || isNullOrUndefined(this.selectedUser) || isNullOrUndefined(this.f.roleId.value)) {
      this.frm.markAllAsTouched();
      return;
    }
    const url = `user/${this.selectedUser.id}/meeting-access/${this.mt.id}`;
    const roleIds = this.f.roleId.value;

    this.api.putToReturn<boolean>(url, { meetingRoles: roleIds }).subscribe(rs => {
      if (rs) {
        this.selectedUser.meetingAccesses = [{
          meetingType: this.mt.type,
          meetingId: this.mt.id,
          meetingRoles: roleIds
        }];
        this.memberAdded$.next(this.selectedUser);

        if (isNew) {
          this.frm.reset({
            id: '',
            roleId: [],
            name: ''
          });
          this.selectedUser = null;
          this.filteredUser$ = of([]);
          this.notifier.success('member.add.success', 'member.add.title', true);
        } else {
          this.notifier.success('member.edit.success', 'member.edit.title', true);
        }
        this.frm.markAsUntouched();
      }
    });
  }

  onMemberSelected(uname: string) {
    if (uname) {
      this.filteredUser$.subscribe(users => {
        this.selectedUser = users?.find(x => x.userName === uname);
        this.isQuering = false;

        if (this.members && this.selectedUser) {
          const roleIds = this.members.find(x => x.userName === uname)?.meetingAccesses[0]?.meetingRoles;
          const rs = this.roles.map(x => roleIds?.includes(x.id) ?? false);

          this.f.id.setValue(this.selectedUser.id);
          this.f.role.setValue(rs);
        } else {
          this.f.id.setValue(null);
        }
      });
    }
  }

  buildRoleNames(userName: string): string {
    let roleNames = '';
    if (this.members) {
      const roleIds = this.members?.find(x => x.userName === userName)
        ?.meetingAccesses[0]?.meetingRoles;
      if (roleIds) {
        roleNames = `(${this.roles.filter(x => roleIds.includes(x.id)).map<string>(x => x.name)?.join(' | ')})`;
      }
    }
    return roleNames;
  }

  createMember() {
    this.dialogService.open(UserDialogComponent);
  }
}
