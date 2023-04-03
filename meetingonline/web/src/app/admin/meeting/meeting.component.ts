import { Component, OnInit, Input, TemplateRef, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { Meeting, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { GetRoute, AppSettings, Route } from 'src/app/@core/utils/app-constants';
import { SafeStyle } from '@angular/platform-browser';
import { NbIconLibraries, NbTabComponent } from '@nebular/theme';
import { FormControl } from '@angular/forms';
import { Observable, of, Subject } from 'rxjs';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { ConfirmationDialogService } from 'src/app/@core/services/confirmation-dialog.service';
import { map, takeUntil } from 'rxjs/operators';
import { Result } from 'src/app/@core/models/common';
import { localizeEnum } from 'src/app/@core/utils/utils';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'vip-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.scss']
})
export class MeetingComponent implements OnInit, OnDestroy {

  private destroy$: Subject<void> = new Subject<void>();

  imageBackgroundStyle: SafeStyle;
  urlRoute = AppSettings;
  @Input() addGroupButton: TemplateRef<any>;
  @Input() addMeetingButton: TemplateRef<any>;


  meetingsOpen: Meeting[];
  meetingsClose: Meeting[];
  meetings: Meeting[];
  @ViewChild('openTab') openTab: NbTabComponent;
  @ViewChild('addGroupButton') addGroupButtonView: ElementRef;

  filteredOptions$: Observable<Meeting[]>;
  options: string[];
  meetingStatus: any[];

  constructor(
    private localizer: TranslateService,
    private iconLibraries: NbIconLibraries,
    private api: ApiService,
    private confirm: ConfirmationDialogService,
    private notifier: NotificationService) {

    this.iconLibraries.registerFontPack('font-awesome', { iconClassPrefix: 'fa' });
    localizeEnum(MeetingStatus, 'enum.MeetingStatus', this.localizer)
      .subscribe(x => {
        this.meetingStatus = x;
      });
  }

  ngOnDestroy(): void {
    this.filteredOptions$ = of(this.meetings);
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnInit(): void {
    this.loadData();
    this.filteredOptions$ = of(this.meetingsOpen);
  }

  route(route: Route) {
    return GetRoute(route);
  }

  loadData() {
    this.api.getObject<Meeting[]>('meeting/all/false').subscribe((res: Meeting[]) => {
      if (res) {
        this.meetings = res;
        this.meetingsOpen = this.meetings.filter(x => !x.closedDate);
        this.meetingsClose = this.meetings.filter(x => x.closedDate);
        this.options = this.meetings?.map<string>(x => x.name);
      }
    });
  }

  onSearch(term: string) {
    if (this.openTab.activeValue) {
      this.meetingsOpen = this.meetings.filter(x => x.name.toLowerCase().includes(term?.toLowerCase()) && !x.closedDate);
    } else {
      this.meetingsClose = this.meetings.filter(x => x.name.toLowerCase().includes(term?.toLowerCase()) && x.closedDate);
    }
  }

  deleteMt(id: string) {
    this.confirm.confirm('meeting.delete.confirm')
      .then((confirm) => {
        if (confirm === true) {
          this.api.delete(`meeting/${id}`).subscribe((res: Result<boolean>) => {
            if (res.succeeded) {
              const idx = this.meetingsOpen.findIndex(g => g.id === id);
              this.meetingsOpen.splice(idx, 1);
              this.notifier.success('meeting.delete.success', 'meeting.delete.title', true);
            } else {
              this.notifier.error(res.errors);
            }
          });
        }
      })
      .catch((e) => console.log(e));
  }

  changeStatus($event: any) {
    this.confirm.confirm('meeting.changeStatus.confirm')
      .then((confirm) => {
        if (confirm === true) {
          this.api.patchToReturn(`meeting/${$event.id}/state/${$event.status}`).subscribe((res: Meeting) => {
            if (res) {
              const idx = this.meetingsOpen.findIndex(x => x.id === res.id);
              this.meetingsOpen[idx] = res;
              this.notifier.success('meeting.changeStatus.success', 'meeting.changeStatus.title', true);
            }
          });
        }
      });
  }
}
