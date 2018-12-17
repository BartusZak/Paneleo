import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { timeout } from 'q';

@Component({
  selector: 'app-products-for-order',
  templateUrl: './productsForOrder.component.html',
  styleUrls: ['./productsForOrder.component.css']
})
export class ProductsForOrderComponent {
  editing = {};
  toPay = 0;
  rows = [
    {
      id: 1,
      name: 'Nazwa',
      quantity: 1,
      unitOfMeasure: 'sztuka',
      pricePerUnit: 0.0,
      totalPrice: 0.0
    }
  ];

  constructor(private ref: ChangeDetectorRef) {
    // this.fetch(data => {
    //   console.log(data);
    //   this.rows = {
    //     name: 'Test',
    //     gender: 'Male',
    //     age: 21
    //   };
    // });
  }

  fetch(cb) {}

  updateTotalPrice = () => {
    this.toPay = 0;
    this.rows.forEach(item => {
      this.toPay = item.totalPrice + this.toPay;
    });
  };

  updateValue(event, cell, rowIndex) {
    console.log('inline editing rowIndex', rowIndex);
    this.editing[rowIndex + '-' + cell] = false;
    this.rows[rowIndex][cell] = event.target.value;
    this.rows = [...this.rows];
    console.log('UPDATED!', this.rows[rowIndex][cell]);

    if (cell === 'pricePerUnit' || cell === 'quantity') {
      this.rows[rowIndex]['totalPrice'] =
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
        totalPrice: 0.0
      }
    ];
  };

  onRemoveProductFromListClick = (id: number) => {
    const rows = [...this.rows];

    if (this.rows.length > 1) {
      rows.splice(id, 1);
    }
    rows.forEach(index => {
      if (index.id > id + 1) {
        --index.id;
      }
    });
    this.rows = rows;
    this.updateTotalPrice();
  };
}
