import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { SingleResponse } from 'src/app/_models/response';
import { Product } from 'src/app/_models/product';
import { ProductService } from 'src/app/_services/Product/product.service';

@Injectable()
export class ProductDetailsResolver
  implements Resolve<SingleResponse<Product>> {
  constructor(
    private productService: ProductService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<SingleResponse<Product>> {
    return this.productService.getProduct(route.paramMap.get('id')).pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
