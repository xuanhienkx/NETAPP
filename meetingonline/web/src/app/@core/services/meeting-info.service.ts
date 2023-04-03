import { Injectable } from '@angular/core';
import { Meeting, MeetingStatus } from '../models/meeting.model';
import { Permission } from '../utils/auth-constant';
import { transformStringToArray } from '../utils/utils';
import { isNullOrUndefined } from 'util';
import { AppStateProvider } from './app-state.provider';
import { filter, takeWhile } from 'rxjs/operators';
import { ApiService } from './api.service';
import { ConfirmationDialogService } from './confirmation-dialog.service';

const meetingKey = '__v_I_p__';

@Injectable({
    providedIn: 'root'
})
export class MeetingInfoService {
    private currentMeeting: Meeting;
    constructor(
        private appState: AppStateProvider,
        private api: ApiService,
        private confirm: ConfirmationDialogService
    ) {
    }

    get meeting(): Meeting {
        if (isNullOrUndefined(this.currentMeeting)) {
            const content = sessionStorage.getItem(meetingKey);
            if (content) {
                this.currentMeeting = JSON.parse(content);
            }
        }
        return this.currentMeeting;
    }

    set meeting(meeting: Meeting) {
        this.currentMeeting = meeting;
        this.updateStorage();
        this.appState.meeting$.next(this.currentMeeting);
        this.appState.meetingSummary$.next(this.currentMeeting?.summary);
    }

    updateStorage() {
        sessionStorage.removeItem(meetingKey);
        if (!isNullOrUndefined(this.currentMeeting)) {
            sessionStorage.setItem(meetingKey, JSON.stringify(this.currentMeeting));
        }
    }

    canAccess(permission: string | string[]): boolean {

        if (isNullOrUndefined(this.meeting)) {
            return false;
        }
        if (this.meeting?.isOwner) {
            return true;
        }

        if (this.meeting?.userRoles) {
            const permissions = transformStringToArray(permission);
            if (this.meeting.userRoles.every(r => permissions?.includes(r.name))) {
                return true;
            } else {
                const meetingRolsPermissions = this.meeting.userRoles?.map(x => x.permissions)?.reduce((ps, it) => [...ps, ...it]);
                const rolsPermissions = meetingRolsPermissions?.filter((elem, index, self) => {
                    return index === self.indexOf(elem);
                });

                if (meetingRolsPermissions.length > 0 && permissions.length > 0) {
                    return permissions.every(x => rolsPermissions?.includes(x));
                }
            }


        } else {
            return false;
        }
    }

    // change meeting status from Started to Lock
    lockMeetingHolderList() {
        const sTitle = MeetingStatus[MeetingStatus.Lock].toLowerCase();
        if (!this.canLockMeetingHolderList) {
            this.appState.message$.next({
                msg: `meeting.${sTitle}.invalid`,
                title: `meeting.${sTitle}.title`,
                type: 1
            });
            return;
        }
        this.changeMeetingStatus(MeetingStatus.Lock);
    }

    get canLockMeetingHolderList(): boolean {
        return this.currentMeeting?.status === MeetingStatus[MeetingStatus.Started];
    }

    // change status from Lock to Open
    openMeetingSession() {
        const sTitle = MeetingStatus[MeetingStatus.Open].toLowerCase();
        if (!this.canOpenMeetingSession) {
            this.appState.message$.next({
                msg: `meeting.${sTitle}.invalid`,
                title: `meeting.${sTitle}.title`,
                type: 1
            });
            return;
        }
        this.changeMeetingStatus(MeetingStatus.Open);
    }

    get canOpenMeetingSession(): boolean {
        return this.currentMeeting?.status === MeetingStatus[MeetingStatus.Lock]
            && this.canAccess(Permission[Permission.meeting_open_session]);
    }

    // change status from Open to Lock
    closeMeetingSession() {
        const sTitle = MeetingStatus[MeetingStatus.Close].toLowerCase();
        if (!this.canCloseMeetingSession) {
            this.appState.message$.next({
                msg: `meeting.${sTitle}.invalid`,
                title: `meeting.${sTitle}.title`,
                type: 1
            });
            return;
        }
        this.changeMeetingStatus(MeetingStatus.Close);
    }

    get canCloseMeetingSession(): boolean {
        return this.currentMeeting?.status === MeetingStatus[MeetingStatus.Open];
    }

    private changeMeetingStatus(status: MeetingStatus) {
        const sTitle = MeetingStatus[status].toLowerCase();
        this.confirm.confirm(`meeting.${sTitle}.confirm`)
            .then((confirm) => {
                if (confirm === true) {
                    this.api.patchToReturn<string>(`meeting/${this.currentMeeting?.id}/state/${sTitle}`)
                        .subscribe((res) => {
                            status = status === MeetingStatus.Lock ? MeetingStatus.Locking : status;
                            this.currentMeeting.status = MeetingStatus[status];
                            this.updateStorage();
                            this.appState.meeting$.next(this.currentMeeting);
                            this.appState.message$.next({
                                msg: `meeting.${sTitle}.success`,
                                title: `meeting.${sTitle}.title`
                            });

                            if (res !== '') {
                                const self = this;
                                this.appState.hfMessage$
                                    .pipe(
                                        takeWhile(() => this.currentMeeting != null),
                                        filter(m => m.id === res)
                                    ).subscribe(m => {
                                        if (self.currentMeeting?.status === MeetingStatus[MeetingStatus.Locking]) {
                                            self.currentMeeting.status = MeetingStatus[MeetingStatus.Lock];
                                            this.updateStorage();
                                            this.appState.meeting$.next(this.currentMeeting);
                                        }
                                        self.appState.message$.next({ msg: m.data, isTranslated: true, type: 3 });
                                    });
                            }
                        });
                }
            });
    }
}
