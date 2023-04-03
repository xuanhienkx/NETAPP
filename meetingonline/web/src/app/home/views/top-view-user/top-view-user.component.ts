import { Component, OnDestroy } from '@angular/core';
import { LoggedInUser } from 'src/app/@core/models/user.model';
import { AppSettings, Route, GetRoute } from 'src/app/@core/utils/app-constants';
import { Media } from 'src/app/@core/models/common';
import { GetMediaUrl } from 'src/app/@core/utils/utils';
import { Subject } from 'rxjs';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { isNullOrUndefined } from 'util';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'vip-top-view-user',
  templateUrl: './top-view-user.component.html',
  styleUrls: ['./top-view-user.component.scss']
})
export class TopViewUserComponent implements OnDestroy {
  private destroy$: Subject<void> = new Subject<void>();

  user: LoggedInUser;
  urlRoute = AppSettings;

  constructor(private appState: AppStateProvider) {
    const self = this;
    this.appState.user$.pipe(
      takeUntil(this.destroy$)
    ).subscribe(u => self.user = u);
  }

  get isLoggedIn() {
    return !isNullOrUndefined(this.user);
  }

  ngOnDestroy(): void {
    this.destroy$?.next();
    this.destroy$?.complete();
  }

  logout() {
    this.appState.logout$.next();
  }

  route(route: Route) {
    return GetRoute(route);
  }

  getUrl(media: Media) {
    return GetMediaUrl(media);
  }
}
