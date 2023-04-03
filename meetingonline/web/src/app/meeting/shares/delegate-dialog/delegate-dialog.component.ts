import { Component, OnInit, Input, ViewChild, ElementRef, AfterViewInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { NbDateService, NbDialogRef, NbSelectComponent } from '@nebular/theme';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';
import { Holder, Meeting, Attendee } from 'src/app/@core/models/meeting.model';
import { Media, MediaForDel } from 'src/app/@core/models/common';
import { CustomValidationService } from 'src/app/@core/services/custom-validation.service';
import { DelegateRequest } from 'src/app/@core/models/delegate-request.model';
import { Subject } from 'rxjs';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';

@Component({
  selector: 'vip-delegate-dialog',
  templateUrl: './delegate-dialog.component.html',
  styleUrls: ['./delegate-dialog.component.scss']
})
export class DelegateDialogComponent implements OnInit, AfterViewInit, OnDestroy {

  itemAdd$: Subject<DelegateRequest> = new Subject<DelegateRequest>();

  @Input() mt: Meeting;
  @Input() holder?: Holder;
  @Input() delegateRequest?: DelegateRequest;
  @Input() mtIdentities?: string[] = [];
  @Input() canEdit = true;

  isEdit = false;
  submitted = false;
  isSubmitedNew = false;
  attendees: Attendee[];
  selectedItem: Attendee | Holder;
  attachments: Media[] = [];
  frm: FormGroup;
  availableVotes = 0;

  private isDestroy = false;
  private typeOfDelegate: string;

  @ViewChild('firstFocus') fieldFocus: ElementRef<NbSelectComponent>;

  constructor(
    protected fb: FormBuilder,
    private api: ApiService,
    private appState: AppStateProvider,
    private notifier: NotificationService,
    protected dateService: NbDateService<Date>,
    private uploadFileService: UploadFileService,
    private customerValidation: CustomValidationService,
    protected dialogRef: NbDialogRef<DelegateDialogComponent>) {
    this.frm = fb.group({
      id: [],
      delegateRequestId: [],
      displayName: ['', Validators.required],
      identityNumber: ['', [Validators.required, Validators.minLength(4)]],
      identityIssuedDate: ['', [Validators.required]],
      identityType: [''],
      identityIssuer: [''],
      address: [''],
      phone: [''],
      emailAddress: ['', [Validators.email]],
      votes: [0, [Validators.required, Validators.min(1)]],
      availableVotes: [this.availableVotes],
      isAttendeeDelegated: [true]
    }, {
      validators: this.customerValidation.isLessThen('votes', 'availableVotes')
    });

  }
  ngOnDestroy(): void {
    this.isDestroy = true;
  }

  async ngOnInit(): Promise<void> {
    this.appState.accountSummary$.next(this.holder);
    if (this.delegateRequest?.delegation) {
      this.isEdit = true;
      this.frm.get('delegateRequestId').setValue(this.delegateRequest?.id);
      this.frm.patchValue(this.delegateRequest?.delegation);
      this.frm.get('phone').setValue(this.delegateRequest?.delegation?.phoneNumber?.value);
      this.frm.get('emailAddress').setValue(this.delegateRequest?.delegation?.email?.value);
      this.setDisabledField(true);

      if (this.delegateRequest?.delegation?.attachments) {
        this.attachments = Object.assign([], this.delegateRequest?.delegation?.attachments);
      }
    }

    this.loadAttendeeDelegated();
    this.checkAndSetAvailableVotes();
    if (!this.canEdit) {
      this.frm.disable();
    }

  }

  ngAfterViewInit(): void {
    if (!this.isEdit) {
      // this.fieldFocus.nativeElement?.button?.nativeElement.focus();
    }
  }

  checkAndSetAvailableVotes() {
    if (this.holder) {
      this.availableVotes = this.holder?.availableVotes;
      if (!isNaN(this.delegateRequest?.delegation?.votes)) {
        this.availableVotes += this.delegateRequest?.delegation?.votes;
      }
      this.frm.get('availableVotes').setValue(this.availableVotes);
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

  bindForm(item: Attendee | Holder) {
    this.setDisabledField(true);
    this.frm.patchValue(item);
    this.frm.get('phone').setValue(item?.phoneNumber?.value);
    this.frm.get('emailAddress').setValue(item?.email?.value);

    this.checkAndSetAvailableVotes();
    this.frm.get('votes').setValue(this.availableVotes);
  }


  loadAttendeeDelegated() {
    const url = `meeting/${this.mt.id}/attendee-delegated`;
    this.api.getObject<Attendee[]>(url, false).subscribe(rs => this.attendees = rs);
  }

  get f() {
    return this.frm.controls;
  }

  onSubmit(isNew?: boolean) {
    if (this.frm.invalid) {
      this.frm.markAllAsTouched();
      return;
    }

    if (isNew) {
      this.isSubmitedNew = true;
    }
    this.setDisabledField(false);
    this.uploadFileService.upload$.next();
  }

  async fileUploaderCompleted(media: Media[]) {
    if (media) {
      const delegation = this.frm.value;
      this.submitted = true;
      if (this.delegateRequest?.delegation && this.delegateRequest?.delegation.attachments) {
        const ats = this.delegateRequest?.delegation?.attachments?.filter(x => this.attachments.includes(x));
        const attachments = [...ats, ...media];
        delegation.attachments = attachments;
      } else if (media.length > 0) {
        delegation.attachments = media;
      }
      this.holder.emailAddress = this.holder?.email?.value;
      this.holder.phone = this.holder?.phoneNumber?.value;
      const body: DelegateRequest = {
        id: this.frm.controls.delegateRequestId.value,
        meetingId: this.mt.id,
        mandator: this.holder,
        delegation,
        isOnline: true
      };



      const rs = await this.api.postToReturn<DelegateRequest>('delegateRequest', body).toPromise();
      if (rs) {

        this.itemAdd$.next(rs);

        if (this.isEdit) {
          const atsDel = this.delegateRequest?.delegation?.attachments?.filter(x => !this.attachments.includes(x));
          if (atsDel.length > 0) {
            atsDel.forEach(x => this.api.deleteFile(x.id));
          }
          this.holder.availableVotes = this.availableVotes - rs.delegation.votes;
          this.holder.delegatingVotes = this.holder.ownedVotes - this.availableVotes + rs.delegation.votes;
          this.holder.blockedVotes = this.holder.ownedVotes - this.availableVotes + rs.delegation.votes;
          this.notifier.success('shares.delegate-dialog.edit.success', 'shares.delegate-dialog.edit.title', true);
        } else {
          this.holder.availableVotes -= rs.delegation.votes;
          this.holder.delegatingVotes += rs.delegation.votes;
          this.holder.blockedVotes += rs.delegation.votes;
          this.notifier.success('shares.delegate-dialog.add.success', 'shares.delegate-dialog.add.title', true);
        }

        if (this.isSubmitedNew) {
          this.frm.reset();
          this.isEdit = false;
          this.delegateRequest = null;
          this.attachments = [];
        } else {
          this.delegateRequest = rs;
          this.frm.patchValue(rs.delegation);
          this.frm.get('delegateRequestId').patchValue(this.delegateRequest.id);
          this.isEdit = true;

          if (this.delegateRequest?.delegation?.attachments) {
            this.attachments = Object.assign([], this.delegateRequest?.delegation?.attachments);
          }

        }

        this.setDisabledField(this.isEdit);
        this.submitted = false;
        this.checkAndSetAvailableVotes();
        this.appState.accountSummary$.next(this.holder);
      }
      this.uploadFileService.reset$.next();
    }
  }

  onClose() {
    this.dialogRef.close();
  }

  selectTypeDelegetion(typeRef: string) {
    this.typeOfDelegate = typeRef;
  }

  removeFileOnForm(data: MediaForDel) {
    if (!data) {
      return;
    }
    this.attachments.splice(data.idx, 1);
  }

  resetForm(cancelSearch?: boolean) {
    this.frm.reset();
    this.f.isAttendeeDelegated.setValue(true);
    if (!this.isEdit) {
      this.setDisabledField(false);
    } else {
      this.frm.patchValue(this.delegateRequest?.delegation);
      if (this.delegateRequest?.delegation?.attachments) {
        this.attachments = Object.assign([], this.delegateRequest?.delegation?.attachments);
      }

      this.frm.get('delegateRequestId').patchValue(this.delegateRequest.id);
    }
    this.checkAndSetAvailableVotes();
  }

  onSelectHodler(item: Attendee | Holder) {
    if (item) {
      if (item.id === this.holder.id) {
        return;
      } else {
        this.selectedItem = item;
        this.bindForm(item);
      }
    }
  }

}
