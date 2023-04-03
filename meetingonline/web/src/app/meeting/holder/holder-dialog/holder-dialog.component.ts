import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Meeting, Holder, MeetingType, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { NbDialogRef, NbDateService } from '@nebular/theme';
import { Subject, } from 'rxjs';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'vip-holder-dialog',
  templateUrl: './holder-dialog.component.html',
  styleUrls: ['./holder-dialog.component.scss']
})
export class HolderDialogComponent implements OnInit, OnDestroy {
  holderAdd$: Subject<Holder> = new Subject<Holder>();
  destroy$: Subject<void> = new Subject<void>();
  @Input() mt: Meeting;
  @Input() hd?: Holder;
  holders: Holder[];
  frm: FormGroup;
  meetingType: MeetingType = MeetingType.GeneralMeeting;
  submitted = false;
  max: Date;
  constructor(
    protected fb: FormBuilder,
    private api: ApiService,
    private notifier: NotificationService,
    protected dateService: NbDateService<Date>,
    protected dialogRef: NbDialogRef<HolderDialogComponent>) {

    this.frm = fb.group({
      id: [],
      displayName: ['', Validators.required],
      identityNumber: ['', [Validators.required]],
      identityIssuedDate: ['', [Validators.required]],
      identityType: [''],
      identityIssuer: [''],
      address: ['', [Validators.required, Validators.minLength(6)]],
      phone: ['', [Validators.required, Validators.minLength(9)]],
      emailAddress: ['', [Validators.required, Validators.email]],
      shares: [0, [Validators.required, Validators.min(1)]],
      ownedVotes: [0, [Validators.required, Validators.min(1)]]
    });
  }
  get allowEdit() {
    return this.mt?.status === MeetingStatus[MeetingStatus.Started];
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnInit(): void {
    this.max = this.dateService.addMonth(this.dateService.today(), -1);
    if (this.hd) {
      this.bindValueForm(this.hd);
    }
    if (!this.allowEdit) {
      this.frm.disable();
    }
  }

  bindValueForm(hd: Holder) {
    this.frm.patchValue(hd);
    this.f.phone.patchValue(hd?.phoneNumber?.value);
    this.f.emailAddress.patchValue(hd?.email?.value);
  }

  onClose() {
    this.dialogRef.close();
  }

  async onSubmit(isNew?: boolean) {
    console.log(this.frm.invalid);

    if (this.frm.invalid) {
      this.frm.markAllAsTouched();
      return;
    }
    const isEdit = !isNullOrUndefined(this.f.id.value) && this.f.id.value !== '';
    this.submitted = true;
    const body: Holder = this.frm.value as Holder;
    const url = `meeting/${this.mt?.id}/holder`;

    const rs = await this.api.putToReturn<Holder>(url, body).toPromise();
    if (rs) {
      if (isNew) {
        this.frm.reset();
      } else {
        this.f.id.setValue(rs.id);
      }

      if (isEdit) {
        this.notifier.success('holder.edit.success', 'holder.edit.title', true);
      } else {
        this.notifier.success('holder.add.success', 'holder.add.title', true);
      }

      this.submitted = false;
      this.holderAdd$.next(rs);
    }

  }

  get f() {
    return this.frm.controls;
  }

}
