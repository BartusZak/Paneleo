import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { GenericList } from 'src/app/_models/generic-list';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/_services/Product/product.service';
import { PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  // @Input() data: Array<GenericList<any>>;
  @Input() name: string;
  @Input() columns: Array<string>;
  // listProps: Array<string> = [];
  loading = true;
  data: PaginatedResult<any>;
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
    // this.route.data.subscribe(data => {
    //   this.data = data[this.name];
    //   console.log(data[this.name]);
    // });
  }

  setPage(atrib) {
    this.loading = true;
    console.log(atrib);
    this.productService
      .getProducts(atrib.limit, ++atrib.offset)
      .subscribe(pagedData => {
        console.log(pagedData);
        this.data = pagedData;
        this.loading = false;
      });
  }
}
