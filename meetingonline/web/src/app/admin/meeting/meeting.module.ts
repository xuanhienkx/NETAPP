import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MeetingRoutingModule } from './meeting-routing.module';
import { SharedModule } from 'src/app/@core/shared.module';
import { MeetingGroupComponent } from '../meeting-group/meeting-group.component';
import { MeetingGroupEditComponent } from '../meeting-group/meeting-group-edit/meeting-group-edit.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MeetingComponent } from './meeting.component';
import { MeetingEditComponent } from './meeting-edit/meeting-edit.component';
// tslint:disable-next-line:max-line-length
import {
  NbTabsetModule,
  NbListModule,
  NbCheckboxModule, NbIconModule,
  NbDatepickerModule,
  NbSelectModule,
  NbAutocompleteModule,
  NbInputModule,
  NbButtonModule,
  NbStepperModule,
  NbCardModule,
  NbDialogModule,
  NbAccordionModule,
  NbToggleModule,
  NbRadioModule,
  NbActionsModule
} from '@nebular/theme';
import { MeetingListComponent } from './meeting-list/meeting-list.component'; 
import { ThemeModule } from 'src/app/@theme/theme.module';
import { NbEvaIconsModule } from '@nebular/eva-icons';

const NB_MODULES = [
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbEvaIconsModule,
  NbStepperModule,
  NbInputModule,
  NbListModule,
  NbCardModule,
  NbAutocompleteModule,
  NbAccordionModule,
  NbToggleModule,
  NbCheckboxModule, 
  NbDatepickerModule,
  NbTabsetModule,
  NbRadioModule,
  NbActionsModule,
  NbIconModule,
  NbDialogModule.forChild(),

];
@NgModule({
  declarations: [
    MeetingGroupComponent,
    MeetingGroupEditComponent,
    MeetingComponent,
    MeetingEditComponent,
    MeetingListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ...NB_MODULES,
    MeetingRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ThemeModule,
  ]
})
export class MeetingModule { }
