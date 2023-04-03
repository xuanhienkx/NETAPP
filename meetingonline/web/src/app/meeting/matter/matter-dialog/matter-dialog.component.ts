import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Media, MediaForDel } from 'src/app/@core/models/common';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { NbDialogRef } from '@nebular/theme';
import { Meeting, ElectionMatter, ElectionOption } from 'src/app/@core/models/meeting.model';
import { Subject } from 'rxjs';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';

@Component({
  selector: 'vip-matter-dialog',
  templateUrl: './matter-dialog.component.html',
  styleUrls: ['./matter-dialog.component.scss']
})
export class MatterDialogComponent implements OnInit {

  meetingMatterAdd$: Subject<ElectionMatter> = new Subject<ElectionMatter>();
  @Input() mt?: Meeting;
  @Input() matter?: ElectionMatter;
  @Input() canEdit = true;

  frm: FormGroup;
  submitted: boolean;
  mattermember: ElectionOption[];
  attachments: Media[] = [];

  mbEdit: ElectionOption;
  isEdit: boolean;
  newOnSubmit = false;
  isMustRequiredMember = false;
  constructor(
    private api: ApiService,
    fb: FormBuilder,
    private notifier: NotificationService, 
    private uploadFileService: UploadFileService,
    protected dialogRef: NbDialogRef<MatterDialogComponent>
  ) {

    this.frm = fb.group({
      name: ['', Validators.required],
      description: [],
      optional: [false],
      taken: [1],
      member: [],
      id: []
    });
  }

  ngOnInit(): void {

    if (this.matter) {
      if (this.matter.optional) {
        this.mattermember = Object.assign([], this.matter?.options ?? []);
        this.f.taken.setValidators([Validators.min(1)]);
      }

      this.attachments = Object.assign([], this.matter?.attachments ?? []);
      this.frm.patchValue(this.matter);
      this.isEdit = true;
    } else {
      this.mattermember = [];
    }

    if (!this.canEdit) {
      this.frm.disable();
    }
  }

  get f() {
    return this.frm.controls;
  }

  onClose() {
    this.dialogRef.close();
  }

  removeFileOnForm(data: MediaForDel) {
    if (!data) {
      return;
    }
    this.attachments.splice(data.idx, 1);
  }


  async fileUploaderCompleted(media: Media[]) {
    if (media) {
      const body = this.frm.value as ElectionMatter;

      if (this.matter && this.matter.attachments) {
        const ats = this.matter.attachments.filter(x => this.attachments.includes(x));
        const attachments = [...ats, ...media];
        body.attachments = attachments;
      } else if (media.length > 0) {
        body.attachments = media;
      }

      this.submitted = true;
      const url = `meeting/${this.mt?.id}/election-matter`;

      if (this.f.optional) {
        body.options = this.mattermember;
      }

      const result = await this.api.putToReturn<ElectionMatter>(url, body).toPromise();

      if (result !== null) {
        if (this.isEdit) {
          const atDels = this.matter.attachments.filter(x => !this.attachments.includes(x));
          atDels.forEach(m => this.api.deleteFile(m.id));

          this.notifier.success('matter.edit.success', 'matter.edit.title', true);
        } else {
          this.notifier.success('matter.add.success', 'matter.add.title', true);
        }

        if (this.newOnSubmit) {
          this.frm.reset();
          this.mattermember = [];
          this.attachments = [];
          this.isEdit = false;
          this.matter = null;
        } else {
          this.matter = result;
          this.frm.patchValue(this.matter);
          if (this.matter.optional) {
            this.mattermember = Object.assign([], this.matter?.options ?? []);
          }
          this.attachments = Object.assign([], this.matter?.attachments ?? []);
          this.isEdit = true;
        }

        this.meetingMatterAdd$.next(result);
        this.submitted = false;
        this.newOnSubmit = false;
      }
      this.uploadFileService.reset$.next();
    }
  }

  changeAdditional(e) {
    if (this.f.optional.value === true && this.f.taken.value < 1) {
      this.f.taken.setValidators([Validators.min(1)]);
      this.frm.markAllAsTouched();
    } else {
      this.f.taken.clearValidators();
      this.f.taken.updateValueAndValidity();
      this.f.taken.reset({ value: 1 });
      this.frm.markAllAsTouched();
    }
  }

  createMember() {
    if (this.f.member.value) {
      const ms = this.f.member?.value?.trim();
      if (this.mattermember && this.mbEdit) {
        this.mbEdit.name = ms;
        this.mattermember.concat(this.mbEdit);
      } else {
        this.mbEdit = { name: ms };
        this.mattermember.push(this.mbEdit);
      }
      this.f.member.setValue('');
      this.mbEdit = null;
      this.isMustRequiredMember = false;
    }
  }

  editMember(mb: ElectionOption) {
    this.f.member.setValue(mb?.name);
    this.mbEdit = mb;
  }


  removeMember(ma, idx) {
    this.mattermember.splice(idx, 1);
  }

  async submit(isNew?: boolean) {

    if (this.frm.invalid) {
      this.frm.markAllAsTouched();
      return;
    }
    if (this.f.optional.value === true && this.f.taken?.value < 1) {
      this.f.taken.setValidators([Validators.min(1)]);
      this.frm.markAllAsTouched();
      return;
    }
    if (this.f.optional.value === true && this.mattermember?.length < this.f.taken?.value) {
      const minMember = this.f.taken.value < 1 ? 1 : this.f.taken.value;
      this.f.taken.setValue(minMember);
      this.isMustRequiredMember = true;
      this.frm.markAllAsTouched();
      return;
    }

    this.newOnSubmit = isNew;
    this.uploadFileService.upload$.next();
  }


  itemDroped(event: CdkDragDrop<string[]>) {
    if (event.previousIndex === event.currentIndex || !this.canEdit) {
      return;
    }
    moveItemInArray(this.mattermember, event.previousIndex, event.currentIndex);
  }

}
