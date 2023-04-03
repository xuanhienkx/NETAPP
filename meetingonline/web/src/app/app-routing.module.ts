import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { NavigationGuard } from './@core/services/navigation.guard';
import { AppSettings } from './@core/utils/app-constants';

export const routes: Routes = [
  {
    path: AppSettings.HOME.Path,
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    canActivate: [NavigationGuard]
  },
  {
    path: AppSettings.ADMIN.Path,
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    data: { breadcrumb: AppSettings.ADMIN.Path },
    canActivate: [NavigationGuard]
  },
  {
    path: AppSettings.MEETING.Path,
    loadChildren: () => import('./meeting/meeting.module').then(m => m.MeetingManageModule),
    data: { breadcrumb: AppSettings.MEETING.Path },
    canActivate: [NavigationGuard]
  },
  {
    path: AppSettings.AUTH.Path, loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
    canActivate: [NavigationGuard]
  },
  {
    path: AppSettings.ERROR.Path,
    loadChildren: () => import('./@theme/error/system-error-page.module').then(m => m.SystemErrorPageModule)
  },
  {
    path: '**', redirectTo: AppSettings.HOME.Path, pathMatch: 'full'
  }
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
