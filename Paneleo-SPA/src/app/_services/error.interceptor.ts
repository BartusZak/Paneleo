import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpEvent,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ErrorInterceptor implements ErrorInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        console.log(error, '<------------------');
        if (error instanceof HttpErrorResponse) {
          if (error.status === 401) {
            return throwError(error.statusText);
          }
          const applicationError = error.headers.get('Application-Error');
          if (applicationError) {
            console.error(applicationError);
            return throwError(applicationError);
          }

          const serverError = error.error;

          let errorModel = '';

          if (serverError.errorOccurred) {
            for (const key in serverError.errors) {
              if (serverError.errors[key]) {
                errorModel += serverError.errors[key] + '\n<br/>';
              }
            }
          }

          let modalStateErrors = '';
          if (
            serverError &&
            typeof serverError === 'object' &&
            error.status !== 0
          ) {
            for (const key in serverError) {
              if (serverError[key]) {
                modalStateErrors += serverError[key] + '\n<br/>';
              }
            }
          }

          return throwError(
            errorModel ||
              modalStateErrors ||
              // serverError ||
              '<b>Błąd serwera!</b><br/>Skontaktuj się z administratorem.'
          );
        }
      })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};
