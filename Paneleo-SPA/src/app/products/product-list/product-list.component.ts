import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ProductService } from 'src/app/_services/Product/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  // @Output() getProducts: EventEmitter<any> = new EventEmitter();
  productColumns = [
    { prop: 'id', summaryFunc: () => console.log('test') },
    { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
    { prop: 'quantity', name: 'Ilość', summaryFunc: () => null }
  ];
  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {}

  getProducts = atrib => {
    return this.productService.getProducts(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };

  onRowClick = id => {
    return this.router.navigate(['/products', id]);
    // tslint:disable-next-line:semicolon
  };
}
