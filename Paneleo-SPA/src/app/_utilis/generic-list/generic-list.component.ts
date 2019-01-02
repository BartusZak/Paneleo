import {
  Component,
  OnInit,
  Input,
  TemplateRef,
  ViewChild
} from '@angular/core';
import { PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-generic-list',
  templateUrl: './generic-list.component.html',
  styleUrls: ['./generic-list.component.css']
})
export class GenericListComponent implements OnInit {
  @ViewChild('currencyCell') currencyCell: TemplateRef<any>;
  @ViewChild('dateCell') dateCell: TemplateRef<any>;

  @Input() getData: any;
  @Input() name: string;
  @Input() columns: Array<string>;
  @Input() onRowClick: any;

  loading = true;
  data: PaginatedResult<any>;

  constructor() {}

  ngOnInit() {
    this.setPage({ limit: 10, offset: 0 });
  }

  setPage(atrib) {
    this.loading = true;
    this.getData(atrib).subscribe((pagedData: PaginatedResult<any>) => {
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
