import { Injectable, Inject, InjectionToken } from '@angular/core';
import { HttpErrorResponse, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Router, RouterStateSnapshot } from '@angular/router';
import { GetRoute, AppSettings } from '../utils/app-constants';
import { UserInfoService } from './user-info.service';
import { AppStateProvider } from './app-state.provider';

export const DEFAULT_TIMEOUT = new InjectionToken<number>('defaultTimeout');

@Injectable({
  providedIn: 'root'
})
export class HttpInterceptorService implements HttpInterceptor {
  private requests: HttpRequest<any>[] = [];
  public errorMessage: any = {};
  public preventAbuse = false;
  snapshot: RouterStateSnapshot;
  isNotLoading = false;
  constructor(
    @Inject(DEFAULT_TIMEOUT)
    protected defaultTimeout: number,
    private router: Router,
    private userInfo: UserInfoService,
    private appState: AppStateProvider,
  ) {
    this.snapshot = this.router.routerState.snapshot;
  }

  removeRequest(req: HttpRequest<any>) {
    const i = this.requests.indexOf(req);
    if (i >= 0) {
      this.requests.splice(i, 1);
    }
  }


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = this.wrapHeaders(req);
    this.requests.push(req);
    return Observable.create(observer => {
      const subscription = next.handle(req)
        .subscribe(
          event => {
            if (event instanceof HttpResponse) {
              observer.next(event);
            }
          },
          err => {
            this.handlerResponseError(err, req.url);
            observer.error(err);
          },
          () => {
            observer.complete();
          });

      // remove request from queue when cancelled
      return () => {
        this.removeRequest(req);

        if (this.requests.length === 0) {
          setTimeout(() => this.appState.spinner$.next(false), 100);
        }

        subscription.unsubscribe();
      };
    });
  }

  handlerResponseError(error: any, requestUrl: string) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      this.appState.message$.next({ msg: `An error occurred: ${error.error.message}`, type: 2 });
    }
    switch (error.status) {
      case 0:
        this.appState.message$.next({ msg: 'errors.ERR_CONNECTION_REFUSED', type: 2 });
        break;
      case 401:
      case 403:
        const extras = {
          queryParams: {
            returnUrl: this.snapshot.url
          }
        };
        this.userInfo.user = null;
        this.router.navigate([GetRoute(AppSettings.SIGNIN)], extras)
          .then(() => {
            this.appState.message$.next({ msg: 'errors.invalidToken', type: 2 });
          });

        break;
      case 404:
      case 405:
      case 500:
        this.appState.message$.next({ msg: error.message, isTranslated: true, type: 2 });
        break;
      case 400:
        this.handleOtherError(error);
        break;
      default:
        this.preventAbuse = false;
        this.router.navigate([GetRoute(AppSettings.ERROR)], { queryParams: { error: error.status, message: error.message } });
    }

    this.appState.spinner$.next(false);
  }

  wrapHeaders(req: HttpRequest<any>) {
    const contentType = req.headers.get('Content-Type');
    if (!contentType) {
      req = req.clone({ headers: req.headers.set('Content-Type', 'application/json') });
    } else if (contentType === 'undefined') {
      this.isNotLoading = true;
      req = req.clone({ headers: req.headers.delete('Content-Type'), reportProgress: true });
    }

    if (this.userInfo.user) {
      req = req.clone(
        {
          headers: req.headers
            .set('Authorization', 'Bearer ' + this.userInfo.user.token)
            .set('Accept-Language', this.userInfo.user.language)
        }
      );
    }

    return req.clone(
      {
        headers: req.headers
          .set('Accept', '*/*')
          .set('Access-Control-Expose-Headers', 'Access-Control-*')
          .set('Access-Control-Allow-Origin', '*')
          .set('Access-Control-Allow-Methods', ' POST, GET, OPTIONS, DELETE, PUT')
          // tslint:disable-next-line: max-line-length
          .set('Access-Control-Allow-Headers', ' X-Requested-With, Content-Type, Origin, Authorization, Accept, Client-Security-Token, Accept-Encoding, X-Auth-Token, content-type')
      });
  }

  pushMessage(key) {
    this.appState.message$.next({ msg: key });
  }

  private handleOtherError(error: HttpErrorResponse) {
    let msgErrors = '';
    const validationErrorDictionary = error.error.errors;
    for (const fieldName in validationErrorDictionary) {
      if (validationErrorDictionary.hasOwnProperty(fieldName)) {
        const err = validationErrorDictionary[fieldName][0];
        msgErrors += `${err} \n`;
      }
    }

    this.appState.message$.next({ msg: msgErrors, isTranslated: true, type: 2 });
  }
}

