import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './user.component';
import { ThemeModule } from '../../@theme/theme.module';
import { SharedModule } from 'src/app/@core/shared.module';
import { UsersRoutingModule } from './user-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { UserEditComponent } from './user-edit/user-edit.component'; 

@NgModule({
  declarations: [UsersComponent, UserListComponent, UserEditComponent],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    UsersRoutingModule, 
  ], schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class UsersModule { }
