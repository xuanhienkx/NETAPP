import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from '../profile/profile.component';
import { UserListComponent } from './user-list/user-list.component';
import { UsersComponent } from './user.component';
import { UserEditComponent } from './user-edit/user-edit.component';


const routes: Routes = [
  {
    path: '', component: UsersComponent ,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },
      { path: 'list', component: UserListComponent, data: { breadcrumb: 'List' } },
      { path: 'edit', component: UserEditComponent, data: { breadcrumb: 'Edit' } }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
