import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Permission } from '../utils/auth-constant';
import { Pair } from '../models/common';

@Injectable({
  providedIn: 'root'
})
export class SubjectedEditorService {

  public readonly content$: Subject<Pair<any>> = new Subject<Pair<any>>();

}
