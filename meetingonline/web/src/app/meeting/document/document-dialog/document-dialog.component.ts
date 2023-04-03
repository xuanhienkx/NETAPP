import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Media, MediaForDel } from 'src/app/@core/models/common';
import { ApiService } from 'src/app/@core/services/api.service';
import { NbDialogRef } from '@nebular/theme';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { Meeting, MeetingInfo } from 'src/app/@core/models/meeting.model';
import { Subject } from 'rxjs';
import { LoggedInUser } from 'src/app/@core/models/user.model';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';

@Component({
  selector: 'vip-document-dialog',
  templateUrl: './document-dialog.component.html',
  styleUrls: ['./document-dialog.component.scss']
})

export class DocumentDialogComponent implements OnInit {

  meetingInfoAdd$: Subject<MeetingInfo> = new Subject<MeetingInfo>();
  meetingMatterAdd$: Subject<MeetingInfo> = new Subject<MeetingInfo>();
  @Input() mt: Meeting;
  @Input() info?: MeetingInfo;
  @Input() canEdit = true;
  frm: FormGroup;
  user: LoggedInUser;
  attachments: Media[] = [];
  newOnSubmit = false;
  submitted = false;
  isEdit = false;
  constructor(
    protected fb: FormBuilder,
    private api: ApiService,
    private notifier: NotificationService,
    private userInfo: UserInfoService,
    private uploadFileService: UploadFileService,
    protected dialogRef: NbDialogRef<DocumentDialogComponent>) {

    this.frm = fb.group({
      id: [],
      name: ['', Validators.required],
      description: [],
      isCreateVote: [false]
    });

  }

  ngOnInit(): void {
    this.user = this.userInfo.user;
    if (this.info) {
      this.frm.patchValue(this.info);
      this.isEdit = true;
      if (this.info.attachments) {
        this.attachments = Object.assign([], this.info.attachments);
      }
    }
    if (!this.canEdit) {
      this.frm.disable();
    }
  }

  public keyupHandlerContentFunction(e: any) {
    this.f.description.setValue(e);
  }

  get f() {
    return this.frm.controls;
  }

  removeFileOnForm(data: MediaForDel) {
    if (!data) {
      return;
    }
    this.attachments.splice(data.idx, 1);
  }

  onClose() {
    this.dialogRef.close();
  }

  async fileUploaderCompleted(media: Media[]) {
    if (media) {
      const body = this.frm.value as MeetingInfo;

      if (this.info && this.info.attachments) {
        const ats = this.info.attachments.filter(x => this.attachments.includes(x));
        const attachments = [...ats, ...media];
        body.attachments = attachments;
      } else if (media.length > 0) {
        body.attachments = media;
      }

      const result = this.frm.controls.isCreateVote.value
        ? await this.updateMeetingInfoWithElection(body)
        : await this.updateMeetingInfo(body);

      if (result !== null) {
        this.meetingInfoAdd$.next(result);

        if (this.isEdit) {
          const atDels = this.info.attachments.filter(x => !this.attachments.includes(x));
          atDels.forEach(m => this.api.deleteFile(m.id));

          this.notifier.success('document.edit.success', 'document.edit.title', true);
        } else {
          this.notifier.success('document.add.success', 'document.add.title', true);
        }
        if (this.newOnSubmit) {
          this.frm.reset();
          this.attachments = [];
          this.info = null;
          this.isEdit = false;
        } else {
          this.info = result;
          this.frm.patchValue(this.info);
          this.frm.get('isCreateVote').setValue(false);
          this.isEdit = true;

          if (this.info.attachments) {
            this.attachments = Object.assign([], this.info.attachments);
          }
        }
        this.submitted = false;
        this.newOnSubmit = false;
      }
      this.uploadFileService.reset$.next();
    }
  }

  async onSubmit(isNew?: boolean) {
    if (this.frm.invalid) {
      this.frm.markAllAsTouched();
      return;
    }

    this.newOnSubmit = isNew;
    this.uploadFileService.upload$.next();
  }

  private async updateMeetingInfo(body: MeetingInfo): Promise<MeetingInfo> {
    const url = `meeting/${this.mt?.id}/info`;
    return await this.api.putToReturn<MeetingInfo>(url, body).toPromise();
  }

  private async updateMeetingInfoWithElection(body: MeetingInfo): Promise<MeetingInfo> {
    const url = `meeting/${this.mt?.id}/info-with-election`;
    const result = await this.api.putToReturn<MeetingInfo[]>(url, body).toPromise();
    if (result !== null) {
      this.meetingMatterAdd$.next(result[1]);
      return result[0];
    }
  }
}
