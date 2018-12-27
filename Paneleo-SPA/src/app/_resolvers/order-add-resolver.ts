import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Order } from '../_models/order';
import { OrderService } from '../_services/Order/order.service';

@Injectable()
export class OrderAddResolver implements Resolve<Order> {
  constructor(
    private orderService: OrderService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Order> {
    return this.orderService.getLastOrderDetails().pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
