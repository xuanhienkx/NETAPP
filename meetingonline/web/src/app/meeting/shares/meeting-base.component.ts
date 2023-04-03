import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { Subject } from 'rxjs';
import { OnDestroy, AfterViewInit } from '@angular/core';
import { Meeting, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { takeUntil } from 'rxjs/operators';

export abstract class MeetingBaseComponent implements OnDestroy, AfterViewInit {
    protected destroy$: Subject<void> = new Subject<void>();

    constructor(
        protected appState: AppStateProvider,
        protected meetingInfo: MeetingInfoService,
    ) {
        const self = this;
        this.appState.meeting$.pipe(
            takeUntil(self.destroy$)
        ).subscribe(m => {
            self.appState.meetingSummary$.next(m?.summary);
            self.onMeetingLoaded();
        });
    }

    protected abstract onMeetingLoaded();

    public get mt(): Meeting {
        return this.meetingInfo.meeting;
    }

    ngAfterViewInit(): void {
        if (this.meetingInfo.meeting) {
            this.appState.meeting$.next(this.meetingInfo.meeting);
        }
    }

    ngOnDestroy(): void {
        this.destroy$?.next();
        this.destroy$?.complete();
    }

    get canContentEdit() {
        return this.mt?.status !== MeetingStatus[MeetingStatus.Open] && this.mt?.status !== MeetingStatus[MeetingStatus.Close];
    }

    // change meeting status from Started to Lock
    lockMeetingHolderList() {
        this.meetingInfo.lockMeetingHolderList();
    }

    get canLockMeetingHolderList(): boolean {
        return this.meetingInfo.canLockMeetingHolderList;
    }

    // change status from Lock to Open
    openMeetingSession() {
        this.meetingInfo.openMeetingSession();
    }

    get canOpenMeetingSession(): boolean {
        return this.meetingInfo.canOpenMeetingSession;
    }

    // change status from Open to Lock
    closeMeetingSession() {
        this.meetingInfo.closeMeetingSession();
    }

    get canCloseMeetingSession(): boolean {
        return this.meetingInfo.canCloseMeetingSession;
    }
}
