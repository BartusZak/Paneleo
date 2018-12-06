import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Order } from '../_models/order';
import { OrderService } from '../_services/Order/order.service';

@Injectable()
export class OrderListResolver implements Resolve<Order[]> {
  pageNumber = 1;
  pageLimit = 5;

  constructor(
    private orderService: OrderService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Order[]> {
    return this.orderService.getOrders(this.pageLimit, this.pageNumber).pipe(
      catchError(error => {
        this.alertify.error('Wystąpił problem z wczytaniem zamówień!');
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
