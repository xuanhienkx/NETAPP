import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';

import { throwIfAlreadyLoaded } from './utils/module-import-guard';
import { AnalyticsService } from './services/analytics.service';
import { SeoService } from './services/seo.service';


export const NB_ANALYTICS_PROVIDERS = [
  AnalyticsService,
  SeoService,
];

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
  ],
})
export class AnalyticsModule {
  constructor(@Optional() @SkipSelf() parentModule: AnalyticsModule) {
    throwIfAlreadyLoaded(parentModule, 'AnalyticsModule');
  }

  static forRoot(): ModuleWithProviders<AnalyticsModule> {
    return {
      ngModule: AnalyticsModule,
      providers: [
        ...NB_ANALYTICS_PROVIDERS,
      ],
    };
  }
}
