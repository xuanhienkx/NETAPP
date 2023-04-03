import { Component, OnInit, AfterViewInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { ScriptLoaderService } from '../@core/services/script-loader.service';
import { AnalyticsService } from '../@core/services/analytics.service';
import { SeoService } from '../@core/services/seo.service';
import { AppStateProvider } from '../@core/services/app-state.provider';
import { UserInfoService } from '../@core/services/user-info.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vip-home',
  templateUrl: './home.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy, AfterViewInit {
  constructor(
    private html: ScriptLoaderService,
    private analytics: AnalyticsService,
    private appState: AppStateProvider,
    private userInfo: UserInfoService,
    private seoService: SeoService
  ) {
    const self = this;
    this.logout$ = this.appState.logout$.subscribe({
      next: ex => {
        self.userInfo.user = null;
      }
    });
   }

  private logout$: Subscription;

  ngOnDestroy(): void {
    this.logout$?.unsubscribe();
  }

  ngOnInit(): void {
    this.appState.spinner$.next(true);

    document.body.setAttribute('data-target', '#header');
    document.body.setAttribute('data-spy', 'scroll');
    document.body.setAttribute('data-offset', '100');

    this.analytics.trackPageViews();
    this.seoService.trackCanonicalChanges();
    this.appState.user$.next(this.userInfo.user);
  }

  ngAfterViewInit(): void {
    const seft = this;
    Promise.resolve(this._loadAllStyles())
      .then(() => this._getAllScripts())
      .finally(() => {
        setTimeout(() => {
          this.appState.spinner$.next(false);
        }, 1200);
      });
  }

  _loadAllStyles() {
    this.html.lazyloadStyles([
      /* Vendor CSS */
      '/assets/home/vendor/bootstrap/css/bootstrap.min.css',
      '/assets/home/vendor/fontawesome-free/css/all.min.css',
      '/assets/home/vendor/animate/animate.min.css',
      '/assets/home/vendor/simple-line-icons/css/simple-line-icons.min.css',
      '/assets/home/vendor/owl.carousel/assets/owl.carousel.min.css',
      '/assets/home/vendor/owl.carousel/assets/owl.theme.default.min.css',
      '/assets/home/vendor/magnific-popup/magnific-popup.min.css',

      /* Theme CSS */
      '/assets/home/css/theme.css',
      '/assets/home/css/theme-elements.css',
      /* Demo CSS */
      '/assets/home/css/demo-seo.css',
      /* Skin CSS */
      '/assets/home/css/skins/skin-seo.css'
    ]);
  }

  _getAllScripts(): void {
    this.html.loadScripts([
      /* Vendor */
      '/assets/home/vendor/jquery/jquery.min.js',
      '/assets/home/vendor/jquery.appear/jquery.appear.min.js',
      '/assets/home/vendor/jquery.easing/jquery.easing.min.js',
      '/assets/home/vendor/popper/umd/popper.min.js',
      '/assets/home/vendor/bootstrap/js/bootstrap.min.js',
      '/assets/home/vendor/common/common.min.js',
      '/assets/home/vendor/owl.carousel/owl.carousel.min.js',
      '/assets/home/vendor/magnific-popup/jquery.magnific-popup.min.js',
      '/assets/home/vendor/vide/jquery.vide.min.js',
      '/assets/home/vendor/vivus/vivus.min.js',
      '/assets/home/vendor/kute/kute.min.js',
      '/assets/home/vendor/kute/kute-svg.min.js',

      /* Theme Base, Components and Settings */
      '/assets/home/js/theme.js',
      /* Demo */
      '/assets/home/js/demo-seo.js',
      /* Theme Initialization Files*/
      '/assets/home/js/theme.init.js',
    ]);
  }
}
