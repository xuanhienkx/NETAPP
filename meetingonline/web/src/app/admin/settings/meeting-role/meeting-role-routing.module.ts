import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppSettings } from 'src/app/@core/utils/app-constants';
import { MeetingRoleEditComponent } from './meeting-role-edit/meeting-role-edit.component';
import { MeetingRoleComponent } from './meeting-role.component';


const routes: Routes = [
  {
    path: '', component: MeetingRoleComponent
  },
  {
    path: AppSettings.MEETING_ROLE_EDIT.Path, component: MeetingRoleEditComponent,
    data: { breadcrumb: AppSettings.MEETING_ROLE_EDIT.Path }
  },
  {
    path: '**', redirectTo: '', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingRoleRoutingModule { }
