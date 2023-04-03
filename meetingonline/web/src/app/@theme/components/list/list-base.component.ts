import { HostListener, OnDestroy } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { takeWhile } from 'rxjs/operators';
import { GetRoute, Route } from 'src/app/@core/utils/app-constants';

export abstract class ListBaseComponent<T> implements OnDestroy {

    items: T[] = [];
    showScroll = false;

    protected searchText;
    protected pageSize = 12;

    protected itemUpdated$ = new Subject<T>();
    protected itemDeleted$ = new Subject<T>();

    protected isOnAir = true;

    private pageToLoadNext = 0;
    private pageEnd = -1;
    private isLoading = false;
    private showScrollHeight = 50;
    private hideScrollHeight = 10;

    protected abstract eq(me: T, you: T): boolean;
    protected abstract load(pageIndex: number, pageSize: number): Observable<T[]>;
    protected abstract onItemAdded(item: T);
    protected abstract onItemDeleted(item: T);
    protected abstract onItemEdited(old: T, item: T);

    protected constructor() {
        const self = this;

        this.itemUpdated$.pipe(takeWhile(() => this.isOnAir))
            .subscribe(r => {
                if (r) {
                    const idx = self.items.findIndex(x => this.eq(x, r));
                    if (idx !== -1) {
                        const old = self.items[idx];
                        self.onItemEdited(old, r);
                        self.items[idx] = r;
                    } else {
                        self.items.push(r);
                        self.onItemAdded(r);
                    }
                }
            });

        this.itemDeleted$.pipe(takeWhile(() => this.isOnAir))
            .subscribe(r => {
                const idx = self.items.findIndex(x => this.eq(x, r));
                if (idx !== -1) {
                    const del = self.items[idx];
                    self.onItemDeleted(del);

                    self.items.splice(idx, 1);
                }
            });
    }

    ngOnDestroy(): void {
        this.isOnAir = false;
    }

    loadNext(reset: boolean = false) {
        if (reset) {
            this.pageEnd = -1;
            this.pageToLoadNext = 0;
            this.items = [];
        }

        if (this.isLoading
            || (this.pageEnd > 0 && this.pageToLoadNext === this.pageEnd)
            || (this.items.length !== 0 && this.items.length < this.pageSize)) {
            return;
        }

        if (this.pageToLoadNext > 0) {
            this.showScroll = true;
        } else {
            this.showScroll = false;
        }

        this.isLoading = true;
        this.load(this.pageToLoadNext, this.pageSize)
            .subscribe(r => {
                if (this.isLoading) {
                    this.isLoading = false;
                    if (r && r.length > 0) {
                        if (r.length > 0) {
                            const newItems = r.filter(x => this.items.findIndex(i => this.eq(i, x)) < 0);
                            this.items.push(...newItems);
                            this.pageToLoadNext++;
                        } else {
                            this.pageEnd = this.pageToLoadNext;
                        }
                    }
                }
            });
    }

    search(text: string) {
        this.searchText = text;
        this.loadNext(true);
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

    route(route: Route) {
        return GetRoute(route);
    }
}

