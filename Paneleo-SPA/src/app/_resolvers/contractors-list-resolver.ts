import { Injectable } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Contractor } from '../_models/contractor';
import { ContractorService } from '../_services/Contractor/contractor.service';

@Injectable()
export class ContractorListResolver implements Resolve<Contractor[]> {
  pageNumber = 1;
  pageLimit = 5;

  constructor(
    private contractorService: ContractorService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Contractor[]> {
    return this.contractorService
      .getContractors(this.pageLimit, this.pageNumber)
      .pipe(
        catchError(error => {
          this.alertify.error('Wystąpił problem z wczytaniem Kontrahentów!');
          this.router.navigate(['/dashboard']);
          return of(null);
        })
      );
  }
}
