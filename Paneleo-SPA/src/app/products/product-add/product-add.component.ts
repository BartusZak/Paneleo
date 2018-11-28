import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/Product/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  addProductForm: FormGroup;
  productToAdd: Product;
  constructor(
    private productService: ProductService,
    private fb: FormBuilder,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.createAddProductForm();
  }

  createAddProductForm() {
    this.addProductForm = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.maxLength(40),
          this.noWhitespaceValidator
        ]
      ],
      quantity: [0, Validators.min(0)]
    });
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { whitespace: true };
  }

  addProduct() {
    if (this.addProductForm.valid) {
      this.productToAdd = Object.assign({}, this.addProductForm.value);
      this.productService.addProduct(this.productToAdd).subscribe(
        () => {
          this.alertify.success('Dodano nowy produkt!');
        },
        error => {
          this.alertify.error(error);
        }
      );
    }
    console.log(this.addProductForm);
  }
}
