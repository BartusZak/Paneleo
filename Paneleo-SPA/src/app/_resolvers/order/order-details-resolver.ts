import { Injectable } from '@angular/core';
import { AlertifyService } from '../../_services/alertify.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Order } from '../../_models/order';
import { OrderService } from '../../_services/Order/order.service';
import { SingleResponse } from 'src/app/_models/response';

@Injectable()
export class OrderDetailsResolver implements Resolve<SingleResponse<Order>> {
  constructor(
    private orderService: OrderService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<SingleResponse<Order>> {
    return this.orderService.getOrder(route.paramMap.get('id')).pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
