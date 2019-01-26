import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Order } from 'src/app/_models/order';
import { SingleResponse } from 'src/app/_models/response';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrders(pageLimit?, pageNumber?): Observable<PaginatedResult<Order[]>> {
    const paginatedResult: PaginatedResult<Order[]> = new PaginatedResult<
      Order[]
    >();

    let params = new HttpParams();

    if (pageNumber != null && pageLimit != null) {
      (params = params.append('PageNumber', pageNumber)),
        (params = params.append('PageLimit', pageLimit));
    }
    return this.http
      .get<any>(this.baseUrl + 'orders', {
        observe: 'response',
        params
      })
      .pipe(
        map(response => {
          paginatedResult.results = response.body;
          paginatedResult.results = response.body.successResult.results;
          paginatedResult.currentPage = response.body.successResult.currentPage;
          paginatedResult.totalItemsCount =
            response.body.successResult.totalItemsCount;
          paginatedResult.totalPageCount =
            response.body.successResult.totalPageCount;
          return paginatedResult;
        })
      );
  }

  getOrder(id: string): Observable<SingleResponse<Order>> {
    return this.http.get<SingleResponse<Order>>(this.baseUrl + 'orders/' + id);
  }

  getLastOrderDetails(): Observable<Order> {
    return this.http.get<Order>(this.baseUrl + 'orders/LastOrderDetails');
  }

  addOrder(order: Order) {
    return this.http.post<SingleResponse<Order>>(
      this.baseUrl + 'orders/',
      order
    );
  }

  updateOrder(id: number, order: Order) {
    return this.http.put(this.baseUrl + 'orders/' + id, order);
  }

  printPdf(id: number) {
    return this.http.get(this.baseUrl + 'orders/pdf/' + id);
  }
}
