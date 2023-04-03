import { TranslateService } from '@ngx-translate/core';
import { NbMenuItem, NbIconConfig } from '@nebular/theme';
import { UserRole, Permission } from './auth-constant';
import { NavigationGuard } from '../services/navigation.guard';

class AppRouteSettings {
    HOME: Route = {
        Path: '',
    };
    //#region Admin Route
    ADMIN: Route = {
        Path: 'admin',
        Icon: 'grid-outline'
    };
    DASHBOARD: Route = {
        Icon: {
            icon: 'desktop',
            pack: 'solid'
        },
        Path: 'dashboard',
        Parent: this.ADMIN,
    };
    USERS: Route = {
        Path: 'users',
        Parent: this.ADMIN,
    };
    PROFILE: Route = {
        Path: 'profile',
        Icon: {
            icon: 'user',
            pack: 'regular'
        },
        Parent: this.ADMIN,
    };
    SETTINGS: Route = {
        Path: 'settings',
        Icon: 'settings-2-outline',
        Parent: this.ADMIN,
        Allow: {
            Role: [UserRole.ADMIN],
        }
    };
    MEETING_ROLE: Route = {
        Path: 'meeting-role',
        Icon: 'people-outline',
        Parent: this.SETTINGS,
        Allow: {
            Role: [UserRole.ADMIN],
        }
    };
    MEETING_ROLE_EDIT: Route = {
        Path: 'edit',
        Parent: this.MEETING_ROLE,
        Allow: {
            Role: [UserRole.ADMIN],
        }
    };
    MEETING_SETTING: Route = {
        Icon: 'options-2-outline',
        Path: 'meeting',
        Parent: this.ADMIN,
    };
    MEETING_LIST: Route = {
        Icon: 'undo-outline',
        Path: 'meeting',
        Parent: this.ADMIN,
    };
    MEETING_EDIT: Route = {
        Path: 'edit',
        Parent: this.MEETING_SETTING,
    };
    MEETING_GROUP: Route = {
        Icon: {
            icon: 'object-group',
            pack: 'solid'
        },
        Path: 'meeting-group',
        Parent: this.ADMIN,
    };
    MEETING_GROUP_EDIT: Route = {
        Path: 'edit',
        Parent: this.MEETING_GROUP,
    };
    //#endregion

    //#region Auth Route

    AUTH: Route = {
        Path: 'auth',
    };
    SIGNIN: Route = {
        Path: 'signin',
        Parent: this.AUTH,
    };
    SIGNUP: Route = {
        Path: 'signup',
        Parent: this.AUTH,
    };
    FORGOT: Route = {
        Path: 'forgot',
        Parent: this.AUTH,
    };
    VERIFY: Route = {
        Path: 'verify',
        Parent: this.AUTH,
    };
    RESETPASSWORD: Route = {
        Path: 'reset-password',
        Parent: this.AUTH,
    };
    CHANGEPASSWORD: Route = {
        Path: 'change-password',
        Parent: this.AUTH,
    };
    //#endregion
    SUCCESS: Route = {
        Path: 'success',
    };
    ERROR: Route = {
        Path: 'error',
    };
    LOGOUT: Route = {
        Path: 'logout',
    };
    //#endregion Meeting manage route
    MEETING: Route = {
        Path: 'meeting',
    };

    MEETING_DOCUMENT: Route = {
        Path: 'document',
        Icon: 'attach-outline',
        Parent: this.MEETING,
        // Allow: {
        //     Access: [Permission.meeting_manage_documents],
        // }
    };

    MEETING_MATTER: Route = {
        Path: 'matter',
        Icon: 'checkmark-circle-outline',
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_electionmatters],
        }
    };

    MEETING_HOLDER: Route = {
        Path: 'holder',
        Icon: {
            icon: 'address-book',
            pack: 'regular'
        },
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_holders],
        }
    };

    MEETING_ATTENDEE: Route = {
        Path: 'attendee',
        Icon: {
            icon: 'chalkboard-teacher',
            pack: 'solid'
        },
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_votes, Permission.meeting_checkin_attendees],
        }
    };

    MEETING_INFO: Route = {
        Path: 'meeting-info',
        Icon: {
            icon: 'file-alt',
            pack: 'regular'
        },
        Parent: this.MEETING
    };

    MEETING_MEMBER: Route = {
        Path: 'member',
        Icon: 'people-outline',
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_members],
        }
    };

    MEETING_DELEGATE: Route = {
        Path: 'delegate',
        Icon: {
            icon: 'check-double',
            pack: 'solid'
        },
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_delegaterequests],
        }
    };

    MEETING_DELEGATE_INFO: Route = {
        Path: 'delegate-info',
        Icon: {
            icon: 'address-card',
            pack: 'regular'
        },
        Parent: this.MEETING,
        Allow: {
            Role: [UserRole.Viewer],
        }
    };

    MEETING_VOTE: Route = {
        Path: 'vote',
        Icon: {
            icon: 'vote-yea',
            pack: 'solid'
        },
        Parent: this.MEETING,
        Allow: {
            Role: [UserRole.Viewer],
        }
    };
    MEETING_VOTE_RESULT: Route = {
        Path: 'vote-result',
        Icon: {
            icon: 'vote-yea',
            pack: 'solid'
        },
        Parent: this.MEETING,
        Allow: {
            Access: [Permission.meeting_manage_votes, Permission.meeting_manage_reports],
        }
    };
    //#endregion
}

////////////// DONT TOUCH FROM BELOW THIS LINE ///////////////

export interface Route {
    Icon?: string | NbIconConfig;
    Path: string;
    Parent?: Route;
    Allow?: {
        Role?: UserRole[];
        Access?: Permission[];
    };
}

export const AppSettings = new AppRouteSettings();

export function GetRoute(route: Route): string {
    if (!route || route.Path === 'logout') {
        return null;
    }
    if (!route.Path || route.Path === '') {
        return '/';
    }

    return _buildRoute(route.Path, route.Parent);
}

export function GetMenu(rootName: string, routes: Route[], localizer: TranslateService, routeGuard: NavigationGuard): NbMenuItem[] {
    const rootMenu: NbMenuItem = { title: null, children: [] };

    routes.forEach(async route => {
        const itemPath = GetRoute(route);
        const item: NbMenuItem = { title: null, icon: route.Icon, data: itemPath, link: itemPath };
        const result = routeGuard.checkRoute(item.link);

        if (result.succeed) {
            item.title = await localizer.get(`menu.${rootName}.${route.Path}`).toPromise();

            if (route.Parent) {
                const parentPath = GetRoute(route.Parent);
                const parent = _findMenu(parentPath, rootMenu);

                if (parent) {
                    if (!parent.children) {
                        const pClone: NbMenuItem = {
                            title: parent.title,
                            link: parent.link,
                            icon: parent.icon
                        };

                        parent.link = null;
                        parent.children = [pClone, item];

                        // update the parent title
                        parent.title = await localizer.get(`menu.${rootName}.g-${route.Parent.Path}`).toPromise();
                    } else {
                        parent.children.push(item);
                    }
                } else {
                    rootMenu.children.push(item);
                }
            } else {
                rootMenu.children.push(item);
            }
        }
    });

    return rootMenu.children;
}

function _findMenu(url: string, menu: NbMenuItem): NbMenuItem {
    if (menu.data === url) {
        return menu;
    }

    if (menu.children) {
        let result: NbMenuItem;
        menu.children.some(m => {
            result = _findMenu(url, m);
            return result !== null;
        });
        return result;
    }
    return null;
}

function _buildRoute(path: string, route: Route) {
    if (!route) {
        return '/' + path;
    }
    return _buildRoute(route.Path + '/' + path, route.Parent);
}
