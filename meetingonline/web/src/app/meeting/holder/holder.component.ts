import { Component, TemplateRef } from '@angular/core';
import { Holder, MeetingStatus, MeetingSummary } from 'src/app/@core/models/meeting.model';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/@core/services/api.service';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { Media } from 'src/app/@core/models/common';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { HolderDialogComponent } from './holder-dialog/holder-dialog.component';
import { takeUntil } from 'rxjs/operators';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { UploadFileService } from 'src/app/@core/services/upload-file.service';
import { NbDialogService, NbDialogRef } from '@nebular/theme';
import { isNullOrUndefined } from 'util';
import { MeetingListBaseComponent } from '../shares/meeting-list-base.component';

@Component({
  selector: 'vip-holder',
  templateUrl: './holder.component.html',
  styleUrls: ['./holder.component.scss']
})
export class HolderComponent extends MeetingListBaseComponent<Holder> {

  private uploadDialog$: NbDialogRef<any>;
  loading = false;

  constructor(
    meetingInfo: MeetingInfoService,
    appState: AppStateProvider,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private notifier: NotificationService,
    private dialogService: NbDialogService,
    private uploadFileService: UploadFileService,
  ) {
    super(appState, meetingInfo);
  }

  protected load(pageIndex: number, pageSize: number): Observable<Holder[]> {
    let url = `meeting/${this.mt?.id}/holder/${pageSize}/${pageIndex}`;
    if (this.searchText && this.searchText !== '') {
      url = `${url}?searchText=${this.searchText}`;
    }
    return this.api.getObject<Holder[]>(url);
  }

  protected onItemAdded(item: Holder) {
    this.mt.summary.holders = this.mt?.summary.holders + 1;
    this.mt.summary.shares = this.mt?.summary.shares + item.shares;
    this.mt.summary.votes = this.mt?.summary.votes + item.ownedVotes;

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();
    this.appState.meetingSummary$.next(this.mt.summary);
  }

  protected onItemEdited(old: Holder, item: Holder) {
    this.mt.summary.shares = this.mt?.summary.shares + item.shares - old.shares;
    this.mt.summary.votes = this.mt?.summary.votes + item.ownedVotes - old.ownedVotes;

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();
    this.appState.meetingSummary$.next(this.mt.summary);
  }

  protected onItemDeleted(item: Holder) {
    this.mt.summary.holders = this.mt?.summary.holders - 1;
    this.mt.summary.shares = this.mt?.summary.shares - item.shares;
    this.mt.summary.votes = this.mt?.summary.votes - item.ownedVotes;

    this.meetingInfo.meeting.summary = this.mt.summary;
    this.meetingInfo.updateStorage();
    this.notifier.success('holder.delete.success', 'holder.delete.title', true);
  }

  get showStart(): boolean {
    return this.items.length === 0 && this.searchText === undefined;
  }

  get allowEdit(): boolean {
    return this.mt?.status === MeetingStatus[MeetingStatus.Started];
  }

  get allowLockList(): boolean {
    return this.canLockMeetingHolderList && this.items?.length > 0;
  }

  allowConfirm(h: Holder): boolean {
    return isNullOrUndefined(h.checkedInDate)
      && this.mt?.status === MeetingStatus[MeetingStatus.Open] && h.availableVotes > 0;
  }

  edit(hd?: Holder, idx?: number) {
    const dlgRef = this.dialogService.open(HolderDialogComponent, {
      context: {
        mt: this.mt,
        hd
      }
    });

    dlgRef.componentRef.instance.holderAdd$
      .pipe(takeUntil(dlgRef.onClose))
      .subscribe((m: Holder) => this.itemUpdated$.next(m));
  }

  delete(hd: Holder, idx: number) {
    this.confirm.confirm('holder.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/holder/${hd.id}`;
          this.api.deleteToReturn<boolean>(url)
            .subscribe(rs => this.itemDeleted$.next(hd));
        }
      });
  }

  confirmAttend(h: Holder) {
    const confirmed = h.confirmedDate ? false : true;
    this.api.patchToReturn<Holder>(`meeting/${this.mt?.id}/holder/${h.id}/attend/${confirmed}`, null, false)
      .subscribe(r => {
        if (r) {
          h.confirmedDate = confirmed ? { value: new Date() } : null;
          // update summary
          this.mt.summary.attendConfirmed += confirmed ? 1 : -1;
          this.mt.summary.confirmedVotes += confirmed ? h.ownedVotes - h.delegatingVotes : h.delegatingVotes - h.ownedVotes;
          if (h.checkedInDate) {
            this.mt.summary.onlineCheckIn += confirmed ? 1 : -1;
          }

          this.meetingInfo.meeting.summary = this.mt.summary;
          this.meetingInfo.updateStorage();
          this.appState.meetingSummary$.next(this.mt.summary);
          this.notifier.success('holder.confirm.success', confirmed ? 'holder.confirm.title' : 'holder.confirm.cancelTitle', true);
        }
      });
  }

  fileUploaderCompleted(media: Media[]) {
    if (media && media.length > 0) {
      const url = `meeting/${this.mt.id}/holder`;
      this.api.postToReturn(url, media[0]).subscribe((rs: MeetingSummary) => {
        if (rs) {
          this.mt.summary = rs;
          this.appState.meetingSummary$.next(rs);

          this.uploadFileService.reset$.next();
          this.uploadDialog$?.close();
          this.uploadDialog$ = null;

          this.meetingInfo.updateStorage();
          this.loadNext(true);
          this.notifier.success('holder.dialog.upload.success', 'holder.dialog.upload.title', true);
        }
      });
    }
  }

  importHolder() {
    this.uploadFileService.upload$.next();
  }

  async onFileChange(event) {
    if (event.target?.files && event.target?.files.length > 0) {
      this.loading = true;
      const file = event.target?.files[0]; // only allow one file
      const media = await this.api.uploadFile(file).toPromise();

      if (media) {
        const url = `meeting/${this.mt?.id}/holder`;
        await this.api.postToReturn(url, media).subscribe((rs: MeetingSummary) => {
          if (rs) {
            this.mt.summary = rs;
            this.appState.meeting$.next(this.mt);
            this.meetingInfo.updateStorage();

            this.notifier.success('holder.dialog.upload.success', 'holder.dialog.upload.title', true);
          }
          this.loading = false;
        }, (e) => {
          console.log(e);
          this.loading = false;
        });
      }
    }
  }

  open(dialog: TemplateRef<any>) {
    this.uploadDialog$ = this.dialogService.open(dialog);
  }
}
