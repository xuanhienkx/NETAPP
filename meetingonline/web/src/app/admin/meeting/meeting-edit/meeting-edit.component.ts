import { Component, OnInit, Input } from '@angular/core';
import { NbDateService } from '@nebular/theme';
import { Meeting, MeetingType, MeetingStatus, } from 'src/app/@core/models/meeting.model';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GetRoute, Route, AppSettings } from 'src/app/@core/utils/app-constants';
import { ApiService } from 'src/app/@core/services/api.service';
import { NotificationService } from 'src/app/@core/services/notification.service';
import { UserInfoService } from 'src/app/@core/services/user-info.service';
import { MeetingGroup } from 'src/app/@core/models/user.model';
import { TranslateService } from '@ngx-translate/core';
import { localizeEnum, GetMediaUrl } from 'src/app/@core/utils/utils';
import { Occurrence, Media } from 'src/app/@core/models/common';
import { Subject } from 'rxjs';
import { SubjectedEditorService } from 'src/app/@core/services/subjected-editor.service';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'vip-meeting-edit',
  templateUrl: './meeting-edit.component.html',
  styleUrls: ['./meeting-edit.component.scss']
})
export class MeetingEditComponent implements OnInit {
  private headerContent: Subject<string> = new Subject<string>();
  min: Date;
  max: Date;
  groups: MeetingGroup[] = [];
  frm: FormGroup;
  submitted = false;
  @Input() title: string;
  selectedItemFormControl = new FormControl();
  mt: Meeting;
  meetingTypes: any[];
  meetingTypeName: string;
  isHeader: boolean;
  isFooter: boolean;
  constructor(
    localizer: TranslateService,
    protected dateService: NbDateService<Date>,
    private fb: FormBuilder,
    private api: ApiService,
    private notifier: NotificationService,
    protected userInfo: UserInfoService,
    private router: Router,
    private routeActive: ActivatedRoute,
    private subjected: SubjectedEditorService
  ) {
    this.isHeader = true;
    this.isFooter = false;
    localizeEnum(MeetingType, 'enum.MeetingType', localizer)
      .subscribe(types => this.meetingTypes = types);
  }

  bidingData() {
    this.frm = this.fb.group({
      id: [null],
      name: ['', [Validators.required]],
      description: [],
      address: ['', [Validators.required, Validators.minLength(11)]],
      groupId: [],
      type: [MeetingType.GeneralMeeting],
      openedDate: [null, Validators.required],
      logo: [],
      header: [],
      footer: []
    });
  }

  changeHeaderFooter() {
    this.isHeader = !this.isHeader;
    this.isFooter = !this.isFooter;
  }

  ngOnInit(): void {
    this.groups = this.userInfo.user.meetingGroups;
    this.min = this.dateService.today();
    this.max = this.dateService.addMonth(this.dateService.today(), 3);
    this.routeActive
      .queryParams
      .subscribe(params => {
        if (params.id) {
          this.getMeeting(params.id);
        }
      });

    this.bidingData();
  }

  getMeeting(id: string) {
    this.api.getObject<Meeting>(`meeting/${id}`).subscribe(res => {
      res.openedDate = (res.openedDate as Occurrence)?.value;
      this.frm.patchValue(res);
      this.mt = res;

      if (this.meetingTypes) {
        this.meetingTypeName = this.meetingTypes[MeetingType[res.type]].name;
      } else {
        this.meetingTypeName = res.type.toString();
      }
      if (!this.canEdit) {
        this.frm.disable();
      }
    });
  }

  get canEdit() {
    return isNullOrUndefined(this.mt) || (this.mt?.isOwner
      && (
        MeetingStatus[MeetingStatus.Close] !== this.mt.status
        && MeetingStatus[MeetingStatus.Open] !== this.mt.status));
  }

  get f() {
    return this.frm.controls;
  }

  onSubmit(): void {
    const url = 'meeting';
    const mt = this.frm.value as Meeting;
    mt.type = MeetingType[this.f.type.value];

    if (mt.id) {
      this.api.putToReturn<Meeting>(url, mt).subscribe((r) => {
        if (r) {
          this.notifier.success('meeting.edit.success', 'meeting.edit.title', true);
        }
      });

    } else {
      this.api.postToReturn<Meeting>(url, mt).subscribe((r) => {
        if (r) {
          this.f.id.setValue(r.id);
          this.notifier.success('meeting.add.success', 'meeting.add.title', true);
        }
      });
    }
  }

  close() {
    this.router.navigate([GetRoute(AppSettings.MEETING_SETTING)]);
  }

  copyFromGroup(cmd: string) {
    const group = this.groups.find(x => x.id === this.f.groupId.value);
    if (cmd === 'logo') {
      this.f.logo.setValue(group.logo);
    } else if (cmd === 'header') {
      this.subjected.content$.next({ name: cmd, value: group.header });
      this.f.header.setValue(group.header);
    } else {
      this.subjected.content$.next({ name: cmd, value: group.footer });
      this.f.footer.setValue(group.footer);
    }
  }

  route(route: Route) {
    return GetRoute(route);
  }

  getUrl(media: Media) {
    return GetMediaUrl(media);
  }

  getFiles(inputFile: any) {
    if (inputFile.files && inputFile.files.length > 0) {
      const file = inputFile.files[0]; // only allow one file

      const media = this.f.logo.value;
      this.api.uploadFile(file).subscribe(res => {
        if (res !== null) {
          if (media != null) {
            // delete old one
            this.api.deleteFile(media.id);
          }
          this.frm.controls.logo.setValue(res);
        }
      });
    }
  }

  open(v: string) {

  }

  keyupHandlerFooterFunction(e) {
    this.f.footer.setValue(e);
  }

  keyupHandlerHeaderFunction(e) {
    this.f.header.setValue(e);
  }
}
