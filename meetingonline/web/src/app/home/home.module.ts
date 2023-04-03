import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { HomeHeaderComponent } from './home-header/home-header.component';
import { HomeFooterComponent } from './home-footer/home-footer.component';
import { HomeComponent } from './home.component';
import { IntroComponent } from './views/intro/intro.component';
import { AboutComponent } from './views/about/about.component';
import { SolutionComponent } from './views/solution/solution.component';
import { PriceComponent } from './views/price/price.component';
import { CustomerComponent } from './views/customer/customer.component';
import { NewsComponent } from './views/news/news.component';
import { RegisterComponent } from './views/register/register.component';
import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from '../@core/shared.module';
import { FormRequestComponent } from './views/form-request/form-request.component';
import { CommonModule } from '@angular/common';
import { TopViewUserComponent } from './views/top-view-user/top-view-user.component';
import { AnalyticsModule } from '../@core/analytics.module';


@NgModule({
  declarations: [
    HomeHeaderComponent,
    HomeFooterComponent,
    HomeComponent,
    IntroComponent,
    AboutComponent,
    SolutionComponent,
    PriceComponent,
    CustomerComponent,
    NewsComponent,
    RegisterComponent,
    FormRequestComponent,
    TopViewUserComponent
  ],
  exports: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    HomeRoutingModule,
    AnalyticsModule.forRoot()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HomeModule { }
