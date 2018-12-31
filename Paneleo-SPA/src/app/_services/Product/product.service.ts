import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../_models/product';
import { PaginatedResult } from 'src/app/_models/pagination';
import { map } from 'rxjs/operators';
import { SingleResponse } from 'src/app/_models/response';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(pageLimit?, pageNumber?): Observable<PaginatedResult<Product[]>> {
    const paginatedResult: PaginatedResult<Product[]> = new PaginatedResult<
      Product[]
    >();

    let params = new HttpParams();

    if (pageNumber != null && pageLimit != null) {
      params = params.append('PageNumber', pageNumber);
      params = params.append('PageLimit', pageLimit);
    }

    return this.http
      .get<any>(this.baseUrl + 'products', {
        observe: 'response',
        params
      })
      .pipe(
        map(response => {
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

  getProduct(id: string): Observable<SingleResponse<Product>> {
    return this.http.get<SingleResponse<Product>>(
      this.baseUrl + 'products/' + id
    );
  }

  addProduct(product: Product) {
    return this.http.post(this.baseUrl + 'products/', product);
  }

  updateProduct(id: number, product: Product) {
    return this.http.put(this.baseUrl + 'products/' + id, product);
  }
}
