import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
 
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { CustomerComponent } from './components/customer/customer.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component'; 
import { StatusPipe } from './cores/pipes/status.pice';
import { PagerService } from './cores/services/pager.service';
import { SortService } from './cores/services/sort.service ';
import { SortableColumnComponent } from './shares/sorttable.column.component';
import { SortableTableDirective } from './cores/sortable-table.directive';
 
import { ModalModule } from 'ngx-bootstrap/modal';
@NgModule({
    declarations: [
        StatusPipe,
        AppComponent,
        NavMenuComponent,
        CustomerComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        SortableTableDirective,
        SortableColumnComponent
    ],
    providers: [
        PagerService, SortService
    ],
    imports: [ 
        CommonModule,
        HttpModule,
        FormsModule,
        FormsModule,
        ModalModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'customer', component: CustomerComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})


export class AppModuleShared {
}
