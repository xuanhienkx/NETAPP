import { Component, OnDestroy, AfterViewInit } from '@angular/core';

import { NbMenuItem } from '@nebular/theme';
import { NavigationGuard } from '../@core/services/navigation.guard';
import { TranslateService } from '@ngx-translate/core';
import { GetMenu, AppSettings } from '../@core/utils/app-constants';
import { Subscription } from 'rxjs';
import { AppStateProvider } from '../@core/services/app-state.provider';
import { AuthenService } from '../@core/services/authen.service';

@Component({
  selector: 'vip-admin',
  styleUrls: ['admin.component.scss'],
  templateUrl: 'admin.component.html'
})
export class AdminComponent implements OnDestroy, AfterViewInit {
  private logout$: Subscription;

  menu: NbMenuItem[];

  constructor(
    private navigator: NavigationGuard,
    private localizer: TranslateService,
    private authService: AuthenService,
    private appState: AppStateProvider
  ) {
    this.menu = GetMenu('admin', [
      AppSettings.DASHBOARD,
      AppSettings.PROFILE,
      AppSettings.MEETING_SETTING, ,
      AppSettings.MEETING_GROUP,
      AppSettings.SETTINGS,
      AppSettings.MEETING_ROLE,
    ], this.localizer, this.navigator);

    const self = this;

    this.logout$ = this.appState.logout$.subscribe({
      next: (msg) => {
        self.authService.logout({
          message: msg?.message,
          extras: {
            queryParams: {
              returnUrl: window.location.pathname,
              params: msg?.extras?.queryParams?.params
            }
          }
        });
      },
    });
  }

  ngAfterViewInit(): void {
    this.localizer.get('menu.admin.home')
      .subscribe(t => this.appState.title$.next(t));
  }

  ngOnDestroy(): void {
    if (this.logout$) {
      this.logout$.unsubscribe();
    }
  }
}
