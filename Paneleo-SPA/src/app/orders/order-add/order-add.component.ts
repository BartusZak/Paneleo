import { Component, OnInit, ViewChild } from '@angular/core';
import { DynamicFormComponent } from 'src/app/_utilis/dynamic-form/dynamic-form.component';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Validators } from '@angular/forms';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { OrderService } from 'src/app/_services/Order/order.service';

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.css']
})
export class OrderAddComponent implements OnInit {
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  regConfig: FieldConfig[] = [
    {
      type: 'input',
      label: 'Kontrahent',
      inputType: 'text',
      name: 'name',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Kontrahent jest wymagany!'
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
    private orderService: OrderService
  ) {}

  ngOnInit() {}

  submit(value: any) {
    this.orderService.addOrder(value).subscribe(
      () => {
        this.alertify.success('Dodano nowe zamówienie!');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }