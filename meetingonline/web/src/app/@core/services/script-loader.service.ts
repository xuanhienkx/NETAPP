import { Injectable } from '@angular/core';
import { ReplaySubject, Observable } from 'rxjs';

declare var document: any;

@Injectable({
  providedIn: 'root'
})
export class ScriptLoaderService {
  private loadedLibraries: { [url: string]: ReplaySubject<any> } = {};

  loadScripts(scripts: string[]) {
    scripts.forEach((src) => {
      const script = this.createScript(src, false);
      document.body.appendChild(script);
    });
  }

  loadStyles(styles: string[]) {
    styles.forEach((url) => {
      const style = this.createLink(url);
      const head = document.getElementsByTagName('head')[0];
      head.appendChild(style);
    });
  }

  lazyLoadScripts(scripts: string[]) {
    const promises: any[] = [];
    scripts.forEach((script) => promises.push(this.loadScriptAsync(script)));
    return Promise.all(promises);
  }

  lazyloadStyles(styles: string[]) {
    const promises: any[] = [];
    styles.forEach((style) => promises.push(this.loadStyleAsync(style)));
    return Promise.all(promises);
  }

  private loadScriptAsync(url: string): Observable<any> {
    if (this.loadedLibraries[url]) {
      return this.loadedLibraries[url].asObservable();
    }

    this.loadedLibraries[url] = new ReplaySubject();

    const script = this.createScript(url, true);
    script.onload = () => {
      this.loadedLibraries[url].next();
      this.loadedLibraries[url].complete();
    };

    document.body.appendChild(script);
    return this.loadedLibraries[url].asObservable();
  }

  private loadStyleAsync(url: string): Observable<any> {
    if (this.loadedLibraries[url]) {
      return this.loadedLibraries[url].asObservable();
    }

    this.loadedLibraries[url] = new ReplaySubject();

    const style = this.createLink(url);
    style.onload = () => {
      this.loadedLibraries[url].next();
      this.loadedLibraries[url].complete();
    };

    const head = document.getElementsByTagName('head')[0];
    head.appendChild(style);

    return this.loadedLibraries[url].asObservable();
  }

  private createLink(url: string): any {
    const style = document.createElement('link');
    style.type = 'text/css';
    style.href = url;
    style.rel = 'stylesheet';
    return style;
  }

  private createScript(url: string, async: boolean) {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.async = async;
    script.src = url;
    return script;
  }
}
