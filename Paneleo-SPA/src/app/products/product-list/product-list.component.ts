import {
  Component,
  OnInit,
  EventEmitter,
  Output,
  TemplateRef,
  ViewChild
} from '@angular/core';
import { ProductService } from 'src/app/_services/Product/product.service';
import { Router } from '@angular/router';
import { GenericListComponent } from '../../_utilis/generic-list/generic-list.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  @ViewChild(GenericListComponent)
  genericListComponent: GenericListComponent;

  productColumns: any;

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.productColumns = [
      { prop: 'id', summaryFunc: () => null },
      { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
      { prop: 'quantity', name: 'Ilość', summaryFunc: () => null },
      { prop: 'unitOfMeasure', name: 'Jm', summaryFunc: () => null },
      {
        prop: 'pricePerUnit',
        name: 'Cana za jm',
        cellTemplate: this.genericListComponent.currencyCell,
        summaryFunc: () => null
      }
    ];
  }

  getProducts = atrib => {
    return this.productService.getProducts(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };

  onRowClick = id => {
    return this.router.navigate(['/products', id]);
    // tslint:disable-next-line:semicolon
  };
}
