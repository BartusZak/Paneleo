import { Component, OnInit, ViewChild } from '@angular/core';
import { FieldConfig } from 'src/app/_models/field.interface';
import { Validators } from '@angular/forms';
import { templateSourceUrl } from '@angular/compiler';
import { formatDate } from '@angular/common';

import { DynamicFormComponent } from 'src/app/_utilis/dynamic-form/dynamic-form.component';
import { ContractorService } from 'src/app/_services/Contractor/contractor.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { OrderService } from 'src/app/_services/Order/order.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.css']
})
export class OrderAddComponent implements OnInit {
  today = new Date();
  orderId: number;
  jstoday = '';
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  regConfig: FieldConfig[] = [
    {
      type: 'input',
      label: 'Data',
      inputType: 'date',
      default: new Date().toISOString().split('T')[0],
      name: 'orderDate'
    },
    {
      type: 'input',
      label: 'Miejsce',
      inputType: 'text',
      default: 'Giżycko',
      name: 'place'
    },
    {
      type: 'radiobutton',
      label: 'isCompany',
      options: ['Firma', 'Osoba prywatna'],
      value: 'Firma',
      name: 'isCompany'
    },
    {
      type: 'input',
      label: 'Kontrahent',
      inputType: 'text',
      name: 'contractorId',
      validations: [
        {
          name: 'required',
          validator: Validators.required,
          message: 'Kontrahent jest wymagany!'
        }
      ],
      typeahead: this.contractorService.searchContractorByQuery
    },
    {
      type: 'products',
      label: 'Produkty',
      name: 'products'
    },
    {
      type: 'button',
      label: 'Dodaj'
    }
  ];

  constructor(
    private alertify: AlertifyService,
    private orderService: OrderService,
    private contractorService: ContractorService,
    private route: ActivatedRoute
  ) {
    this.jstoday = formatDate(this.today, '/MM/yyyy', 'pl-PL', '+0530');
  }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.orderId = data['order'].successResult.id + 1;
    });
    console.log(Date.now());
  }

  submit(value: any) {
    const newOrder = { ...value };
    newOrder.contractorId = value.contractorId.id;
    this.orderService.addOrder(newOrder).subscribe(
      () => {
        this.alertify.success('Dodano nowe zamówienie!');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
