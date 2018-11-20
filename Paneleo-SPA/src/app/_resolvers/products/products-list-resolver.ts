import { Injectable } from '@angular/core';
import { ProductService } from '../../_services/Product/product.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from '../../_models/product';

@Injectable()
export class ProductListResolver implements Resolve<Product[]> {
  constructor(
    private productService: ProductService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Product[]> {
    return this.productService.getProducts().pipe(
      catchError(error => {
        this.alertify.error('Wystąpił problem z wczytaniem produktów!');
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
