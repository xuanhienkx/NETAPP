import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable, } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { LocaleLoaderService } from './locale-loader.service';
import { UserRole, Permission } from 'src/app/@core/utils/auth-constant';
import { GetRoute, AppSettings, Route } from '../utils/app-constants';
import { UserInfoService } from './user-info.service';
import { AuthResult, MessageExtras } from '../models/common';
import { AppStateProvider } from './app-state.provider';

@Injectable({
  providedIn: 'root'
})
export class NavigationGuard implements CanActivate {
  constructor(
    private localizer: TranslateService,
    private router: Router,
    private appState: AppStateProvider,
    private userInfo: UserInfoService) { }

  navigate(route: Route, ex?: MessageExtras) {
    return this.router.navigate([GetRoute(route)], ex?.extras)
      .then(() => {
        if (ex?.message) {
          this.appState.message$.next(ex.message);
        }
      });
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const currentPath = route.routeConfig.path;

    if (currentPath === AppSettings.ADMIN.Path || currentPath === AppSettings.MEETING.Path) {
      const result = this.checkRoute(state.url);
      // console.log('NavigationGuard access [' + state.url + '] -> ' + result.succeed);

      if (!result.succeed) {
        if (result.hasUserLogin) {
          this.navigate(AppSettings.ERROR, { message: { msg: 'errors.permission_retricted' } });
        } else {
          this.navigate(AppSettings.AUTH);
        }
        return true;
      }
    }

    const loader = this.localizer.currentLoader as LocaleLoaderService;
    const requestReset = loader.setRequestRoute(currentPath);
    if (requestReset) {
      this.localizer.reloadLang(this.localizer.currentLang);
    }

    return true;
  }

  checkRoute(url: string): AuthResult {
    url = url + '/';
    const roles: string[] = [];
    const permissions: string[] = [];

    Object.getOwnPropertyNames(AppSettings).forEach(name => {
      const route = AppSettings[name] as Route;
      if (route.Allow && url.indexOf('/' + route.Path + '/') > -1) {
        if (route.Allow.Role) {
          route.Allow.Role.forEach(r => {
            const role = UserRole[r];
            if (!roles.find(x => x === role)) {
              roles.push(role);
            }
          });
        }
        if (route.Allow.Access) {
          route.Allow.Access.forEach(p => {
            const perm = Permission[p];
            if (!permissions.find(x => x === perm)) {
              permissions.push(perm);
            }
          });
        }
      }
    });

    const res = this.userInfo.isInRoles(roles);
    if (!res.succeed) {
      return res;
    }

    return this.userInfo.hasPermissions(permissions);
  }
}
