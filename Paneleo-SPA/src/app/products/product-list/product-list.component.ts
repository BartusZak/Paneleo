import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product';
import { ActivatedRoute } from '@angular/router';
import { TitleService } from 'src/app/_services/title.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];
  // productColumns: Array<string> = ['id', 'Nazwa', 'Ilość'];
  productColumns = [
    { prop: 'id', summaryFunc: () => null },
    { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
    { prop: 'quantity', name: 'Ilość', summaryFunc: () => null }
  ];
  constructor(
    private route: ActivatedRoute,
    private titleService: TitleService
  ) {}

  ngOnInit() {
    this.titleService.setTitle('Lista Produktów');
    this.route.data.subscribe(data => {
      this.products = data['products'].successResult;
    });
  }
}
