import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MeetingGroupComponent } from './meeting-group.component';
import { AppSettings } from '../../@core/utils/app-constants';
import { MeetingGroupEditComponent } from './meeting-group-edit/meeting-group-edit.component';


const routes: Routes = [
  { path: '', component: MeetingGroupComponent },
  {
    path: AppSettings.MEETING_GROUP_EDIT.Path, component: MeetingGroupEditComponent,
    data: { breadcrumb: AppSettings.MEETING_GROUP_EDIT.Path }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingGroupRoutingModule { }
