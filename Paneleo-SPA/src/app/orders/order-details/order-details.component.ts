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
import { Order } from 'src/app/_models/order';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {
  public order: Order;
  productsColumns: any;
  constructor(
    private alertify: AlertifyService,
    private orderService: OrderService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.order = data['order'].successResult;
      console.log(data);
    });

    this.productsColumns = [
      { prop: 'name', name: 'Nazwa', summaryFunc: () => null },
      { prop: 'unitOfMeasure', name: 'Jm', summaryFunc: () => null },
      { prop: 'quantity', name: 'Ilość', summaryFunc: () => null },
      {
        prop: 'pricePerUnitNetto',
        name: 'Cena netto',
        summaryFunc: () => null
      },
      {
        prop: 'pricePerUnitBrutto',
        name: 'Cena brutto',
        summaryFunc: () => null
      },
      {
        prop: 'totalCostNetto',
        name: 'Wartość zamówienia netto',
        summaryFunc: () => null
      },
      {
        prop: 'totalCostBrutto',
        name: 'Wartość zamówienia brutto',
        summaryFunc: () => null
      }
    ];
  }
}
