import {
  Component,
  Input,
  ViewChild,
  ElementRef,
  OnChanges,
  AfterViewInit,
  Output,
  EventEmitter
} from '@angular/core';

@Component({
  selector: 'vip-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnChanges, AfterViewInit {
  @Input() tag: string;
  @Input() placeholder: string;

  @ViewChild('searchInput') inputElement: ElementRef<HTMLInputElement>;

  @Output() search = new EventEmitter();
  @Output() searchInput = new EventEmitter();

  constructor() { }

  ngOnChanges() {
    if (this.inputElement) {
      this.inputElement.nativeElement.value = '';
    }

    this.focusInput();
  }

  ngAfterViewInit() {
    // this.focusInput();
  }

  focusInput() {
    if (this.inputElement) {
      this.inputElement.nativeElement.focus();
    }
  }
  submitSearch(term) {
    this.search.emit(term);
  }

  emitSearchInput(term: string) {
    this.searchInput.emit(term);
  }
}
