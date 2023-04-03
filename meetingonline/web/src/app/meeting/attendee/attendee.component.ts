import { Component, ViewChild, TemplateRef } from '@angular/core';
import { Attendee, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { NbDialogService } from '@nebular/theme';
import { Observable } from 'rxjs';
import { AttendeeDialogComponent } from './attendee-dialog/attendee-dialog.component';
import { takeUntil } from 'rxjs/operators';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { AppSettings } from 'src/app/@core/utils/app-constants';
import { MeetingListBaseComponent } from '../shares/meeting-list-base.component';
import { Media } from 'src/app/@core/models/common';
import { DocumentViewerComponent } from 'src/app/@theme/components/document-viewer/document-viewer.component';

@Component({
  selector: 'vip-attendee',
  templateUrl: './attendee.component.html',
  styleUrls: ['./attendee.component.scss']
})
export class AttendeeComponent extends MeetingListBaseComponent<Attendee> {

  urlRoute = AppSettings;
  meetingstatus: MeetingStatus;
  delegationCounter: number;
  delegationVotes: number;
  @ViewChild('voteDialog') voteTemplate: TemplateRef<any>;
  @ViewChild('reportOfPrint') reportOfPrint: TemplateRef<any>;

  constructor(
    meetingInfo: MeetingInfoService,
    appState: AppStateProvider,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private notifier: NotificationService,
    private dialogService: NbDialogService
  ) {
    super(appState, meetingInfo);
    this.delegationCounter = this.mt.summary.checkIn ?? 0 - this.mt.summary.holderCheckIn ?? 0;
    this.delegationVotes = this.mt.summary.checkInVotes ?? 0 - this.mt.summary.holderCheckInVotes ?? 0;
  }

  protected load(page: number, pageSize: number): Observable<Attendee[]> {
    let url = `meeting/${this.mt.id}/attendee/${pageSize}/${page}`;
    if (this.searchText && this.searchText !== '') {
      url = `${url}?searchText=${this.searchText}`;
    }
    return this.api.getObject<Attendee[]>(url);
  }

  protected onItemAdded(item: Attendee) {
    this.mt.summary.checkIn += 1;
    this.mt.summary.checkInVotes += item.totalVotes;

    if (item.shares > 0) {
      this.mt.summary.holderCheckIn += 1;
      this.mt.summary.holderCheckInVotes += item.totalVotes;
    }

    this.delegationCounter = this.mt.summary.checkIn ?? 0 - this.mt.summary.holderCheckIn ?? 0;
    this.delegationVotes = this.mt.summary.checkInVotes ?? 0 - this.mt.summary.holderCheckInVotes ?? 0;

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();

    this.appState.meetingSummary$.next(this.mt.summary);
  }

  protected onItemEdited(old: Attendee, item: Attendee) {
    this.mt.summary.checkInVotes = this.mt.summary.checkInVotes - old.totalVotes + item.totalVotes;

    if (item.shares > 0) {
      this.mt.summary.holderCheckInVotes = this.mt.summary.holderCheckInVotes - old.totalVotes + item.totalVotes;
    }

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();

    this.appState.meetingSummary$.next(this.mt.summary);
  }

  protected onItemDeleted(item: Attendee) {
    this.mt.summary.checkIn -= 1;
    this.mt.summary.checkInVotes -= item.totalVotes;

    if (item.shares > 0) {
      this.mt.summary.holderCheckIn -= 1;
      this.mt.summary.holderCheckInVotes -= item.totalVotes;
    }

    this.delegationCounter = this.mt.summary.checkIn - this.mt.summary.holderCheckIn;
    this.delegationVotes = this.mt.summary.checkInVotes - this.mt.summary.holderCheckInVotes;

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();

    this.appState.meetingSummary$.next(this.mt.summary);
    this.notifier.success('attendee.delete.success', 'attendee.delete.title', true);
  }

  showStart(): boolean {
    return this.items.length === 0 && (this.searchText === undefined || this.searchText === '');
  }

  allowConfirm(a: Attendee): boolean {
    return this.mt.status !== MeetingStatus[MeetingStatus.Started] && this.mt.status !== MeetingStatus[MeetingStatus.Close];
  }

  edit(a?: Attendee) {
    const dlgRef = this.dialogService.open(AttendeeDialogComponent, {
      context: {
        mt: this.mt,
        attendee: a
      }
    });

    dlgRef.componentRef.instance.attendeeAdd$
      .pipe(takeUntil(dlgRef.onClose))
      .subscribe((attendee: Attendee) => this.itemUpdated$.next(attendee));
  }

  delete(a: Attendee, idx: number) {
    this.confirm.confirm('attendee.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/attendee/${a.id}`;
          this.api.deleteToReturn<boolean>(url)
            .subscribe(rs => this.itemDeleted$.next(a));
        }
      });
  }

  vote(attendee: Attendee) {
    this.appState.accountSummary$.next(attendee);
    const dlgRef = this.dialogService.open(this.voteTemplate, {
      context: {
        attendee,
        mt: this.mt,
        items: this.mt?.electionMatters ?? []
      }
    });

  }

  printcard(attendee: Attendee, isRePrint?: boolean) {
    if (attendee.reportPrint && !isRePrint) {
      this.dialogService.open(DocumentViewerComponent, {
        context: {
          attachments: attendee.reportPrint
        }
      });
    } else {
      const url = `meeting/${this.mt?.id}/checkin-reports/${attendee.id}`;
      this.api.getObject<Media[]>(url).subscribe(s => {
        attendee.reportPrint = s;
        this.dialogService.open(DocumentViewerComponent, {
          context: {
            attachments: attendee.reportPrint
          }
        });
      });
    }
  }
}
