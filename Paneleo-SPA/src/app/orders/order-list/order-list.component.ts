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
    { prop: 'contractorName', name: 'Kontrahent', summaryFunc: () => null },
    { prop: 'createdAt', name: 'Wystawiono dnia', summaryFunc: () => null },
    { prop: 'totalCost', name: 'Suma', summaryFunc: () => null }
  ];
  constructor(private orderService: OrderService) {}

  ngOnInit() {}

  getOrders = atrib => {
    return this.orderService.getOrders(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };
}
