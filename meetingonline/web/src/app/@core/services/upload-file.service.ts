import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadFileService {
  public readonly upload$: Subject<void> = new Subject<void>();
  public readonly reset$: Subject<void> = new Subject<void>();
  constructor() { }
}
