import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MeetingComponent } from './meeting.component';
import { MeetingEditComponent } from './meeting-edit/meeting-edit.component';
import { AppSettings } from 'src/app/@core/utils/app-constants';


const routes: Routes = [
  { path: '', component: MeetingComponent },
  {
    path: AppSettings.MEETING_EDIT.Path, component: MeetingEditComponent,
    data: { breadcrumb: AppSettings.MEETING_EDIT.Path }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingRoutingModule { }
