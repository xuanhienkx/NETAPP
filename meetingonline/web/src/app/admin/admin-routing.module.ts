import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { AdminComponent } from './admin.component';
import { SharedModule } from '../@core/shared.module';
import { CommonModule } from '@angular/common';
import { ThemeModule } from '../@theme/theme.module';
import { AppSettings } from '../@core/utils/app-constants';

const routes: Routes = [{
  path: '',
  component: AdminComponent,
  children: [
    {
      path: AppSettings.DASHBOARD.Path,
      loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
      data: { breadcrumb: AppSettings.DASHBOARD.Path }
    },
    {
      path: AppSettings.PROFILE.Path,
      loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule),
      data: { breadcrumb: AppSettings.PROFILE.Path }
    },
    {
      path: AppSettings.USERS.Path,
      loadChildren: () => import('./user/user.module').then(m => m.UsersModule),
      data: { breadcrumb: AppSettings.USERS.Path }
    },
    {
      path: AppSettings.MEETING_SETTING.Path,
      loadChildren: () => import('./meeting/meeting.module').then(m => m.MeetingModule),
      data: { breadcrumb: AppSettings.MEETING_SETTING.Path }
    },
    {
      path: AppSettings.MEETING_GROUP.Path,
      loadChildren: () => import('./meeting-group/meeting-group.module').then(m => m.MeetingGroupModule),
      data: { breadcrumb: AppSettings.MEETING_GROUP.Path }
    },
    {
      path: AppSettings.SETTINGS.Path,
      loadChildren: () => import('./settings/settings.module').then(m => m.SettingsModule),
      data: { breadcrumb: AppSettings.SETTINGS.Path }
    },
    {
      path: '',
      redirectTo: AppSettings.DASHBOARD.Path,
      pathMatch: 'full',
    },
    {
      path: '**',
      redirectTo: AppSettings.DASHBOARD.Path,
      pathMatch: 'full',
    }
  ]
}];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    SharedModule,
    CommonModule,
    ThemeModule
  ],
  exports: [RouterModule],
})
export class AdminRoutingModule {
}
