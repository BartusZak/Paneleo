import { Component, OnInit } from '@angular/core';
import { TitleService } from 'src/app/_services/title.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsData: any;
  totalPageCount: number;
  currentPage: number;
  productColumns = [
    { prop: 'id', summaryFunc: () => null },
    { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
    { prop: 'quantity', name: 'Ilość', summaryFunc: () => null }
  ];
  constructor(private titleService: TitleService) {}

  ngOnInit() {
    this.titleService.setTitle('Lista Produktów');
  }
}
