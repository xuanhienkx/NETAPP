import { Component, AfterViewInit, ElementRef } from '@angular/core';
import { ListBaseComponent } from 'src/app/@theme/components/list/list-base.component';
import { DelegateRequestGroup, DelegateRequest } from 'src/app/@core/models/delegate-request.model';
import { ApiService } from 'src/app/@core/services/api.service';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { takeWhile } from 'rxjs/operators';
import { Meeting, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { Observable } from 'rxjs';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'vip-delegate',
  templateUrl: './delegate.component.html',
  styleUrls: ['./delegate.component.scss']
})
export class DelegateComponent extends ListBaseComponent<DelegateRequestGroup> implements AfterViewInit {


  selectedItem: DelegateRequest;
  private mt: Meeting;

  constructor(
    private api: ApiService,
    private appState: AppStateProvider,
    private meetingInfo: MeetingInfoService,
    private confirm: ConfirmationDialogService,
    private notifier: NotificationService
  ) {
    super();
    this.showScroll = true;

    const self = this;

    this.appState.meeting$.pipe(takeWhile(() => this.isOnAir))
      .subscribe(m => {
        if (m) {
          self.mt = m;
          self.appState.meetingSummary$.next(m.summary);
          self.loadNext();
        }
      });
  }

  protected eq(me: DelegateRequestGroup, you: DelegateRequestGroup): boolean {
    return me.mandator?.id === you.mandator?.id;
  }

  protected load(pageIndex: number, pageSize: number): Observable<DelegateRequestGroup[]> {
    let url = `delegateRequest/${this.mt?.id}/admin/${pageIndex}/${pageSize}`;
    if (this.searchText && this.searchText !== '') {
      url = `${url}?searchText=${this.searchText}`;
    }
    return this.api.getObject<DelegateRequestGroup[]>(url);
  }

  protected onItemAdded(item: DelegateRequestGroup) { }
  protected onItemDeleted(item: DelegateRequestGroup) { }
  protected onItemEdited(old: DelegateRequestGroup, item: DelegateRequestGroup) { }

  ngAfterViewInit(): void {
    if (this.meetingInfo.meeting) {
      this.appState.meeting$.next(this.meetingInfo.meeting);
    }
  }

  setActive(item: DelegateRequest) {
    this.selectedItem = item;

  }
  get isOpenMessing() {
    return this.mt?.status === MeetingStatus[MeetingStatus.Open];
  }


  canResponse(item: DelegateRequest) {
    return this.isOpenMessing
      && (!isNullOrUndefined(item.delegation.requestedDate)
        && isNullOrUndefined(item.delegation.approvedDate)
        && isNullOrUndefined(item.delegation.rejectedDate)
      );

  }
  approvalDelegation(item: DelegateRequest, isApprove: boolean, idx2: number) {
    const url = `delegaterequest/admin-response`;
    const body: any = {
      id: item.id,
      isApprove
    };

    // reject
    if (!isApprove) {
      this.confirm.confirmWithConfig({ message: 'delegate.delegation.reject.confirm', config: { requiredNote: true } })
        .then((confirm) => {
          if (confirm.isConfirm === true) {
            body.message = confirm.message;
            this.api.patchToReturn<DelegateRequest>(url, body).subscribe(rs => {
              if (rs) {
                item.delegation = rs.delegation;
                this.notifier.success('delegate.delegation.reject.success', null, true);
              }
            });
          }
        });
    } else {
      this.api.patchToReturn<DelegateRequest>(url, body).subscribe(rs => {
        if (rs) {
          item.delegation = rs.delegation;
          this.items[idx2].mandator.blockedVotes += rs.delegation.votes;
          this.items[idx2].mandator.availableVotes -= rs.delegation.votes;
          this.notifier.success('delegate.delegation.approval.success', null, true);
        }
      });
    }
  }

  delete(idx: number, item: DelegateRequest) {
    this.confirm.confirm('delegate.delegation.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `delegateRequest/${item.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              this.items.splice(idx, 1);
              this.mt.summary.votes -= item.delegation.votes;
              const items: DelegateRequestGroup = {
                mandator: item.mandator,
                requests: [item]
              };
              this.notifier.success('delegate.delegation.delete.success', 'delegate.delegation.delete.title', true);
            }
          });
        }
      });
  }
}
