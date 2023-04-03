import { Component, OnInit, Input, EventEmitter, OnDestroy, HostListener } from '@angular/core';
import { SortService } from '../cores/services/sort.service ';
import { Subscription } from 'rxjs/Subscription'; 
import { ColumnSortedEvent } from '../components/app/models/filter.model';

@Component({
    selector: '[sortable-column]',
    templateUrl: './sortable.column.component.html'
})
export class SortableColumnComponent implements OnInit {
    @Input('sortable-column') columnName: string='';

    @Input('sort-direction') sortDirection: string = '';

    private columnSortedSubscription: Subscription;
    constructor(private sortService: SortService) {
        this.columnSortedSubscription = new Subscription();
    }

   

    @HostListener('click')
    sort() {
        this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
        this.sortService.columnSorted(new ColumnSortedEvent(this.columnName, this.sortDirection));
    }

    ngOnInit() {
        // subscribe to sort changes so we can react when other columns are sorted
        this.columnSortedSubscription = this.sortService.columnSorted$.subscribe(event => {
            // reset this column's sort direction to hide the sort icons
            if (this.columnName != event.fieldName) {
                this.sortDirection = '';
            }
        });
    }

    ngOnDestroy() {
        this.columnSortedSubscription.unsubscribe();
    }
}