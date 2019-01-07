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
  totalNetPrice = 0.0;
  totalGrossPrice = 0.0;
  rows = [];
  constructor() {}
  ngOnInit() {}

  updateProductsList = () => {
    this.group.value.products = this.rows;
    this.group.value.totalNetPrice = this.totalNetPrice;
    this.group.value.totalGrossPrice = this.totalGrossPrice;
    // tslint:disable-next-line:semicolon
  };

  updateTotalPrices = () => {
    let totalNetPriceTemp = 0.0;
    let totalGrossPriceTemp = 0.0;

    this.rows.forEach(item => {
      totalNetPriceTemp += item.totalNetPrice;
      totalGrossPriceTemp += item.totalGrossPrice;
    });

    this.totalNetPrice = Math.round(totalNetPriceTemp * 100) / 100;
    this.totalGrossPrice = Math.round(totalGrossPriceTemp * 100) / 100;

    this.updateProductsList();
    // tslint:disable-next-line:semicolon
  };

  updateValue(event, cell, rowIndex) {
    this.editing[rowIndex + '-' + cell] = false;
    this.rows[rowIndex][cell] = event.target.value;
    this.rows = [...this.rows];

    const netPrice = parseFloat(this.rows[rowIndex]['netPrice']);

    if (cell === 'netPrice' || cell === 'vat') {
      const vatPrice =
        Math.round(netPrice * (this.rows[rowIndex]['vat'] / 100) * 100) / 100;

      this.rows[rowIndex]['grossPrice'] = netPrice + vatPrice;
    }

    if (cell === 'netPrice' || cell === 'quantity' || cell === 'vat') {
      this.rows[rowIndex]['totalNetPrice'] =
        netPrice * this.rows[rowIndex]['quantity'];

      this.rows[rowIndex]['totalGrossPrice'] =
        this.rows[rowIndex]['grossPrice'] * this.rows[rowIndex]['quantity'];
    }

    this.updateTotalPrices();
  }

  onAddProductToOrderClick = () => {
    this.rows = [
      ...this.rows,
      {
        id: this.rows.length + 1,
        name: 'Nazwa',
        quantity: 1,
        unitOfMeasure: 'sztuka',
        vat: 0,
        netPrice: 0.0,
        grossPrice: 0.0,
        totalNetPrice: 0.0,
        totalGrossPrice: 0.0,
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
    this.updateTotalPrices();
    // tslint:disable-next-line:semicolon
  };
}
