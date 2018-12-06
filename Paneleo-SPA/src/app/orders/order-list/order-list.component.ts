import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/_services/Order/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  ordersColumns = [
    { prop: 'id', summaryFunc: () => null },
    { prop: 'contractor', name: 'Kontrahent', summaryFunc: () => null }
  ];
  constructor(private orderService: OrderService) {}

  ngOnInit() {}

  getOrders = atrib => {
    return this.orderService.getOrders(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };
}
