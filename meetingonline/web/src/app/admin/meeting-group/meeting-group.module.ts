import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MeetingGroupRoutingModule } from './meeting-group-routing.module';
import { SharedModule } from 'src/app/@core/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ThemeModule } from 'src/app/@theme/theme.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    MeetingGroupRoutingModule,
    ThemeModule
  ]
})
export class MeetingGroupModule { }
