import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-products',
  template: `
    <div class="form-group text-center" [formGroup]="group">
      <app-products-for-order></app-products-for-order>
    </div>
  `,
  styles: []
})
export class ProductsComponent implements OnInit {
  productsColumns = [
    { prop: 'actions', name: '' },
    { prop: 'id', name: 'lp.' },
    { prop: 'productName', name: 'Nazwa produktu' },
    { prop: 'quantity', name: 'Ilość' },
    { prop: 'unitOfMeasure', name: 'Jm' },
    { prop: 'pricePerUnit', name: 'Cena za jednostkę' },
    { prop: 'totalCost', name: 'Cena produktów' }
  ];
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}
