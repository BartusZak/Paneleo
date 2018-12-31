import { ContractorService } from './../../_services/Contractor/contractor.service';
import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { SingleResponse } from 'src/app/_models/response';
import { Contractor } from 'src/app/_models/contractor';

@Injectable()
export class ContractorDetailsResolver
  implements Resolve<SingleResponse<Contractor>> {
  constructor(
    private contractorService: ContractorService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot
  ): Observable<SingleResponse<Contractor>> {
    return this.contractorService.getContractor(route.paramMap.get('id')).pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/dashboard']);
        return of(null);
      })
    );
  }
}
