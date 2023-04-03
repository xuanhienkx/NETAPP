import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'vip-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  constructor() {

  }
  public users: any[];
  // source: LocalDataSource = new LocalDataSource();
  public pageIndex = 1;
  public pageSize = 20;
  public pageDisplay = 10;
  public totalRow: number;

  // Mook data

  data = [
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    },
    {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }, {
      UserName: 'phapnx',
      FullName: 'Nguyen Xuan PHap',
      Email: 'Sincere@april.biz',
      PhoneNumber: '123456789',
      Avatar: ''
    }

  ];
  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
  ngOnInit(): void {
    this.totalRow = this.data.length;
    this.loadData();
  }
  loadData() {
    this.pageIndex = 1;
    const begin = ((this.pageIndex - 1) * this.pageSize);
    const end = begin + this.pageSize;
    this.users = this.data.slice(begin, end);
  }
  setRowCountChange(value: number): void {
    this.pageSize = value;
    this.loadData();

  }
  pageChanged(page: number): void {
    this.pageIndex = page;
    this.loadData();
  }
  setAddNew() {

  }
}
