import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MeetingInfoComponent } from './info/info.component';
import { AppSettings } from '../@core/utils/app-constants';
import { MeetingManageComponent } from './meeting.component';
import { MemberComponent } from './member/member.component';
import { MeetingDocumentComponent } from './document/document.component';
import { MatterComponent } from './matter/matter.component';
import { HolderComponent } from './holder/holder.component';
import { AttendeeComponent } from './attendee/attendee.component';
import { DelegateInfoComponent } from './delegate/delegate-info/delegate-info.component';
import { DelegateComponent } from './delegate/delegate.component';
import { VoteComponent } from './vote/vote.component';
import { VotesTotalResultComponent } from './votes-total-result/votes-total-result.component';


const routes: Routes = [
  {
    path: '', component: MeetingManageComponent,
    children: [
      {
        path: AppSettings.MEETING_INFO.Path, component: MeetingInfoComponent,
        data: { breadcrumb: AppSettings.MEETING_INFO.Path }
      },
      {
        path: AppSettings.MEETING_MEMBER.Path, component: MemberComponent,
        data: { breadcrumb: AppSettings.MEETING_MEMBER.Path }
      },
      {
        path: AppSettings.MEETING_DOCUMENT.Path, component: MeetingDocumentComponent,
        data: { breadcrumb: AppSettings.MEETING_DOCUMENT.Path }
      },
      {
        path: AppSettings.MEETING_MATTER.Path, component: MatterComponent,
        data: { breadcrumb: AppSettings.MEETING_MATTER.Path }
      },
      {
        path: AppSettings.MEETING_HOLDER.Path, component: HolderComponent,
        data: { breadcrumb: AppSettings.MEETING_HOLDER.Path }
      },
      {
        path: AppSettings.MEETING_ATTENDEE.Path, component: AttendeeComponent,
        data: { breadcrumb: AppSettings.MEETING_ATTENDEE.Path }
      },
      {
        path: AppSettings.MEETING_DELEGATE.Path, component: DelegateComponent,
        data: { breadcrumb: AppSettings.MEETING_DELEGATE.Path }
      },
      {
        path: AppSettings.MEETING_DELEGATE_INFO.Path, component: DelegateInfoComponent,
        data: { breadcrumb: AppSettings.MEETING_DELEGATE_INFO.Path }
      },
      {
        path: AppSettings.MEETING_VOTE.Path, component: VoteComponent,
        data: { breadcrumb: AppSettings.MEETING_VOTE.Path }
      },
      {
        path: AppSettings.MEETING_VOTE_RESULT.Path, component: VotesTotalResultComponent,
        data: { breadcrumb: AppSettings.MEETING_VOTE_RESULT.Path }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingManageRoutingModule { }
