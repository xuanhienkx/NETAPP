import { Injectable, InjectionToken } from '@angular/core';
import { ConfirmationDialogComponent } from 'src/app/@theme/components/confirmation-dialog/confirmation-dialog.component';
import { NbDialogService } from '@nebular/theme';

export declare const VIP_DIALOG_CONFIG: InjectionToken<VipDialogConfig>;
export class VipDialogConfig {
  btnOkText?: string;
  btnCancelText?: string;
  requiredNote?: boolean;
  constructor(config: Partial<VipDialogConfig>) {
    Object.assign(this, config);
  }

}
export class VipConfirm {
  title?: string;
  message: string;
  config?: VipDialogConfig;
}
export class VipConfirmResult {
  isConfirm: boolean;
  message?: string;
}
@Injectable({
  providedIn: 'root'
})
export class ConfirmationDialogService {

  constructor(private dialogService: NbDialogService) { }

  public async confirm(
    message: string,
    title: string = 'Common.confirmTitle'): Promise<boolean> {
    const confirm: VipConfirm = {
      title,
      message
    };
    const rs = await this.confirmWithConfig(confirm);
    return rs.isConfirm;

  }

  public async confirmWithConfig(confirm: VipConfirm): Promise<VipConfirmResult> {
    const modalRef = this.dialogService.open(ConfirmationDialogComponent,
      {
        context: {
          confirm
        },
        hasBackdrop: false,
        autoFocus: true,
        closeOnBackdropClick: false
      });
    return await modalRef.onClose.toPromise();
  }
}
