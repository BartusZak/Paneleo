import { Component, OnInit, OnDestroy } from '@angular/core';
import { TitleService } from '../_services/title.service';

import { Order } from '../_models/order';
import { Pagination } from '../_models/pagination';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [
    new Order(
      1,
      'test',
      'Leszek Płoszyński',
      [],
      new Date('2015-05-18'),
      new Date('2015-05-18'),
      'Giżycko'
    ),
    new Order(
      2,
      'test2',
      'Tomasz Jeznach',
      [],
      new Date('2015-05-13'),
      new Date('2015-05-11'),
      'Giżycko'
    ),
    new Order(
      3,
      'test',
      'Bartłomiej Płoszyński',
      [],
      new Date('2015-03-18'),
      new Date('2015-02-18'),
      'Giżycko'
    ),
    new Order(
      4,
      'test',
      'Jeż Jeży',
      [],
      new Date('2015-01-15'),
      new Date('2015-04-12'),
      'Giżycko'
    )
  ];
  pagination: Pagination;

  constructor(private titleService: TitleService) {}

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
