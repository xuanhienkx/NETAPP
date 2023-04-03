import { Component, OnDestroy, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { NbIconLibraries, NbThemeService } from '@nebular/theme';
import { environment } from 'src/environments/environment';
import { UserInfoService } from './@core/services/user-info.service';
import { Subject } from 'rxjs';
import { NotificationService } from './@core/services/notification.service';
import { AppStateProvider } from './@core/services/app-state.provider';
import { WsMessage, Message } from './@core/models/common';
import { takeUntil, delay, takeWhile } from 'rxjs/operators';
import { ConnectionStateManager } from './@core/services/connection-state.manager';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'vip-app',
  styleUrls: ['app.component.scss'],
  template: '<vip-spinner></vip-spinner> <router-outlet></router-outlet>',
})
export class AppComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  constructor(
    private translate: TranslateService,
    private userInfo: UserInfoService,
    private iconLibraries: NbIconLibraries,
    private appState: AppStateProvider,
    private notifier: NotificationService,
    private theme: NbThemeService,
    private connectionState: ConnectionStateManager
  ) {
    translate.addLangs(environment.languages);
    translate.setDefaultLang(environment.defaultLanguage);
    translate.use(environment.defaultLanguage);

    this.iconLibraries.registerFontPack('font-awesome', { iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('solid', { packClass: 'fas', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('regular', { packClass: 'far', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('light', { packClass: 'fal', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('duotone', { packClass: 'fad', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('brands', { packClass: 'fab', iconClassPrefix: 'fa' });
    this.iconLibraries.setDefaultPack('font-awesome'); // <---- set as default


    const self = this;

    this.appState.message$.pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (x: Message) => self.showMessage(x)
      });

    this.appState.user$.pipe(takeUntil(this.destroy$))
      .subscribe({
        next: u => this.connectionState.onUserChanges(u)
      });

    this.appState.wsMessage$.pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (message: WsMessage) => self.onWsMessageReceive(message),
        error: () => {
          // request with invalid token
          return self.showMessage({ msg: 'Common.invalidToken' });
        },
      });
  }

  ngOnInit(): void {
    // load login user
    this.userInfo.loadLoginUserInfo();

    const self = this;
    this.theme.getJsTheme().pipe(
      takeWhile(() => isNullOrUndefined(self.appState.theme)),
      delay(1)
    ).subscribe(theme => {
      self.appState.theme = theme;
    });
  }

  ngOnDestroy(): void {
    this.destroy$?.next();
    this.destroy$?.complete();
  }

  onWsMessageReceive(message: WsMessage) {
    if (message) {
      if (message.id === this.userInfo.user?.id) {
        if (message.data !== this.userInfo.user?.loginTimeStamp) {
          return this.appState.logout$.next({ message: { msg: 'Common.loginSessionViolent' } });
        }
      } else if (message.id === this.connectionState.connectionId) {
        this.showMessage({ msg: message.data, isTranslated: true, type: 3 });
      } else if (message.data === 'INVALID_TOKEN') {
        return this.appState.logout$.next({ message: { msg: 'Common.invalidToken' } });
      }
    }
  }


  showMessage(m: Message) {
    if (isNullOrUndefined(m.type) || m.type === 0) {
      this.notifier.success(m.msg, m.title, !m.isTranslated);
    } else if (m.type === 1) {
      this.notifier.warning(m.msg, m.title, !m.isTranslated);
    } else if (m.type === 2) {
      if (m.isTranslated) {
        this.notifier.error(m.msg, m.title);
      } else {
        this.notifier.errorTranslate(m.msg, m.title);
      }
    } else {
      this.notifier.message(m.msg, m.title, !m.isTranslated);
    }
  }
}
