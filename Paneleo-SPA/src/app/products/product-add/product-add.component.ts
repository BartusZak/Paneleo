import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  addProductForm: FormGroup;
  constructor() {}

  ngOnInit() {
    this.addProductForm = new FormGroup({
      name: new FormControl(),
      quantity: new FormControl()
    });
  }

  addProduct() {
    console.log(this.addProductForm);
  }
}
