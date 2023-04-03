import { TranslateLoader } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppSettings } from '../utils/app-constants';

export class LocaleLoaderService implements TranslateLoader {
  private constructor(private httpClient: HttpClient) {
  }

  private static instance: LocaleLoaderService;
  private currentPath: string;
  private urlLoaded: string;

  public static Factory(httpClient: HttpClient): TranslateLoader {
    if (!this.instance) {
      this.instance = new LocaleLoaderService(httpClient);
    }

    return this.instance;
  }

  setRequestRoute(route: string): boolean {
    let path: string;
    switch (route) {
      case AppSettings.MEETING.Path:
      case AppSettings.ADMIN.Path:
        path = route;
        break;
      case AppSettings.ERROR.Path:
      case AppSettings.AUTH.Path:
        path = 'page';
        break;
      default:
        path = 'home';
    }
    if (this.currentPath !== path) {
      this.currentPath = path;
      return true;
    }
    return false;
  }

  getTranslation(lang: string): Observable<any> {
    if (!this.currentPath) {
      this.currentPath = 'home';
    }

    const url = './assets/locale/' + this.currentPath + '.content.' + lang + '.json';

    if (url !== this.urlLoaded) {
      this.urlLoaded = url;
      return this.httpClient.get(url);
    }
  }
}
