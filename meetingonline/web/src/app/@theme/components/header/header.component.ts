import { Component, OnDestroy, OnInit } from '@angular/core';
import { NbMenuService, NbSidebarService, NbMenuItem } from '@nebular/theme';

import { takeUntil, filter } from 'rxjs/operators';
import { Subject, forkJoin } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { AppSettings, GetRoute } from 'src/app/@core/utils/app-constants';
import { LayoutService } from 'src/app/@core/services/layout.service';
import { GetMediaUrl } from 'src/app/@core/utils/utils';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { isNullOrUndefined } from 'util';
import { MeetingStatus } from 'src/app/@core/models/meeting.model';

@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  pageHeaderTitle: string;
  pageHeaderBagde: string;
  logoUrl: string;
  userPictureOnly = false;
  user: any;
  isBagdeLocked = false;

  userMenu: NbMenuItem[] = [
    { title: AppSettings.PROFILE.Path, link: GetRoute(AppSettings.PROFILE) },
    { title: AppSettings.LOGOUT.Path }
  ];

  constructor(
    private localizer: TranslateService,
    private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private layoutService: LayoutService,
    private appState: AppStateProvider,
    private userInfo: UserInfoService
  ) {
    forkJoin(
      localizer.get('menu.' + this.userMenu[0].title),
      localizer.get('menu.' + this.userMenu[1].title),
    ).subscribe(([t1, t2]) => {
      this.userMenu[0].title = t1;
      this.userMenu[1].title = t2;
    });

    const self = this;
    this.appState.meeting$.pipe(
      takeUntil(this.destroy$)
    ).subscribe(m => {
      if (m) {
        self.pageHeaderTitle = m.name;
        self.isBagdeLocked = m.status === MeetingStatus[MeetingStatus.Locking];

        if (!isNullOrUndefined(m?.logo)) {
          self.logoUrl = GetMediaUrl(m?.logo);
        }
        self.localizer.get('enum.MeetingStatus.' + m.status)
          .subscribe(t => self.pageHeaderBagde = t);
      } else {
        self.logoUrl = null;
      }
    });

    this.appState.title$.pipe(
      takeUntil(this.destroy$)
    ).subscribe(title => self.pageHeaderTitle = title);

    this.menuService.onItemClick()
      .pipe(
        filter(tag => tag.tag === 'user-menu-header'),
        takeUntil(this.destroy$)
      ).subscribe(menu => self.menuClick(menu.item));
  }

  ngOnInit() {
    this.user = this.userInfo.user;
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    this.layoutService.changeLayoutSize();

    return false;
  }

  menuClick(item: NbMenuItem) {
    if (item.link == null) {
      this.appState.logout$.next();
    }
  }
}
