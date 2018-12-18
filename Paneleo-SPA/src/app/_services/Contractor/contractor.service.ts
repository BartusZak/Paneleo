import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Contractor } from 'src/app/_models/contractor';
import { PaginatedResult } from 'src/app/_models/pagination';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Response } from 'src/app/_models/response';

@Injectable({
  providedIn: 'root'
})
export class ContractorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getContractors(
    pageLimit?,
    pageNumber?
  ): Observable<PaginatedResult<Contractor[]>> {
    const paginatedResult: PaginatedResult<Contractor[]> = new PaginatedResult<
      Contractor[]
    >();

    let params = new HttpParams();

    if (pageNumber != null && pageLimit != null) {
      params = params.append('PageNumber', pageNumber);
      params = params.append('PageLimit', pageLimit);
    }

    return this.http
      .get<any>(this.baseUrl + 'contractors', {
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

  getContractor(id: number): Observable<Contractor> {
    return this.http.get<Contractor>(this.baseUrl + 'contractors/' + id);
  }

  addContractor(contractor: Contractor) {
    return this.http.post(this.baseUrl + 'contractors/', contractor);
  }

  updateContractor(id: number, contractor: Contractor) {
    return this.http.put(this.baseUrl + 'contractors/' + id, contractor);
  }

  searchContractorByQuery = (term: string) => {
    if (term === '') {
      return of([]);
    }

    return this.http
      .get<Response<Contractor>>(this.baseUrl + 'contractors/Search/' + term)
      .pipe(map(data => data.successResult));
    // tslint:disable-next-line:semicolon
  };
}
