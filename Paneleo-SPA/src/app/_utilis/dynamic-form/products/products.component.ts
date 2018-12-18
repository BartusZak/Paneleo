import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FieldConfig } from 'src/app/_models/field.interface';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  field: FieldConfig;
  group: FormGroup;
  editing = {};
  toPay = 0;
  rows = [];
  constructor() {}
  ngOnInit() {}

  updateProductsList = () => {
    this.group.value.products = this.rows;
    console.log(this.group.value);
    // tslint:disable-next-line:semicolon
  };

  updateTotalPrice = () => {
    this.toPay = 0;
    this.rows.forEach(item => {
      this.toPay = item.totalCost + this.toPay;
    });
    this.updateProductsList();
    // tslint:disable-next-line:semicolon
  };

  updateValue(event, cell, rowIndex) {
    this.editing[rowIndex + '-' + cell] = false;
    this.rows[rowIndex][cell] = event.target.value;
    this.rows = [...this.rows];

    if (cell === 'pricePerUnit' || cell === 'quantity') {
      this.rows[rowIndex]['totalCost'] =
        this.rows[rowIndex]['pricePerUnit'] * this.rows[rowIndex]['quantity'];
    }
    this.updateTotalPrice();
  }

  onAddProductToOrderClick = () => {
    this.rows = [
      ...this.rows,
      {
        id: this.rows.length + 1,
        name: 'Nazwa',
        quantity: 1,
        unitOfMeasure: 'sztuka',
        pricePerUnit: 0.0,
        totalCost: 0.0,
        productId: null
      }
    ];
    this.updateProductsList();
    // tslint:disable-next-line:semicolon
  };

  onRemoveProductFromListClick = (id: number) => {
    const rows = [...this.rows];
    rows.splice(id, 1);
    rows.forEach(index => {
      if (index.id > id + 1) {
        --index.id;
      }
    });
    this.rows = rows;
    this.updateTotalPrice();
    // tslint:disable-next-line:semicolon
  };
}
