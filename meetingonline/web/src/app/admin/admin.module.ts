import { NgModule } from '@angular/core';
import { NbMenuModule } from '@nebular/theme';

import { ThemeModule } from '../@theme/theme.module';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../@core/shared.module';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    AdminRoutingModule,
    ThemeModule,
    NbMenuModule,
    SharedModule,
    CommonModule
  ],
  declarations: [
    AdminComponent
  ],
})
export class AdminModule {
}
