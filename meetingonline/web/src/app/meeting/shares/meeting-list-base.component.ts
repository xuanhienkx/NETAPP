import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { AfterViewInit } from '@angular/core';
import { Meeting } from 'src/app/@core/models/meeting.model';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { takeWhile } from 'rxjs/operators';
import { ListBaseComponent } from 'src/app/@theme/components/list/list-base.component';
import { Permission } from 'src/app/@core/utils/auth-constant';

export abstract class MeetingListBaseComponent<T extends Partial<{ id: string }>>
    extends ListBaseComponent<T> implements AfterViewInit {

    constructor(
        protected appState: AppStateProvider,
        protected meetingInfo: MeetingInfoService,
    ) {
        super();
        const self = this;
        this.appState.meeting$.pipe(takeWhile(() => this.isOnAir))
            .subscribe(m => {
                // self.onMeetingUpdated();
                self.appState.meetingSummary$.next(m?.summary);

                // load the list
                self.loadNext(true);
            });
    }

    protected eq(me: T, you: T): boolean {
        return me.id === you.id;
    }

    public get mt(): Meeting {
        return this.meetingInfo.meeting;
    }

    ngAfterViewInit(): void {
        if (this.meetingInfo.meeting) {
            this.appState.meeting$.next(this.meetingInfo.meeting);
        }
    }

    // change meeting status from Started to Lock
    lockMeetingHolderList() {
        this.meetingInfo.lockMeetingHolderList();
    }

    get canLockMeetingHolderList(): boolean {
        return this.meetingInfo.canLockMeetingHolderList && this.meetingInfo.canAccess(Permission[Permission.meeting_complete_holders]);
    }

    // change status from Lock to Open
    openMeetingSession() {
        this.meetingInfo.openMeetingSession();
    }

    get canOpenMeetingSession(): boolean {
        return this.meetingInfo.canOpenMeetingSession && this.meetingInfo.canAccess(Permission[Permission.meeting_open_session]);
    }

    // change status from Open to Lock
    closeMeetingSession() {
        this.meetingInfo.closeMeetingSession();
    }

    get canCloseMeetingSession(): boolean {
        return this.meetingInfo.canCloseMeetingSession && this.meetingInfo.canAccess(Permission[Permission.meeting_close_session]);
    }
}
