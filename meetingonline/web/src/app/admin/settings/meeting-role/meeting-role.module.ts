import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MeetingRoleRoutingModule } from './meeting-role-routing.module';
import { MeetingRoleComponent } from './meeting-role.component';
import { MeetingRoleEditComponent } from './meeting-role-edit/meeting-role-edit.component';
import { SharedModule } from 'src/app/@core/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NbToggleModule,
  NbOptionModule,
  NbCheckboxModule,
  NbSelectModule,
  NbListModule,
  NbInputModule,
  NbButtonModule,
  NbCardModule,
  NbMenuModule
} from '@nebular/theme';
import { ThemeModule } from 'src/app/@theme/theme.module';

const NB_MODULES = [
  NbToggleModule,
    NbOptionModule,
    NbCheckboxModule,
    NbSelectModule,
    NbListModule,
    NbInputModule,
    NbButtonModule,
    NbCardModule,
    NbMenuModule
];

@NgModule({
  declarations: [
    MeetingRoleComponent,
    MeetingRoleEditComponent,
  ],
  imports: [
    ...NB_MODULES,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    ThemeModule,
    SharedModule,
    MeetingRoleRoutingModule
  ]
})
export class MeetingRoleModule { }
