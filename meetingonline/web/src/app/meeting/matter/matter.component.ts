import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ApiService } from 'src/app/@core/services/api.service';
import { NbDialogService } from '@nebular/theme';
import { MediaForDel } from 'src/app/@core/models/common';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ElectionMatter, ElectionOption } from 'src/app/@core/models/meeting.model';
import { MatterDialogComponent } from './matter-dialog/matter-dialog.component';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { takeUntil, map } from 'rxjs/operators';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { MeetingBaseComponent } from '../shares/meeting-base.component';
import { AppStateProvider } from 'src/app/@core/services/app-state.provider';

@Component({
  selector: 'vip-matter',
  templateUrl: './matter.component.html',
  styleUrls: ['./matter.component.scss']
})
export class MatterComponent
  extends MeetingBaseComponent {

  electionMatters: ElectionMatter[];
  docUrl: string;
  constructor(
    meetingInfo: MeetingInfoService,
    appState: AppStateProvider,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private notifier: NotificationService,
    private fb: FormBuilder,
    private dialogService: NbDialogService
  ) {
    super(appState, meetingInfo);

  }

  protected onMeetingLoaded() {
    this.electionMatters = this.meetingInfo.meeting?.electionMatters ?? [];
  }

  editInfo(matter?: ElectionMatter) {
    const dlgRef = this.dialogService.open(MatterDialogComponent,
      {
        context:
        {
          mt: this.mt,
          matter,
          canEdit: (this.canContentEdit || this.mt.isOwner)
        }
      });

    dlgRef.componentRef.instance.meetingMatterAdd$
      .pipe(
        takeUntil(dlgRef.onClose),
        map((m: ElectionMatter) => {
          const idx = this.mt.electionMatters.findIndex(x => x.id === m.id);
          if (idx !== -1) {
            this.mt.electionMatters[idx] = m;
          } else {
            this.mt.electionMatters.push(m);
          }
          this.appState.meeting$.next(this.mt);
          this.meetingInfo.updateStorage();
        })
      )
      .subscribe();
  }



  deleteMember(matterId: string, member: ElectionOption) {
    this.confirm.confirm('matter.form.member.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt.id}/election-matter/${matterId}/option/${member.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              const index = this.mt.electionMatters.findIndex(x => x.id === matterId);
              const idx = this.mt.electionMatters[index].options.findIndex(x => x.id === member.id);

              this.mt.electionMatters[index].options.splice(idx, 1);
              this.appState.meeting$.next(this.mt);
              this.meetingInfo.updateStorage();
              this.notifier.success('matter.form.member.delete.success', 'matter.form.member.delete.title', true);
            }
          });
        }
      })
      .catch((e) => console.log(e));
  }

  delete(doc: ElectionMatter, idx: number) {
    this.confirm.confirm('matter.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/election-matter/${doc.id}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              this.mt.electionMatters.splice(idx, 1);
              this.appState.meeting$.next(this.mt);
              this.meetingInfo.updateStorage();
              this.notifier.success('matter.delete.success', 'matter.delete.title', true);
            }
          });
        }
      })
      .catch((e) => console.log(e));
  }

  deleteFile(data: MediaForDel) {
    this.confirm.confirm('matter.form.file.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          const url = `meeting/${this.mt?.id}/election-matter/${data.contentId}/attachment/${data.fileId}`;
          this.api.deleteToReturn<boolean>(url).subscribe(rs => {
            if (rs) {
              const doc = this.mt.electionMatters.find(x => x.id === data.contentId);
              const rIdx = doc.attachments?.findIndex(x => x.id === data.fileId);
              if (rIdx !== -1) {
                doc.attachments?.splice(rIdx, 1);
              }

              this.appState.meeting$.next(this.mt);
              this.meetingInfo.updateStorage();
              this.notifier.success('matter.form.file.delete.success', 'matter.form.file.delete.title', true);

            }
          });
        }
      })
      .catch((e) => console.log(e));
  }

  itemDroped(event: CdkDragDrop<string[]>) {
    if (!this.canContentEdit) {
      this.notifier.warning('matter.list.dropIndex.errorMessage', 'matter.list.dropIndex.title', true);
      return;
    } else if (event.previousIndex === event.currentIndex) {
      return;
    }

    const matterId = this.electionMatters[event.previousIndex].id;
    const url = `meeting/${this.meetingInfo.meeting.id}/election-matter/${matterId}/index/${event.currentIndex}`;
    this.api.patchToReturn<boolean>(url).subscribe(rs => {
      moveItemInArray(this.electionMatters, event.previousIndex, event.currentIndex);
      this.meetingInfo.meeting.electionMatters = this.electionMatters;
    });
  }

}
