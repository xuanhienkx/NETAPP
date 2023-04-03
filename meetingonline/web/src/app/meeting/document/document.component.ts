import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { MediaForDel } from 'src/app/@core/models/common';
import { NbDialogService } from '@nebular/theme';
import { DocumentDialogComponent } from './document-dialog/document-dialog.component';
import { environment } from 'src/environments/environment';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { MeetingInfo, ElectionMatter } from 'src/app/@core/models/meeting.model';
import { takeUntil } from 'rxjs/operators';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { Observable, of } from 'rxjs';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';
import { MeetingBaseComponent } from '../shares/meeting-base.component';
@Component({
  selector: 'vip-meeting-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss']
})

export class MeetingDocumentComponent extends MeetingBaseComponent {


  filtered$: Observable<MeetingInfo[]>;

  docUrl: string;
  viewType: string;
  constructor(
    meetingInfo: MeetingInfoService,
    appState: AppStateProvider,
    private fb: FormBuilder,
    private dialogService: NbDialogService,
    private notifier: NotificationService,
    private confirm: ConfirmationDialogService,
    private api: ApiService
  ) {
    super(appState, meetingInfo);

    this.viewType = environment.documentViewType;

  }
  
  protected onMeetingLoaded() {
    this.filtered$ = of(this.mt?.contents);
  }

  onChangeList(value: string) {
    this.filtered$ = of(this.mt?.contents.filter(x => x.name?.toLowerCase()?.includes(value?.toLowerCase())));
  }

  editInfo(info?: MeetingInfo) {
    const dlgRef = this.dialogService.open(DocumentDialogComponent,
      {
        context:
        {
          mt: this.mt,
          info,
          canEdit: this.canContentEdit
        }
      });

    dlgRef.componentRef.instance.meetingInfoAdd$
      .pipe(takeUntil(dlgRef.onClose)
      ).subscribe((m: MeetingInfo) => {
        const idx = this.mt?.contents.findIndex(x => x.id === m.id);
        if (idx !== -1) {
          this.mt.contents[idx] = m;
        } else {
          this.mt?.contents.push(m);
        }
        this.filtered$ = of(this.mt?.contents);
        this.meetingInfo.updateStorage();
        this.appState.meeting$.next(this.mt);
      });

    dlgRef.componentRef.instance.meetingMatterAdd$
      .pipe(takeUntil(dlgRef.onClose)
      ).subscribe((m: ElectionMatter) => {
        const idx = this.mt?.electionMatters.findIndex(x => x.id === m.id);
        if (idx !== -1) {
          this.mt.electionMatters[idx] = m;
        } else {
          this.mt?.electionMatters.push(m);
        }

        this.meetingInfo.updateStorage();
        this.appState.meeting$.next(this.mt);
      });

  }

  delete(doc: MeetingInfo, idx: number) {
    this.confirm.confirm('document.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/info/${doc.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              this.mt?.contents.splice(idx, 1);
              this.meetingInfo.updateStorage();
              this.appState.meeting$.next(this.mt);

              this.filtered$ = of(this.mt?.contents);
              this.notifier.success('document.delete.success', 'document.delete.title', true);
            }
          });

        }
      });
  }

  deleteFile(data: MediaForDel) {

    this.confirm.confirm('document.file.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/info/${data?.contentId}/attachment/${data.fileId}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              const doc = this.mt?.contents.find(x => x.id === data.contentId);
              const rIdx = doc.attachments?.findIndex(x => x.id === data.fileId);
              if (rIdx !== -1) {
                doc.attachments?.splice(rIdx, 1);
              }

              this.meetingInfo.updateStorage();
              this.appState.meeting$.next(this.mt);
              this.filtered$ = of(this.mt?.contents);
              this.notifier.success('document.file.delete.success', 'document.file.delete.title', true);
            }
          });
        }
      });
  }
}
