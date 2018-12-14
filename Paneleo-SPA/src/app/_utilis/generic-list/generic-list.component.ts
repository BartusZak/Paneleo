import { Component, OnInit, Input } from '@angular/core';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Product, ProductForOrder } from 'src/app/_models/product';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  @Input() getData: any;
  @Input() name: string;
  @Input() columns: Array<string>;
  loading = true;
  data: PaginatedResult<any>;
  constructor() {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
  }

  setPage(atrib) {
    this.loading = true;
    if (this.getData == null) {
      const test = {
        currentPage: 1,
        results: [
          {
            actions: '<i class="fa fa-trash" aria-hidden="true"></i>',
            id: 1,
            productName: '',
            quantity: 1,
            unitOfMeasure: 'sztuka',
            pricePerUnit: 0.0,
            totalCost: 0.0
          }
        ],
        totalItemsCount: 1,
        totalPageCount: 1
      };

      this.data = test;
      this.loading = false;
      console.log(this.data);
    } else {
      this.getData(atrib).subscribe(pagedData => {
        console.log(pagedData);
        this.data = pagedData;
        this.loading = false;
      });
    }
  }
}
