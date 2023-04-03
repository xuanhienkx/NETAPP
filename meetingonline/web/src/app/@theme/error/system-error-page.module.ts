import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { SystemErrorPageRoutingModule } from './system-error-page.routing';
import { SystemErrorPageComponent } from './system-error-page.component';
import { NbButtonModule } from '@nebular/theme';



@NgModule({
  declarations: [SystemErrorPageComponent],
  imports: [
    CommonModule,
    TranslateModule,
    NbButtonModule,
    SystemErrorPageRoutingModule
  ]
})
export class SystemErrorPageModule { }
