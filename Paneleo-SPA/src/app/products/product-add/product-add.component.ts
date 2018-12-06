import { Component, OnInit, ViewChild } from '@angular/core';
import { DynamicFormComponent } from 'src/app/_utilis/dynamic-form/dynamic-form.component';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProductService } from 'src/app/_services/Product/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  regConfig: FieldConfig[] = [
    {
      type: 'input',
      label: 'Nazwa Produktu',
      inputType: 'text',
      name: 'name',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Nazwa Produktu jest wymagana!'
        }
      ]
    },
    {
      type: 'input',
      label: 'Ilość',
      inputType: 'number',
      min: '0',
      name: 'quantity',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Ilość jest wymagana!'
        },
        {
          name: 'min',
          validator: Validators.min(0),
          message: 'Ilość musi być liczbą dodatnią!'
        }
      ]
    },
    {
      type: 'button',
      label: 'Dodaj'
    }
  ];

  constructor(
    private alertify: AlertifyService,
    private productService: ProductService
  ) {}

  ngOnInit() {}

  submit(value: any) {
    this.productService.addProduct(value).subscribe(
      () => {
        this.alertify.success('Dodano nowy produkt!');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
