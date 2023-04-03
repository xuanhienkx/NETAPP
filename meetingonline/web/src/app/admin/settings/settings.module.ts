import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsComponent } from './settings.component';
import { SharedModule } from 'src/app/@core/shared.module';
import { ThemeModule } from 'src/app/@theme/theme.module';

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ThemeModule,
    SettingsRoutingModule
  ]
})
export class SettingsModule { }
