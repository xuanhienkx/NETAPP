import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { FormGroup, Validators, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { GetRoute, AppSettings } from 'src/app/@core/utils/app-constants';
import { MeetingRole } from 'src/app/@core/models/meeting-role.model';
import { MeetingType } from 'src/app/@core/models/meeting.model';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { localizeEnum } from 'src/app/@core/utils/utils';
import { Permission } from 'src/app/@core/utils/auth-constant';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'vip-meeting-role-edit',
  templateUrl: './meeting-role-edit.component.html',
  styleUrls: ['./meeting-role-edit.component.scss']
})
export class MeetingRoleEditComponent implements OnInit {
  meetingTypes: any[];
  permissionsList: any[];
  frm: FormGroup;
  isEdit: boolean;
  submitted = false;
  title: string;
  meetingTypeName: string;

  constructor(
    private localizer: TranslateService,
    private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private notifier: NotificationService,
    private api: ApiService) {

    this.frm = this.fb.group({
      id: [null],
      name: ['', [Validators.required]],
      description: [''],
      isEnable: [true],
      permissions: this.fb.array([]),
      meetingType: [MeetingType.GeneralMeeting],
    });

    forkJoin(
      localizeEnum(MeetingType, 'enum.MeetingType', this.localizer),
      localizeEnum(Permission, 'enum.Permission', this.localizer)
    ).subscribe(([types, perms]) => {
      this.meetingTypes = types;
      this.permissionsList = perms.sort((a, b) => a.name > b.name ? 0 : -1);

      if (this.permissionsList && this.permissionsList.length > 0) {
        this.permissionsList.forEach(p => {
          console.log('permissionsList==>p=', p);

          (this.frm.controls.permissions as FormArray).push(this.fb.control(false));
        });
      }
    });
  }

  ngOnInit(): void {
    this.activeRoute.queryParams.subscribe(params => {
      if (params.id) {
        this.api.getObject<MeetingRole>(`meetingRole/${params.id}`)
          .subscribe(val => {
            this.isEdit = true;
            this.frm.patchValue(val);
            this.frm.controls.isEnable.setValue(!val.isDisabled);
            this.meetingTypeName = this.meetingTypes[MeetingType[val.meetingType]].name;

            if (val && val.permissions) {
              const selectedPerms = this.permissionsList.map(
                p => val.permissions.findIndex(v => Permission[v] === p.value) !== -1 ? true : false);

              this.frm.controls.permissions.setValue(selectedPerms);
            }
          });
      }
    });
  }

  get f() {
    return this.frm.controls;
  }

  onSubmit(isNew?: boolean): void {
    const url = 'meetingrole';
    const role = this.frm.value as MeetingRole;

    role.isDisabled = !this.f.isEnable.value;
    role.permissions = this.frm.value.permissions
      .map((v, i) => (v ? Permission[this.permissionsList[i].value] : null))
      .filter(v => v !== null);

    if (this.isEdit) {
      this.api.putToReturn<MeetingRole>(url, role)
        .subscribe(result => this.handleResult(result, isNew));
    } else {
      this.api.postToReturn<MeetingRole>(url, role)
        .subscribe(result => this.handleResult(result, isNew));
    }
  }

  private handleResult(result: MeetingRole, createNew: boolean) {
    if (result != null) {
      if (this.isEdit) {
        this.notifier.success('meetingRole.edit.success', 'meetingRole.edit.title', true);
      } else {
        this.notifier.success('meetingRole.add.success', 'meetingRole.add.title', true);
      }

      if (createNew && createNew === true) {
        this.frm.reset();
        this.frm.controls.isEnable.setValue(true);
        this.frm.controls.id.setValue('');
        this.isEdit = false;
      } else {
        this.frm.controls.id.setValue(result.id);
        this.meetingTypeName = this.meetingTypes[MeetingType[result.meetingType]].name;
        this.isEdit = true;
      }
    }
  }

  close() {
    this.router.navigate([GetRoute(AppSettings.MEETING_ROLE)]);
  }
}
