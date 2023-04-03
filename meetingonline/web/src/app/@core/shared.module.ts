import { NgModule } from '@angular/core';
import { PasswordPatternDirective } from '../@theme/directives/password-pattern.directive';
import { ValidateUserNameDirective } from '../@theme/directives/validate-user-name.directive';
import { MatchPasswordDirective } from '../@theme/directives/match-password.directive';
import { HttpClientModule } from '@angular/common/http';
import { CustomValidationService } from './services/custom-validation.service';
import { TranslateModule } from '@ngx-translate/core';
import { NbToastrModule } from '@nebular/theme';
import { RouterModule } from '@angular/router';
import { AllowAccessDirective } from '../@theme/directives/allow-access.directive';
import { GroupPipePipe } from '../@theme/pipes/group-pipe.pipe';
import { GroupLogoPipe } from '../@theme/pipes/group-logo.pipe';
import { StateService } from './services/state.service';
import { LayoutService } from './services/layout.service';


@NgModule({
  declarations: [
    PasswordPatternDirective,
    ValidateUserNameDirective,
    MatchPasswordDirective,
    AllowAccessDirective,
    GroupPipePipe,
    GroupLogoPipe
  ],
  imports: [
    HttpClientModule,
    TranslateModule,
    RouterModule,
    NbToastrModule.forRoot(),
  ],
  exports: [
    HttpClientModule,
    TranslateModule,
    AllowAccessDirective,
    GroupPipePipe,
    GroupLogoPipe
  ],
  providers: [
    CustomValidationService,
    LayoutService,
    StateService,
  ],

})
export class SharedModule { }
