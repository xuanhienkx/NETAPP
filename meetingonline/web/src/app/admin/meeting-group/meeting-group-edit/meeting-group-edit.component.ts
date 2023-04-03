import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/@core/services/api.service';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { AppSettings, GetRoute } from 'src/app/@core/utils/app-constants';
import { LoggedInUser, MeetingGroup } from 'src/app/@core/models/user.model';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { GetMediaUrl } from 'src/app/@core/utils/utils';
import { Result, Media } from 'src/app/@core/models/common';
import { stringify } from 'querystring';
import { isNullOrUndefined } from 'util';
import { emit } from 'cluster';

@Component({
  selector: 'vip-meeting-group-edit',
  templateUrl: './meeting-group-edit.component.html',
  styleUrls: ['./meeting-group-edit.component.scss']
})
export class MeetingGroupEditComponent implements OnInit {
  frm: FormGroup;
  currentUser: LoggedInUser;
  isEdit = false;
  submitted = false;
  isHeader: boolean;
  isHeaderValid = true;
  isFooter: boolean;
  isFooterValid = true;
  constructor(
    private fb: FormBuilder,
    private routeActive: ActivatedRoute,
    private api: ApiService,
    protected userInfo: UserInfoService,
    private router: Router,
    private notifier: NotificationService
  ) {
    this.frm = this.fb.group({
      id: [null],
      name: [null, [Validators.required]],
      header: [null],
      footer: [null],
      logo: [null]
    });
  }

  ngOnInit(): void {
    this.currentUser = this.userInfo.user;

    this.routeActive
      .queryParams
      .subscribe(params => {
        if (params.id) {
          const group = this.currentUser.meetingGroups.find(g => g.id === params?.id);
          this.frm.patchValue(group);
          this.isEdit = true;
        }
      });

    this.isHeader = true;
    this.isFooter = false;
  }

  get f() {
    return this.frm.controls;
  }

  changeHeaderFooter() {
    this.isHeader = !this.isHeader;
    this.isFooter = !this.isHeader;
  }

  keyupHandlerHeaderFunction(e) {

    this.f.header.setValue(e);

    if (isNullOrUndefined(this.f.header.value) || this.f.header.value === '') {
      this.isHeaderValid = false;
    } else {
      this.isHeaderValid = true;
    }

    this.f.header.markAsTouched();
    this.f.header.updateValueAndValidity();
  }

  keyupHandlerFooterFunction(e) {
    this.f.footer.setValue(e);

    // if (isNullOrUndefined(this.f.footer.value) || this.f.footer.value === '') {
    //   this.isFooterValid = false;
    // } else {
    //   this.isFooterValid = true;
    // }

    this.f.footer.markAsTouched();
    this.f.footer.updateValueAndValidity();
  }

  onSubmit(createNew?: boolean): void {
    const url = 'user/meeting-group';
    const group = this.frm.value as MeetingGroup;

    this.api.putToReturn<MeetingGroup>(url, group).subscribe((res: MeetingGroup) => this.handlerResult(res, createNew));
  }

  handlerResult(res: MeetingGroup, createNew?: boolean) {
    if (res) {
      if (!this.isEdit) {
        this.notifier.success('meetingGroup.add.success', 'meetingGroup.add.title', true);
      } else {
        this.notifier.success('meetingGroup.edit.success', 'meetingGroup.edit.title', true);
      }
      if (createNew && createNew === true) {
        this.frm.reset();
        this.frm.controls.id.setValue(null);
        this.isEdit = false;
      } else {
        const idx = this.currentUser.meetingGroups.findIndex(x => x.id === res.id);
        this.isEdit = true;
        if (idx !== -1) {
          this.currentUser.meetingGroups[idx] = res;
        } else {
          this.currentUser.meetingGroups.push(res);
        }
        this.frm.controls.id.setValue(res.id);
        this.userInfo.user = this.currentUser;
      }
    }
  }

  close() {
    this.router.navigate([GetRoute(AppSettings.MEETING_GROUP)]);
  }

  getUrl(media: Media) {
    return GetMediaUrl(media);
  }

  getFiles(inputFile: any) {
    if (inputFile.files && inputFile.files.length > 0) {
      const file = inputFile.files[0]; // only allow one file

      const media = this.f.logo.value;
      this.api.uploadFile(file).subscribe(res => {
        if (res !== null) {
          if (media != null) {
            // delete old one
            this.api.deleteFile(media.id);
          }
          this.frm.controls.logo.setValue(res);
        }
      });
    }
  }
}
