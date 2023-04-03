import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Meeting, MeetingStatus } from 'src/app/@core/models/meeting.model';
import { Route, GetRoute, AppSettings } from 'src/app/@core/utils/app-constants';
import { Router } from '@angular/router';
import { MeetingInfoService } from 'src/app/@core/services/meeting-info.service';
import { Media, Pair } from 'src/app/@core/models/common';
import { GetMediaUrl } from 'src/app/@core/utils/utils';
import { MeetingRole } from 'src/app/@core/models/meeting-role.model';
import { isNumber, isString, isNullOrUndefined } from 'util';

@Component({
  selector: 'vip-meeting-list',
  templateUrl: './meeting-list.component.html',
  styleUrls: ['./meeting-list.component.scss']
})
export class MeetingListComponent implements OnInit {


  urlRoute = AppSettings;
  @Input() meetings: Meeting[] = [];
  @Input() meetingStatus: Pair<MeetingStatus>[] = [];
  @Output() deleteMeeting = new EventEmitter<string>();
  @Output() changeMeetingStatus = new EventEmitter<any>();

  constructor(private router: Router, private meetingInfo: MeetingInfoService) { }

  ngOnInit(): void {
  }

  route(route: Route) {
    return GetRoute(route);
  }

  delete(id: string) {
    this.deleteMeeting.emit(id);
  }

  gotoMeeting(meeting: Meeting) {
    // this.meetingInfo.getMeeting(meeting.id);
    this.router.navigate([this.route(this.urlRoute.MEETING_INFO)], { queryParams: { id: meeting.id } });
  }

  changeStatus(id: string, status: MeetingStatus) {
    this.changeMeetingStatus.emit({ id, status });
  }

  enum(e: string) {
    return MeetingStatus[e];
  }

  getStatus(status: MeetingStatus | string) {
    if (isNullOrUndefined(this.meetingStatus)) {
      return;
    }

    if (isString(status) || isNumber(status)) {
      status = MeetingStatus[status];
    }
    return this.meetingStatus[status].name;
  }

  getUrl(media: Media) {
    return GetMediaUrl(media);
  }

  buildRoles(roles: MeetingRole[]): string {
    if (roles) {
      return roles.map(x => x.name).join('|');
    }
  }
  canEdit(mt: Meeting) {
    return  mt.isOwner && (MeetingStatus[MeetingStatus.Close] !== mt.status && MeetingStatus[MeetingStatus.Open] !== mt.status);
  }
}
