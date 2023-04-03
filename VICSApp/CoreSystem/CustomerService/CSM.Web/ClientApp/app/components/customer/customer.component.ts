import { Component, Inject, TemplateRef } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from "@angular/forms";
import { ICustomer, ICustomerResult } from '../app/models/customer.interface';
import { Filter, Criterion, Operator, CriterionType, ColumnSortedEvent } from '../app/models/filter.model';
import { PagerService } from '../../cores/services/pager.service';
import { SortService } from '../../cores/services/sort.service ';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
    selector: 'customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})

export class CustomerComponent {
    private baseUrl: string;
    customers: ICustomer[] = [];
    model: any = {};
    pager: any = {};
    isEdit: boolean = false;
    // paged items
    pagedItems: any[] = [];
    modalRef: BsModalRef;
    operators: any = [
        { name: "bằng [=]", value: Operator.Equals },
        { name: "lớn hơn [>]", value: Operator.GreaterThan },
        { name: "lớn hơn hoặc bằng [>=]", value: Operator.GreaterThanOrEqual },
        { name: "nhỏ hơn [<]", value: Operator.LessThan },
        { name: "nhỏ hơn hoặc bằng [<=]", value: Operator.LessThanOrEqual },
        { name: "khác biệt [!=]", value: Operator.DifferenceOf },
        { name: "có chứa [contains]", value: Operator.Contains }
    ];

    filter = new Filter([
        new Criterion("CustomerId", "Mã khách hàng"),
        new Criterion("Email", "Email", CriterionType.AndAlso)
    ], new ColumnSortedEvent("CustomerId", "asc"));

    constructor(private http: Http, @Inject("BASE_URL", ) baseUrl: string,
        private pagerService: PagerService,
        private modalService: BsModalService,
        private sortService: SortService) {
        this.baseUrl = baseUrl;
        this.model = {};
    }
    openModal(template: TemplateRef<ICustomer>, id?: string) {
        this.model = { isActive: false };
        if (id != undefined) {
            this.isEdit = true;
            this.model = this.customers.find(x => x.customerId === id);
        }
        this.modalRef = this.modalService.show(template);
    }

    findCustomers(page: number = 1) {
        this.filter.pageIndex = page;
        this.http.put(this.baseUrl + 'api/customers/filter', this.filter).subscribe(result => {
            let rs = result.json() as ICustomerResult;
            this.customers = rs.list;
            this.pager = this.pagerService.getPager(rs.totalCount, this.filter.pageIndex, this.filter.pageSize);
        }, error => console.log(error));
        return false;
    }
    onSorted($event: any) {
        this.filter.sortField = $event as ColumnSortedEvent;
        this.findCustomers(this.pager.currentPage);
    }

    onSubmit(form: NgForm) {
        if (form.valid) {
            var cus = this.model as ICustomer;
            if (this.isEdit) {
                this.http.put(this.baseUrl + 'api/customers', cus).subscribe(result => {
                    let rs = result.json() as ICustomer;
                    var old = this.customers.findIndex(x => x.customerId === rs.customerId);
                    if (old > -1) {
                        this.customers.splice(old, 1);
                        this.customers.push(rs);
                    }
                }, error => console.log(error));
            } else {
                this.http.post(this.baseUrl + 'api/customers', cus).subscribe(result => {
                    let rs = result.json() as ICustomer;
                    this.customers.push(rs);
                }, error => console.log(error));
            }
            this.modalRef.hide();
        }
        return false;
    }
    delete(id: string) {
        this.http.delete(this.baseUrl + 'api/customers/'+ id).subscribe(result => {
            let rs = result.json() as boolean;
            if (rs) {
                var index = this.customers.findIndex(x => x.customerId === id);
                if (index > -1) {
                    this.customers.splice(index, 1);
                } 
            }
           
        }, error => console.log(error));
    }
}


