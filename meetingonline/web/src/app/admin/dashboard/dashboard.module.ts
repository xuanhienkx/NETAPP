import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from 'src/app/@core/shared.module';
import { NbTabsetModule, NbListModule, NbBadgeModule, NbIconModule } from '@nebular/theme';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    NbTabsetModule,
    NbListModule,
    NbBadgeModule,
    NbIconModule,
    SharedModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
