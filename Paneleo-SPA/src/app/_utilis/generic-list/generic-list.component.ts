import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  // @Input() data: Array<GenericList<any>>;
  @Input() getData: Function;
  @Input() name: string;
  @Input() columns: Array<string>;
  // listProps: Array<string> = [];
  loading = true;
  data: PaginatedResult<any>;
  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
    // this.route.data.subscribe(data => {
    //   // this.data = data[this.name];
    //   console.log(data);
    // });
  }

  setPage(atrib) {
    this.loading = false;

    this.getData(atrib).subscribe(pagedData => {
      this.data = pagedData;
      this.loading = false;
    });
  }
}
