import { Component } from '@angular/core';
import { MeetingBaseComponent } from '../../shares/meeting-base.component';
import { Holder, Attendee } from 'src/app/@core/models/meeting.model';
import { ApiService } from 'src/app/@core/services/api.service';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { NbDialogService } from '@nebular/theme';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { DelegateDialogComponent } from '../../shares/delegate-dialog/delegate-dialog.component';
import { isNullOrUndefined } from 'util';
import { DelegateRequest } from 'src/app/@core/models/delegate-request.model';
import { takeUntil, map } from 'rxjs/operators';
import { MediaForDel } from 'src/app/@core/models/common';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { UserRole } from 'src/app/@core/utils/auth-constant';

@Component({
  selector: 'vip-delegate-info',
  templateUrl: './delegate-info.component.html',
  styleUrls: ['./delegate-info.component.scss']
})
export class DelegateInfoComponent extends MeetingBaseComponent {

  holder: Holder;
  myDelegations: DelegateRequest[] = [];
  mandators: DelegateRequest[] = [];

  totalShared = 0;
  totalDelegated = 0;
  constructor(
    appState: AppStateProvider,
    meetingInfo: MeetingInfoService,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private dialogService: NbDialogService,
    private notifier: NotificationService,
    private userInfo: UserInfoService
  ) {
    super(appState, meetingInfo);
  }

  protected onMeetingLoaded() {
    Promise.resolve(this.loadCurrenHolder())
      .then(() => setTimeout(() => this.loadDelegationInfo(), 200))
      .finally(() => setTimeout(() =>
        this.appState.accountSummary$.next(this.holder), 100));
  }

  private loadCurrenHolder() {
    this.api.getObject<Holder>(`meeting/${this.mt?.id}/current-holder`)
      .subscribe(rs => {
        if (rs) {
          this.holder = rs;
        }
      });
  }

  private loadDelegationInfo() {
    if (this.userInfo.user.role === UserRole[UserRole.MODERATOR] && !this.holder) {
      return;
    }
    this.api.getObject<DelegateRequest[]>(`delegateRequest/${this.mt?.id}/current-user`)
      .subscribe(rs => {
        if (rs) {

          if (this.holder) {
            this.myDelegations = rs.filter(x => x.mandator?.id === this.holder?.id);
            this.mandators = rs.filter(x => x.delegation?.id === this.holder?.id);

            this.totalShared =
              this.myDelegations.length > 0
                ? this.myDelegations?.map(x => x.delegation.votes)?.reduce((t, val) => t + val)
                : 0;

          } else {
            this.mandators = rs;
          }

          this.totalDelegated =
            this.mandators.length > 0
              ? this.mandators?.map(x => x.delegation.votes)?.reduce((t, val) => t + val)
              : 0;

          this.appState.accountSummary$.next(this.holder);
        }

      });
  }

  get canCheckIn() {
    return this.canCloseMeetingSession && !this.canCheckOut && this.holder?.availableVotes > 0;
  }

  checkIn() {
    this.api.patchToReturn<Attendee>(`meeting/${this.mt?.id}/check-in`)
      .subscribe(r => {
        if (r) {
          this.holder.checkedInDate = r.checkedInDate;
          this.holder.availableVotes = 0;
          this.mt.summary.onlineCheckIn += 1;
          this.mt.summary.checkIn += 1;
          this.appState.accountSummary$.next(this.holder);

          this.notifier.success('holder.confirm.success', 'holder.confirm.title', true);
        }
      });
  }

  get canCheckOut() {
    return this.canCloseMeetingSession && !isNullOrUndefined(this.holder?.checkedInDate);
  }

  checkOut() {
    this.api.patchToReturn<Holder>(`meeting/${this.mt?.id}/check-out`)
      .subscribe(r => {
        if (r) {
          console.log('check-out==>', r);
          this.holder = r;
          this.mt.summary.onlineCheckIn -= 1;
          this.mt.summary.checkIn -= 1;
          this.appState.accountSummary$.next(this.holder);
          this.notifier.success('holder.confirm.success', 'holder.confirm.title', true);
        }
      });
  }

  requestDelegate(item: DelegateRequest, index: number) {
    if (!isNullOrUndefined(this.holder.checkedInDate)) {
      return;
    }
    this.api.patchToReturn<DelegateRequest>(`delegateRequest/${item.id}/submit`)
      .subscribe((r: DelegateRequest) => {
        if (r) {
          item.delegation = r.delegation;
          this.notifier.success('holder.confirm.success', 'holder.confirm.title', true);
        }
      });
  }

  get canDelegate() {
    return this.canCloseMeetingSession && this.holder && this.holder?.availableVotes > 0;
  }

  canEdit(item: DelegateRequest) {
    return this.canCloseMeetingSession
      && this.holder
      && isNullOrUndefined(this.holder.checkedInDate)
      && (isNullOrUndefined(item.delegation.requestedDate) || !isNullOrUndefined(item.delegation.rejectedDate));

  }

  edit(item?: DelegateRequest) {
    const identityNumbers = this.myDelegations.map(i => i.delegation?.identityNumber);
    identityNumbers.push(this.holder?.identityNumber);

    const canEdit: boolean = isNullOrUndefined(item) || this.canEdit(item);

    const dlgRef = this.dialogService.open(DelegateDialogComponent,
      {
        context:
        {
          mt: this.mt,
          holder: this.holder,
          delegateRequest: item,
          mtIdentities: identityNumbers,
          canEdit

        }
      });

    dlgRef.componentRef.instance.itemAdd$.pipe(
      takeUntil(dlgRef.onClose),
      map((rs: DelegateRequest) => {

        const index = this.myDelegations.findIndex(x => x.id === rs.id);
        if (index !== -1) {
          this.myDelegations[index] = rs;
          this.holder.availableVotes -= rs.delegation.votes;
          this.holder.delegatingVotes = this.holder.ownedVotes - this.holder.availableVotes + rs.delegation.votes;
          this.holder.blockedVotes = this.holder.ownedVotes - this.holder.availableVotes + rs.delegation.votes;
        } else {
          this.holder.availableVotes -= rs.delegation.votes;
          this.holder.delegatingVotes += rs.delegation.votes;
          this.holder.blockedVotes += rs.delegation.votes;
          this.myDelegations.push(rs);
        }
        this.appState.accountSummary$.next(this.holder);
      })).subscribe();
  }

  delete(idx: number, item: DelegateRequest) {
    this.confirm.confirm('delegateInfo.holder.delegation.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `delegateRequest/${item.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              this.myDelegations.splice(idx, 1);
              this.holder.availableVotes += item.delegation.votes;
              this.holder.delegatingVotes += item.delegation.votes;

              this.appState.accountSummary$.next(this.holder);

              this.notifier.success('delegation.holder.delegation.delete.success', 'delegation.holder.delegation.delete.title', true);
            }
          });
        }
      });
  }

  deleteFile(data: MediaForDel) {

    this.confirm.confirm('document.file.delete.confirm')
      .then(async confirm => {
        if (confirm === true) {
          const body = this.myDelegations.find(x => x.id === data.contentId);
          body.delegation.attachments.splice(data.idx, 1);
          await this.api.postToReturn<DelegateRequest>('delegateRequest', body).toPromise();
        }
      });
  }
}
