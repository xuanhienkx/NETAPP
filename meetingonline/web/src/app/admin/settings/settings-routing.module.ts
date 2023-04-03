import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SettingsComponent } from './settings.component';
import { AppSettings } from 'src/app/@core/utils/app-constants';


const routes: Routes = [
  {
    path: '', component: SettingsComponent,
    children: [
      {
        path: AppSettings.MEETING_ROLE.Path,
        loadChildren: () => import('./meeting-role/meeting-role.module').then(m => m.MeetingRoleModule),
        data: { breadcrumb: AppSettings.MEETING_ROLE.Path }
      },
      {
        path: '**',
        redirectTo: '',
        pathMatch: 'full',
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }
