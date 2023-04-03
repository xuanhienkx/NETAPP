import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subject } from 'rxjs';
import { Attendee, Meeting, Holder, Delegation, Person, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { NbDateService, NbDialogRef } from '@nebular/theme';
import { isNullOrUndefined } from 'util';
import { Media, MediaForDel } from 'src/app/@core/models/common';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';
import { DelegateRequest } from 'src/app/@core/models/delegate-request.model';
import { CustomValidationService } from 'src/app/@core/services/custom-validation.service';

@Component({
  selector: 'vip-attendee-dialog',
  templateUrl: './attendee-dialog.component.html',
  styleUrls: ['./attendee-dialog.component.scss']
})
export class AttendeeDialogComponent implements OnInit, OnDestroy {

  attendeeAdd$: Subject<Attendee> = new Subject<Attendee>();
  destroy$: Subject<void> = new Subject<void>();
  @Input() mt: Meeting;
  @Input() attendee?: Attendee;
  mtIdentities: string[] = [];

  attendees: Attendee[];
  attachments: Media[] = [];

  frm: FormGroup;
  submitted = false;
  newOnSubmit = false;
  max: Date;
  isEdit = false;
  requiredMadator = false;
  constructor(
    protected fb: FormBuilder,
    private api: ApiService,
    private notifier: NotificationService,
    protected dateService: NbDateService<Date>,
    private uploadFileService: UploadFileService,
    private customerValidation: CustomValidationService,
    protected dialogRef: NbDialogRef<AttendeeDialogComponent>) {

    this.frm = fb.group({
      id: [],
      displayName: ['', Validators.required],
      identityNumber: ['', [Validators.required]],
      identityIssuedDate: ['', [Validators.required]],
      identityType: [''],
      identityIssuer: [''],
      address: [''],
      phone: [''],
      emailAddress: [''],
      shares: [0],
      ownedVotes: [0],
      delegatingVotes: [0],
      sharedVotes: [0],
      totalVotes: [0],
      isRepresentative: [false],
      isAttendeeSelect: [false],
      repTitle: [''],
      identityUserId: [''],
      mandators: this.fb.array([])
    });
  }

  ngOnDestroy(): void {
    this.attendeeAdd$.complete();
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnInit(): void {
    this.max = this.dateService.addMonth(this.dateService.today(), -1);
    if (this.attendee) {
      this.bindValueForm(this.attendee);
      this.isEdit = true;
      if (this.attendee.attachments) {
        this.attachments = Object.assign([], this.attendee.attachments);
      }
    }
    if (!this.canEdit) {
      this.frm.disable();
    }
  }
  get canEdit() {
    return !this.attendee || !this.attendee?.votes || this.attendee?.votes?.length === 0;
  }
  get isMeetingClose() {
    return this.mt.status === MeetingStatus[MeetingStatus.Close];
  }

  bindValueForm(attendee: Attendee) {
    this.frm.patchValue(attendee);
    this.f.phone.patchValue(attendee?.phoneNumber?.value);
    this.f.emailAddress.patchValue(attendee?.email?.value);
    this.setDisabledField(true);
    if (!isNullOrUndefined(attendee.mandators) && attendee.mandators?.length > 0) {
      attendee.mandators?.forEach(s => {
        this.mandators.push(this.createMandator(s));
      });
    }

    if (attendee.isRepresentative === true) {
      this.f.repTitle.setValidators([Validators.required]);
    }

    this.f.sharedVotes.setValue(attendee.sharedVotes);
    this.f.totalVotes.setValue(attendee.totalVotes);
  }

  onClose() {
    this.dialogRef.close();
    this.attendeeAdd$.complete();
  }

  changeRepresentative(e) {
    if (this.f.isRepresentative.value === false) {
      this.f.repTitle.setValidators([Validators.required]);
      this.f.totalVotes.clearValidators();
      this.f.totalVotes.updateValueAndValidity();
      this.requiredMadator = false;
      this.frm.markAllAsTouched();
    } else {
      this.f.repTitle.clearValidators();
      this.f.repTitle.updateValueAndValidity();
      this.f.totalVotes.setValidators([Validators.min(1)]);
      this.f.totalVotes.updateValueAndValidity();
      this.requiredMadator = true;
      this.frm.markAllAsTouched();
    }
  }

  async onSubmit(isNew?: boolean) {
    if (this.f.isRepresentative.value === true && (isNullOrUndefined(this.f.repTitle) || this.f.repTitle.value === '')) {
      this.notifier.errorTranslate('attendee.form.repTitle.repTitleErrMs', 'attendee.form.repTitle.errorTitle');
      this.f.repTitle.setValidators([Validators.required]);
      this.f.repTitle.markAsTouched();
      this.f.repTitle.markAsDirty();
      this.frm.markAllAsTouched();
      return;
    } else
      if (this.f.totalVotes.value === 0 && this.f.isRepresentative.value === false) {
        this.notifier.errorTranslate('attendee.checkin.lostDelegateErrMs', 'attendee.checkin.lostDelegateTitle');
        this.frm.markAllAsTouched();
        this.requiredMadator = true;
        return;
      } else
        if (this.frm.invalid) {
          this.frm.markAllAsTouched();
          return;
        } else {
          this.requiredMadator = false;
          this.setDisabledField(false);
          this.newOnSubmit = isNew;

          this.uploadFileService.upload$.next();
        }
  }

  setDisabledField(isDisabled: boolean) {
    if (isDisabled === true) {
      this.f.identityNumber.disable();
      this.f.displayName.disable();
      this.f.identityIssuedDate.disable();
    } else {
      this.f.identityNumber.enable();
      this.f.displayName.enable();
      this.f.identityIssuedDate.enable();
    }
  }

  get f() {
    return this.frm.controls;
  }

  get mandators() {
    const mArrayCtl = this.frm.get('mandators') as FormArray;
    return mArrayCtl;
  }

  fileUploaderCompleted(media: Media[]) {
    if (media) {
      const isEdit = !isNullOrUndefined(this.f.id.value) && this.f.id.value !== '';
      this.submitted = true;
      const body: Attendee = this.frm.value as Attendee;
      // attachments
      if (this.attendee && this.attendee.attachments) {
        const ats = this.attendee.attachments.filter(x => this.attachments.includes(x));
        const attachments = [...ats, ...media];
        body.attachments = attachments;
      } else if (media.length > 0) {
        body.attachments = media;
      }

      body.mandators = this.mandators.controls.map(x => x.value.mandator);

      const url = `meeting/${this.mt?.id}/attendee`;

      this.setDisabledField(true);
      this.api.putToReturn<Attendee>(url, body)
        .subscribe(rs => {
          if (rs) {
            this.attendeeAdd$.next(rs);

            // delete file before update
            if (this.attendee?.attachments?.length > 0) {
              const atsDel = this.attendee?.attachments.filter(x => this.attachments?.includes(x));
              atsDel?.forEach(x => this.api.deleteFile(x.id));
            }

            if (this.newOnSubmit) {
              this.attendee = null;
              this.attachments = [];
              this.frm.reset();
              this.isEdit = false;
              while (this.mandators.controls.length > 0) {
                this.mandators.removeAt(0);
              }
              this.setDisabledField(false);
            } else {
              this.isEdit = true;
              this.attendee = rs;
              this.attachments = Object.assign([], rs?.attachments ?? []);
              this.f.id.setValue(rs.id);
            }

            if (isEdit) {
              this.notifier.success('attendee.edit.success', 'attendee.edit.title', true);
            } else {
              this.notifier.success('attendee.add.success', 'attendee.add.title', true);
            }
            this.submitted = false;
          }

          this.uploadFileService.reset$.next();
        });

    }
  }

  removeFileOnForm(data: MediaForDel) {
    if (!data) {
      return;
    }
    this.attachments.splice(data.idx, 1);
  }


  private createMandator(mandator?: Delegation, readOnly: boolean = true): FormGroup {
    this.mtIdentities.push(mandator?.identityNumber);
    if (readOnly) {
      return this.fb.group({
        mandator,
        votes: mandator?.votes ?? 0,
        readOnly
      });
    } else {
      return this.fb.group({
        mandator,
        votes: [mandator?.votes ?? 0, [Validators.required, Validators.min(1), Validators.pattern('^[0-9]*$')]],
        readOnly,
        maxVotes: mandator?.votes ?? 0
      }, {
        validators: this.customerValidation.isLessThen('votes', 'maxVotes')
      });
    }
  }

  private createMandatorControl(mandator: Holder, sharedVotes: number): FormGroup {
    const delegation = mandator as Person as Delegation;
    delegation.votes = sharedVotes;

    const manCtrl = this.createMandator(delegation, false);
    manCtrl.controls.votes.valueChanges
      .subscribe(x => {
        delegation.votes = x;
        this.updateVotes(mandator.id, x);
      });

    return manCtrl;
  }

  private updateVotes(mandatorId: string, val: number) {
    const old = this.mandators.controls.filter(x => x.value.mandator.id === mandatorId)
      .map(x => x.value.votes ?? 0)[0];

    const totalVotes = this.f.totalVotes.value;
    const sharedVotes = this.f.sharedVotes.value;
    this.f.sharedVotes.setValue(sharedVotes - old + val);
    this.f.totalVotes.setValue(totalVotes - old + val);
  }

  onSelectHolder(holder: Holder) {
    if (holder) {
      this.loadRequestedManadator(holder);
    }

    this.frm.patchValue({
      id: holder.id ?? '',
      displayName: holder?.displayName ?? '',
      identityNumber: holder?.identityNumber ?? '',
      identityIssuedDate: holder?.identityIssuedDate ?? '',
      identityType: holder.identityType ?? '',
      identityIssuer: holder?.identityIssuer ?? '',
      identityUserId: holder?.identityUserId ?? '',
      address: holder?.address ?? '',
      phone: holder?.phoneNumber?.value ?? '',
      emailAddress: holder?.email?.value ?? '',
      shares: holder?.shares ?? 0,
      ownedVotes: holder?.ownedVotes ?? 0,
      sharedVotes: holder?.delegatedVotes ?? 0,
      totalVotes: holder?.availableVotes + holder?.delegatedVotes
    }, { emitEvent: false, onlySelf: true });

    this.setDisabledField(true);
    this.mtIdentities.push(holder.identityNumber);
  }

  addMandator(holder: Holder) {
    if (!holder || holder?.availableVotes === 0) {
      return;
    }
    this.mandators.push(this.createMandatorControl(holder, holder.availableVotes));

    const totalVotes = this.f.totalVotes.value;
    const sharedVotes = this.f.sharedVotes.value;
    this.f.sharedVotes.setValue(sharedVotes + holder.availableVotes);
    this.f.totalVotes.setValue(totalVotes + holder.availableVotes);
  }

  loadRequestedManadator(holder: Holder) {
    const url = `delegateRequest/${this.mt.id}/mandator/${holder.id}`;

    this.api.getObject<DelegateRequest[]>(url)
      .subscribe(rs => {
        if (rs) {
          rs.forEach(x => {
            const delegation = x.mandator as Person as Delegation;
            delegation.votes = x.delegation.votes;
            delegation.requestedDate = x.delegation.requestedDate;
            delegation.approvedDate = x.delegation.approvedDate;
            delegation.attachments = x.delegation.attachments;
            this.mandators.push(this.createMandator(delegation));
          });
        }
      });
  }

  removeMandator(idx: number) {
    const removedVote = this.mandators.controls[idx].value.votes;
    const totalVotes = this.f.totalVotes.value;
    const sharedVotes = this.f.sharedVotes.value;

    this.f.sharedVotes.setValue(sharedVotes - removedVote);
    this.f.totalVotes.setValue(totalVotes - removedVote);

    const identityNumber = this.mandators.controls[idx].value.mandator.identityNumber;
    this.mtIdentities.splice(this.mtIdentities.indexOf(identityNumber), 1);

    this.mandators.removeAt(idx);
  }

  resetForm() {
    this.frm.reset();
    this.isEdit = false;
    this.f.sharedVotes.setValue(0);
    this.f.totalVotes.setValue(0);
    while (this.mandators.length > 0) {
      this.mandators.removeAt(0);
    }
    this.setDisabledField(false);
  }

}
