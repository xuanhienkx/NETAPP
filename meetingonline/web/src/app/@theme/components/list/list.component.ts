import { Component, OnInit, Input, HostListener, Output, EventEmitter } from '@angular/core';
import { SubjectedEditorService } from 'src/app/@core/services/subjected-editor.service';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'vip-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  private destroy$ = false;

  @Input() id: string;
  @Input() title: string;
  @Input() items: any[];
  @Input() pageSize = 13;

  @Output() itemsLoad: EventEmitter<any> = new EventEmitter<any>();

  pageToLoadNext = 0;
  pageEnd = -1;
  isLoading = false;
  showScroll: boolean;
  showScrollHeight = 50;
  hideScrollHeight = 10;

  constructor(subjected: SubjectedEditorService) {
    const self = this;
    subjected.content$.pipe(takeWhile(() => this.destroy$ === false))
      .subscribe(r => {
        if (r.name === self.id) {
          self.isLoading = false;
          if (r.value.length > 0) {
            self.items.push(...r.value);
            this.pageToLoadNext++;
          } else {
            this.pageEnd = this.pageToLoadNext;
          }
        }
      });
  }

  ngOnInit(): void {
  }

  loadNext() {
    if (this.isLoading || (this.pageEnd > 0 && this.pageToLoadNext === this.pageEnd)) {
      return;
    }

    if (this.pageToLoadNext > 0) {
      this.showScroll = true;
    } else {
      this.showScroll = false;
    }

    this.isLoading = true;
    this.itemsLoad.emit({ page: this.pageToLoadNext, size: this.pageSize });
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    if ((window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop) > this.showScrollHeight) {
      this.showScroll = true;
    } else if (this.showScroll
      && (window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop)
      < this.hideScrollHeight) {
      this.showScroll = false;
    }
  }

  scrollToTop() {
    window.scroll(0, 0);
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; //
  }
}
