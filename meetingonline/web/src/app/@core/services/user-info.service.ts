import { Injectable } from '@angular/core';
import { transformStringToArray } from '../utils/utils';
import { LoggedInUser } from '../models/user.model';
import { UserRole, Permission } from '../utils/auth-constant';
import { AuthResult } from '../models/common';
import { MeetingInfoService } from './meeting-info.service';
import { AppStateProvider } from './app-state.provider';
import { isNullOrUndefined } from 'util';

const CURRENT_LOGIN_USER = '__c_u_s_r__';

@Injectable({
  providedIn: 'root'
})
export class UserInfoService {
  private loginUser: LoggedInUser;

  constructor(
    private appState: AppStateProvider,
    private meetingInfo: MeetingInfoService
  ) {
  }

  loadLoginUserInfo() {
    // load user from store
    const localStorageloginUser = localStorage.getItem(CURRENT_LOGIN_USER);
    if (localStorageloginUser) {
      this.loginUser = JSON.parse(localStorageloginUser);
      this.appState.user$.next(this.loginUser);
    }
  }

  get user(): LoggedInUser {
    return this.loginUser;
  }

  set user(user: LoggedInUser) {
    this.loginUser = user;
    this.appState.user$.next(this.loginUser);

    // store user info
    localStorage.removeItem(CURRENT_LOGIN_USER);
    if (user !== null) {
      localStorage.setItem(CURRENT_LOGIN_USER, JSON.stringify(user));
    }
  }

  isInRoles(role?: string | string[]): AuthResult {
    if (isNullOrUndefined(this.user)) {
      return new AuthResult(false, false);
    }

    if (!role || (Array.isArray(role) && role.length === 0)) {
      return new AuthResult(true);
    }

    if (isNullOrUndefined(this.user)) {
      return new AuthResult(false, false);
    }

    if (this.loginUser.role && this.loginUser.role === UserRole[UserRole.MODERATOR]) {
      return new AuthResult(true, true);
    }

    role = transformStringToArray(role);
    if (role.find(r => r === this.loginUser.role)) {
      return new AuthResult(true, true);
    }

    if (this.meetingInfo.canAccess(role)) {

      return new AuthResult(true, true);

    }
    
    return new AuthResult(false, true);
  }

  hasPermissions(permission?: string | string[]): AuthResult {
    if (!permission || (Array.isArray(permission) && permission.length === 0)) {
      return new AuthResult(true);
    }

    if (isNullOrUndefined(this.user)) {
      return new AuthResult(false, false);
    }

    if (this.loginUser.role && this.loginUser.role === UserRole[UserRole.MODERATOR]) {
      return new AuthResult(true, true);
    }

    permission = transformStringToArray(permission);

    if (this.loginUser.permisions) {
      permission.forEach(p => {
        if (!this.loginUser.permisions.includes(Permission[p])) {
          return new AuthResult(false, true);
        }
      });
    }

    if (this.meetingInfo.canAccess(permission)) {

      return new AuthResult(true, true);

    }

    return new AuthResult(false, true);
  }
}
