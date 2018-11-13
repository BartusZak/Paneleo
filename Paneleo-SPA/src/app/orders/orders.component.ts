import { Component, OnInit, OnDestroy } from '@angular/core';
import { TitleService } from '../_services/title.service';

import { Order } from '../_models/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  constructor(private titleService: TitleService) {}

  orders: Order[] = [new Order(1, 'test')];

  ngOnInit() {
    this.titleService.setTitle('Zamówienia');
  }

  hasOrders(): boolean {
    return this.orders && this.orders.length !== 0;
  }

  // ngOnDestroy() {
  //   this.titleService.setTitle('');
  // }
}
