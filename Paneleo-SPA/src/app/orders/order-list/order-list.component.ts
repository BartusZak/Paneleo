import { Component, OnInit, ViewChild } from '@angular/core';
import { OrderService } from 'src/app/_services/Order/order.service';
import { Router } from '@angular/router';
import { GenericListComponent } from 'src/app/_utilis/generic-list/generic-list.component';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  @ViewChild(GenericListComponent)
  genericListComponent: GenericListComponent;
  ordersColumns: any;
  constructor(private orderService: OrderService, private router: Router) {}

  ngOnInit() {
    this.ordersColumns = [
      { prop: 'name', name: 'Numer', summaryFunc: () => null },
      { prop: 'contractor.name', name: 'Kontrahent', summaryFunc: () => null },
      {
        prop: 'createdAt',
        name: 'Wystawiono dnia',
        cellTemplate: this.genericListComponent.dateCell,
        summaryFunc: () => null
      },
      {
        prop: 'totalCost',
        name: 'Suma',
        cellTemplate: this.genericListComponent.currencyCell,
        summaryFunc: () => null
      }
    ];
  }

  getOrders = atrib => {
    return this.orderService.getOrders(atrib.limit, ++atrib.offset);
    // tslint:disable-next-line:semicolon
  };

  onRowClick = id => {
    return this.router.navigate(['/orders', id]);
    // tslint:disable-next-line:semicolon
  };
}
