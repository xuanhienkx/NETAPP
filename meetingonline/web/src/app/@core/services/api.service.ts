import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, OperatorFunction } from 'rxjs';
import { map } from 'rxjs/operators';
import { Media, Result } from '../models/common';
import { AppStateProvider } from './app-state.provider';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient, private appState: AppStateProvider) { }

  public get(route: string, showSpinner: boolean = true) {
    return this.http.get(this.createCompleteRoute(route, showSpinner));
  }

  public post(route: string, body?: any, showSpinner: boolean = true) {

    return this.http.post(this.createCompleteRoute(route, showSpinner), body);
  }

  public put(route: string, body?: any, showSpinner: boolean = true) {
    return this.http.put(this.createCompleteRoute(route, showSpinner), body);
  }

  public patch(route: string, body?: any, showSpinner: boolean = true) {
    return this.http.patch(this.createCompleteRoute(route, showSpinner), body);
  }

  public delete(route: string, showSpinner: boolean = true) {
    return this.http.delete(this.createCompleteRoute(route, showSpinner));
  }

  getObject<T>(route: string, showSpinner: boolean = true): Observable<T> {
    return this.http.get(this.createCompleteRoute(route, showSpinner))
      .pipe<T>(this.handle());
  }

  postToReturn<T>(route: string, body?: any, showSpinner: boolean = true) {
    return this.http.post(this.createCompleteRoute(route, showSpinner), body)
      .pipe<T>(this.handle());
  }

  putToReturn<T>(route: string, body?: any, showSpinner: boolean = true) {
    return this.http.put(this.createCompleteRoute(route, showSpinner), body)
      .pipe<T>(this.handle());
  }

  patchToReturn<T>(route: string, body?: any, showSpinner: boolean = true) {
    return this.http.patch(this.createCompleteRoute(route, showSpinner), body)
      .pipe<T>(this.handle());
  }

  deleteToReturn<T>(route: string, showSpinner: boolean = true) {
    return this.http.delete(this.createCompleteRoute(route, showSpinner))
      .pipe<T>(this.handle());
  }

  fileUploaderUpload(file: File, showSpinner: boolean = false) {
    const formData = new FormData();
    formData.append(file.name, file);

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'undefined' }),
      reportProgress: true
    };

    const uploadReq = new HttpRequest('POST', this.createCompleteRoute('resource/upload', showSpinner), formData, httpOptions);
    return this.http.request(uploadReq);
  }

  uploadFile(file: File, showSpinner: boolean = false) {
    const formData = new FormData();
    formData.append('file', file);

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'undefined' })
    };

    return this.http.post(this.createCompleteRoute('resource/upload', showSpinner), formData, httpOptions)
      .pipe<Media>(this.handle<Media>());
  }

  uploadManyFile(files: File[], showSpinner: boolean = false) {
    const formData = new FormData();
    for (const file of files) {
      formData.append('file[]', file);
    }
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'undefined' })
    };

    return this.http.post(this.createCompleteRoute('resource/upload/many', showSpinner), formData, httpOptions)
      .pipe<Media[]>(this.handle<Media[]>());
  }

  deleteFile(id: string) {
    return this.deleteToReturn<boolean>(`resource/${id}`).subscribe();
  }

  private createCompleteRoute(route: string, showSpinner: boolean) {
    // Not spinner when upload file
    if (showSpinner) {
      this.appState.spinner$.next(true);
    }

    return `${environment.endpoint}/${route}`;
  }

  private handle<T>(): OperatorFunction<Result<T>, T> {
    return map((result: Result<T>) => {
      if (result.succeeded) {
        return result.value;
      }

      this.appState.message$.next({ msg: result.errors.join('. '), type: 2 });
      return null;
    });
  }
}
