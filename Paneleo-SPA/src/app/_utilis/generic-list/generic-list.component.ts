import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/_models/product';
import { GenericList } from 'src/app/_models/generic-list';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/_services/Product/product.service';
import { PaginatedResult } from 'src/app/_models/pagination';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';

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
    private productService: ProductService,
    private contractorService: ContractorService
  ) {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
    // this.route.data.subscribe(data => {
    //   // this.data = data[this.name];
    //   console.log(data);
    // });
  }

  setPage(atrib) {
    this.loading = true;
    if (this.name === '1') {
      this.productService
        .getProducts(atrib.limit, ++atrib.offset)
        .subscribe(pagedData => {
          this.data = pagedData;
          this.loading = false;
        });
    } else {
      this.contractorService
        .getContractors(atrib.limit, ++atrib.offset)
        .subscribe(pagedData => {
          this.data = pagedData;
          this.loading = false;
        });
    }
  }
}
