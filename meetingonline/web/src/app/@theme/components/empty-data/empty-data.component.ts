import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'vip-empty-data',
  templateUrl: './empty-data.component.html',
  styleUrls: ['./empty-data.component.scss']
})
export class EmptyDataComponent implements OnInit {
  @Input() isNoData = false;
  constructor() { }

  ngOnInit(): void {
  }

}
