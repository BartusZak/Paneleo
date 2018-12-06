import { Component, OnInit, Input } from '@angular/core';
import { PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  @Input() getData: Function;
  @Input() name: string;
  @Input() columns: Array<string>;
  loading = true;
  data: PaginatedResult<any>;
  constructor() {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
  }

  setPage(atrib) {
    this.loading = false;

    this.getData(atrib).subscribe(pagedData => {
      this.data = pagedData;
      this.loading = false;
    });
  }
}
