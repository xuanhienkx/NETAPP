import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LocaleLoaderService } from './@core/services/locale-loader.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import {
  NbDatepickerModule,
  NbMenuModule,
  NbSidebarModule,
  NbToastrModule,
  NbWindowModule,
  NbIconModule,
} from '@nebular/theme';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { ThemeModule } from './@theme/theme.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpInterceptorService, DEFAULT_TIMEOUT } from './@core/services/http-interceptor.service';
import { NgxMaskModule } from 'ngx-mask';
import { environment } from 'src/environments/environment';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';

export function getAuthServiceConfigs() {
  return new AuthServiceConfig(
    [
      {
        id: FacebookLoginProvider.PROVIDER_ID,
        provider: new FacebookLoginProvider(environment.socialLoginProvider.facebook.clientId)
      },
      {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider(environment.socialLoginProvider.google.clientId)
      }
    ]
  );
}

const nbModels = [
  NbIconModule,
  NbSidebarModule.forRoot(),
  NbMenuModule.forRoot(),
  NbDatepickerModule.forRoot(),
  NbWindowModule.forRoot(),
  NbToastrModule.forRoot(),
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ...nbModels,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    SocialLoginModule,
    ThemeModule.forRoot(),
    NgxMaskModule.forRoot(),
    TranslateModule.forRoot({
      defaultLanguage: 'vi',
      loader: {
        provide: TranslateLoader,
        useFactory: LocaleLoaderService.Factory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true },
    { provide: DEFAULT_TIMEOUT, useValue: 1000 },
    { provide: AuthServiceConfig, useFactory: getAuthServiceConfigs }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
