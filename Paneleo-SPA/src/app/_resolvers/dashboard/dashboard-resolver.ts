import { Component, OnInit, Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { SingleResponse } from 'src/app/_models/response';
import { Dashboard } from 'src/app/_models/dashboard';
import { DashboardService } from 'src/app/_services/dashboard/dashboard.service';

@Injectable()
export class DashboardResolver implements Resolve<SingleResponse<Dashboard>> {
  constructor(
    private dashboardService: DashboardService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(
    route: ActivatedRouteSnapshot
  ): Observable<SingleResponse<Dashboard>> {
    return this.dashboardService.getStatistics().pipe(
      catchError(error => {
        this.alertify.error(error);
        this.router.navigate(['/']);
        return of(null);
      })
    );
  }
}
