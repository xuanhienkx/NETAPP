import { Component, Input, OnInit, ElementRef, ViewChild } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { VipConfirm, VipDialogConfig, VipConfirmResult } from 'src/app/@core/services/confirmation-dialog.service';
import { FormControl, Validators } from '@angular/forms';
import { isNullOrUndefined } from 'util';
@Component({
  selector: 'vip-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent implements OnInit {
  @Input() confirm: VipConfirm;

  @ViewChild('reasonInput') reasonElement: ElementRef<HTMLTextAreaElement>;

  reason?: FormControl;
  config: VipDialogConfig = {
    btnOkText: 'Common.confirmOk',
    btnCancelText: 'Common.confirmCancel'
  };
  constructor(
    private dialogRef: NbDialogRef<ConfirmationDialogComponent>
  ) {
    this.reason = new FormControl();
    this.reason.setValidators([Validators.required]);
  }

  ngOnInit(): void {

    if (isNullOrUndefined(this.confirm?.title)) {
      this.confirm.title = 'Common.confirmTitle';
    }
    if (isNullOrUndefined(this.confirm.config)) {
      this.confirm.config = this.config;
    }

    if (isNullOrUndefined(this.confirm?.config?.btnOkText)) {
      this.confirm.config.btnOkText = 'Common.confirmOk';
    }

    if (isNullOrUndefined(this.confirm?.config?.btnCancelText)) {
      this.confirm.config.btnCancelText = 'Common.confirmCancel';
    }
    if (this.confirm.config.requiredNote === true) {
      this.reasonElement?.nativeElement.focus();
    }
  }

  public decline() {
    this.dialogRef.close({ isConfirm: false } as VipConfirmResult);
  }

  public accept() {
    if (this.confirm?.config?.requiredNote === true && isNullOrUndefined(this.reason.value) || this.reason.value === '') {
      this.reason.markAsTouched();
      this.reasonElement?.nativeElement.focus();
      return;
    } else {
      this.dialogRef.close({ isConfirm: true, message: this.reason.value } as VipConfirmResult);
    }
  }
}
