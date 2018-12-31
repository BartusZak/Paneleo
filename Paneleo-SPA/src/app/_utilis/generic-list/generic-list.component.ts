import { Component, OnInit, Input } from '@angular/core';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Product, ProductForOrder } from 'src/app/_models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  @Input() getData: any;
  @Input() name: string;
  @Input() columns: Array<string>;
  @Input() onRowClick: any;
  loading = true;
  data: PaginatedResult<any>;
  constructor(private router: Router) {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
  }

  setPage(atrib) {
    this.loading = true;
    this.getData(atrib).subscribe(pagedData => {
      this.data = pagedData;
      this.loading = false;
    });
  }

  onActivate(event) {
    if (event.type === 'click') {
      this.onRowClick(event.row.id);
    }
  }
}
