import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { NgxEchartsModule } from 'ngx-echarts';
import { MeetingManageRoutingModule } from './meeting-routing.module';
import { MeetingManageComponent } from './meeting.component';
import { MeetingInfoComponent } from './info/info.component';
import {
  NbMenuModule,
  NbStepperModule,
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbInputModule,
  NbListModule,
  NbCardModule,
  NbAutocompleteModule,
  NbDialogModule,
  NbAccordionModule,
  NbToggleModule,
  NbPopoverModule,
  NbCheckboxModule,
  NbSpinnerModule,
  NbDatepickerModule,
  NbBadgeModule,
  NbFormFieldModule,
  NbRadioModule
} from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { SharedModule } from '../@core/shared.module';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserDialogComponent } from './member/user-dialog/user-dialog.component';
import { MemberComponent } from './member/member.component';
import { MemberDialogComponent } from './member/member-dialog/member-dialog.component';
import { HolderComponent } from './holder/holder.component';
import { MeetingDocumentComponent } from './document/document.component';
import { MatterComponent } from './matter/matter.component';
import { DocumentDialogComponent } from './document/document-dialog/document-dialog.component';
import { MatterDialogComponent } from './matter/matter-dialog/matter-dialog.component';
import { ScrollTopService } from '../@core/services/scroll-top.service';
import { AttendeeComponent } from './attendee/attendee.component';
import { VoteComponent } from './vote/vote.component';
import { HolderDialogComponent } from './holder/holder-dialog/holder-dialog.component';
import { NbMomentDateModule } from '@nebular/moment';
import { AttendeeDialogComponent } from './attendee/attendee-dialog/attendee-dialog.component';
import { MeetingSummaryComponent } from './shares/meeting-summary/meeting-summary.component';
import { HolderAutocompleteComponent } from './shares/holder-autocomplete/holder-autocomplete.component';
import { NgxMaskModule } from 'ngx-mask';
import { MeetingSummaryPieComponent } from './shares/meeting-summary-pie/meeting-summary-pie.component';
import { DelegateDialogComponent } from './shares/delegate-dialog/delegate-dialog.component';
import { DelegateInfoComponent } from './delegate/delegate-info/delegate-info.component';
import { AccountInfoItemComponent } from './shares/account-info-item/account-info-item.component';
import { AccountRightInfoComponent } from './shares/account-right-info/account-right-info.component';
import { DelegateComponent } from './delegate/delegate.component';
import { ContentDetailComponent } from './shares/content-detail/content-detail.component';
import { VoteResultComponent } from './vote/vote-result/vote-result.component';
import { VoteConfirmComponent } from './vote/vote-confirm/vote-confirm.component';
import { VotesTotalResultComponent } from './votes-total-result/votes-total-result.component';

const NB_MODULES = [
  NbButtonModule,
  NbSelectModule,
  NbIconModule,
  NbEvaIconsModule,
  NbMenuModule,
  NbStepperModule,
  NbInputModule,
  NbListModule,
  NbCardModule,
  NbDialogModule,
  NbAutocompleteModule,
  NbAccordionModule,
  NbToggleModule,
  NbCheckboxModule,
  NbPopoverModule,
  NbSpinnerModule,
  NbSpinnerModule,
  NbDatepickerModule,
  NbMomentDateModule,
  NbBadgeModule,
  NbFormFieldModule,
  NbRadioModule,
  NbDialogModule.forRoot(),
];

@NgModule({
  declarations: [
    MeetingManageComponent,
    MeetingInfoComponent,
    UserDialogComponent,
    MeetingDocumentComponent,
    MemberComponent,
    MemberDialogComponent,
    HolderComponent,
    DocumentDialogComponent,
    MatterComponent,
    MatterDialogComponent,
    AttendeeComponent,
    VoteComponent,
    HolderDialogComponent,
    AttendeeDialogComponent,
    MeetingSummaryComponent,
    HolderAutocompleteComponent,
    DelegateDialogComponent,
    MeetingSummaryPieComponent,
    DelegateInfoComponent,
    AccountInfoItemComponent,
    AccountRightInfoComponent,
    DelegateComponent,
    ContentDetailComponent,
    VoteResultComponent,
    VoteConfirmComponent,
    VotesTotalResultComponent
  ],
  imports: [
    ...NB_MODULES,
    CommonModule,
    ThemeModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    MeetingManageRoutingModule,
    DragDropModule,
    NgxEchartsModule,
    NgxMaskModule.forChild()
  ],
  providers: [
    ScrollTopService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MeetingManageModule { }
