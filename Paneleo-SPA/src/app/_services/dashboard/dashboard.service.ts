import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Dashboard } from 'src/app/_models/dashboard';
import { Observable } from 'rxjs';
import { SingleResponse } from 'src/app/_models/response';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getStatistics(): Observable<SingleResponse<Dashboard>> {
    return this.http.get<SingleResponse<Dashboard>>(this.baseUrl + 'dashboard');
  }
}
