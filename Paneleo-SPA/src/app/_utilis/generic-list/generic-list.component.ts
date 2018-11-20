import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { GenericList } from 'src/app/_models/generic-list';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  @Input() list: Array<GenericList<any>>;
  @Input() columns: Array<string>;
  listProps: Array<string> = [];
  constructor() {}

  ngOnInit() {
    this.extractColumnsFromObject();
    console.log(this.list);
    console.log(this.columns);
    console.log(this.listProps);
  }

  extractColumnsFromObject() {
    return Object.keys(this.list[0]).forEach(key => {
      this.listProps.push(key);
    });
  }
}
