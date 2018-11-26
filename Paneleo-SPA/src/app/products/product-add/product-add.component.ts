import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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
      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(40)
      ]),
      quantity: new FormControl(0, Validators.min(0))
    });
  }

  addProduct() {
    console.log(this.addProductForm);
  }
}
