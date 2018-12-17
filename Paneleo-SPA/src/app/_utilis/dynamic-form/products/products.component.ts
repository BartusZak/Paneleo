import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-products',
  template: `
    <div class="form-group" [formGroup]="group">
      <app-products-for-order></app-products-for-order>
    </div>
  `,
  styles: []
})
export class ProductsComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  constructor() {}
  ngOnInit() {}
}
