import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Person } from 'src/app/@core/models/meeting.model';
@Component({
  selector: 'vip-account-info-item',
  templateUrl: './account-info-item.component.html',
  styleUrls: ['./account-info-item.component.scss']
})
export class AccountInfoItemComponent implements OnInit {

  @Input() index: number;
  @Input() accountInfo: Person;
  @Input() public allowEdit = true;

  @Output() itemSelect = new EventEmitter<Person>();
  constructor() { }

  ngOnInit(): void {
  }

  edit(info: Person) {
    this.itemSelect.emit(info);
  }
}
