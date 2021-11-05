import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RoutingRule } from './routing-rules.model';

@Injectable({
  providedIn: 'root'
})
export class RoutingRulesService {

  constructor(private http: HttpClient) {

  }

  getRules(): Observable<RoutingRule[]> {
    return this.http.get<RoutingRule[]>('/api/routing-rules');
  }
}
