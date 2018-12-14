import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products-for-order',
  templateUrl: './productsForOrder.component.html',
  styleUrls: ['./productsForOrder.component.css']
})
export class ProductsForOrderComponent {
  editing = {};
  rows = [
    {
      id: 1,
      name: null,
      quantity: 1,
      unitOfMeasure: 'sztuka',
      pricePerUnit: 0.0,
      totalPrice: 0.0
    }
  ];

  constructor() {
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

  updateValue(event, cell, rowIndex) {
    console.log('inline editing rowIndex', rowIndex);
    this.editing[rowIndex + '-' + cell] = false;
    this.rows[rowIndex][cell] = event.target.value;
    this.rows = [...this.rows];
    console.log('UPDATED!', this.rows[rowIndex][cell]);
  }

  onAddProductToOrderClick = () => {
    this.rows = [
      ...this.rows,
      {
        id: this.rows.length + 1,
        name: null,
        quantity: 1,
        unitOfMeasure: 'sztuka',
        pricePerUnit: 0.0,
        totalPrice: 0.0
      }
    ];
  };
}
