import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ApiService } from 'src/app/@core/services/api.service';

@Component({
  selector: 'vip-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent {
  frm: FormGroup;
  submitted: boolean;
  constructor(
    private fb: FormBuilder,
    private api: ApiService,
    private notifier: NotificationService,
    protected dialogRef: NbDialogRef<UserDialogComponent>) {
    this.frm = this.fb.group({
      displayName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  cancel() {
    this.dialogRef.close();
  }

  submit() {
    this.submitted = true;
    if (!this.frm.valid) {
      return;
    }
    const url = 'auth/sign-up';
    const body = this.frm.value;
    this.api.postToReturn<boolean>(url, body).subscribe(data => {
      this.frm.reset();
      this.submitted = false;
      this.notifier.success('member.dialog.user.add.success', 'member.dialog.user.add.title', true);
    });
    return body;
  }

}
