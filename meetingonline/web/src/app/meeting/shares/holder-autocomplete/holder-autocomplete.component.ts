import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, Subject, of } from 'rxjs';
import { Holder } from 'src/app/@core/models/meeting.model';
import { isNullOrUndefined } from 'util';
import { uriEscape, notEmptyValue, convertToBoolProperty, VipBooleanInput } from 'src/app/@core/utils/utils';
import { takeUntil, filter, map } from 'rxjs/operators';
import { ApiService } from 'src/app/@core/services/api.service';

@Component({
  selector: 'vip-holder-autocomplete',
  templateUrl: './holder-autocomplete.component.html',
  styleUrls: ['./holder-autocomplete.component.scss']
})
export class HolderAutocompleteComponent implements OnInit, OnDestroy {
  private readonly destroy$: Subject<void> = new Subject<void>();
  @Input()
  get checkAvailable(): boolean {
    return this._checkAvailable;
  }
  set checkAvailable(value: boolean) {
    this._checkAvailable = convertToBoolProperty(value);
  }
  protected _checkAvailable = false;
  // tslint:disable-next-line:member-ordering
  static ngAcceptInputType_checkAvailable: VipBooleanInput;

  @Input() meetingId?: string;
  @Input() placeholdertextKey?: string;
  @Input() holderFindControl?: FormControl;
  @Input() isClearText = false;
  @Input() status?: string;
  @Input() checkRight = false;
  @Input() holdersExten?: string[] = [];

  @Output() holderSelect = new EventEmitter<Holder>();

  filtered$: Observable<Holder[]>;
  search$: Subject<string> = new Subject<string>();
  isQuering = false;

  constructor(
    private api: ApiService) {
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngOnInit(): void {
    if (!this.holderFindControl) {
      this.holderFindControl = new FormControl();
    }
    const self = this;
    this.search$.subscribe(s => {
      if (!isNullOrUndefined(this.meetingId) && !isNullOrUndefined(s) && s?.length >= 2) {


        self.isQuering = true;
        const url = `meeting/${this.meetingId}/holder/10/0?searchText=${uriEscape(s)}`;
        self.api.getObject<Holder[]>(url, false).subscribe(rs => {
          let rsFind: Holder[] = this._checkAvailable ? rs.filter(h => h?.availableVotes > 0) : rs;
          if (!isNullOrUndefined(self.holdersExten)) {
            rsFind = rsFind.filter(x => !this.holdersExten?.includes(x.identityNumber));
          }

          this.filtered$ = of(rsFind);
          self.isQuering = false;
        });
      }
    });

    this.holderFindControl.valueChanges.pipe(
      takeUntil(this.destroy$),
      filter(() => this.isQuering === false),
      map(s => self.search$.next(s)))
      .subscribe();
  }

  onHolderSelected(identityNumber: string) {
    if (identityNumber) {

      this.filtered$.subscribe(hds => {
        const hdSelect = hds?.find(x => x.identityNumber === identityNumber);
        this.isQuering = false;
        if (this.isClearText) {
          this.holderFindControl.reset();
        }
        this.holderSelect.emit(hdSelect);
      });
    }
  }
  searchHolder() {
    if (notEmptyValue(this.holderFindControl.value)) {
      this.search$.next(this.holderFindControl.value);
    }
  }
}
