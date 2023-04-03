import { Injectable } from '@angular/core';
import { NbToastrService, NbIconConfig, NbToastrConfig } from '@nebular/theme';
import { transformStringToArray } from '../utils/utils';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin } from 'rxjs';
import { isNullOrUndefined } from 'util';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private toastrService: NbToastrService, private translate: TranslateService) {

  }

  success(message: string, title?: string, isNeedTranlate?: boolean) {
    if (isNullOrUndefined(title)) {
      title = 'Common.commonInformTitle';
    }
    if (isNeedTranlate) {
      forkJoin(
        this.translate.get(title),
        this.translate.get(message)
      ).subscribe(([t, m]) => {
        this.toastrService.success(m, t);
      });
    } else {
      this.translate.get(title)
        .subscribe(t => this.toastrService.success(message, t));
    }
  }

  errorTranslate(message: string, title?: string, op?: any) {
    if (isNullOrUndefined(title)) {
      title = 'Common.commonErrorTitle';
    }

    forkJoin(
      this.translate.get(title, op),
      this.translate.get(message, op)
    ).subscribe(([t, m]) => {
      this.toastrService.danger(m, t, { duration: 5000 });
    });
  }

  error(message: string | string[], title?: string) {
    if (isNullOrUndefined(title)) {
      title = 'Common.commonErrorTitle';
    }

    this.translate.get(title)
      .subscribe(t => {
        message = transformStringToArray(message);
        message.forEach(m => this.toastrService.danger(m, t, { duration: 5000 }));
      });
  }

  warning(message: string, title?: string, isNeedTranlate?: boolean) {
    if (isNullOrUndefined(title)) {
      title = 'Common.commonWarningTitle';
    }

    if (isNeedTranlate) {
      forkJoin(
        this.translate.get(title),
        this.translate.get(message)
      ).subscribe(([t, m]) => {
        this.toastrService.warning(m, t, { duration: 5000 });
      });
    } else {
      this.translate.get(title)
        .subscribe(t => this.toastrService.warning(message, t, { duration: 5000 }));
    }
  }

  message(message: string, title?: string, isNeedTranlate?: boolean) {
    if (isNullOrUndefined(title)) {
      title = 'Common.commonInformTitle';
    }

    const config: Partial<NbToastrConfig> = {
      icon: 'envelope-open-text',
      iconPack: 'solid',
      duration: 5000
    };

    if (isNeedTranlate) {
      forkJoin(
        this.translate.get(title),
        this.translate.get(message)
      ).subscribe(([t, m]) => {
        this.toastrService.info(m, t, config);
      });
    } else {
      this.translate.get(title)
        .subscribe((res: string) => this.toastrService.info(message, res, config));
    }
  }
}
