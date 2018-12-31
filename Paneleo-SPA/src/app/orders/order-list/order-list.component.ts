import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/_services/Order/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  ordersColumns = [
    { prop: 'id', summaryFunc: () => null },
    { prop: 'contractor.name', name: 'Kontrahent', summaryFunc: () => null },
    { prop: 'createdAt', name: 'Wystawiono dnia', summaryFunc: () => null },
    { prop: 'totalCost', name: 'Suma', summaryFunc: () => null }
  ];
  constructor(private orderService: OrderService, private router: Router) {}

  ngOnInit() {}

  getOrders = atrib => {
    return this.orderService.getOrders(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };

  onRowClick = id => {
    return this.router.navigate(['/orders', id]);
    // tslint:disable-next-line:semicolon
  };
}
