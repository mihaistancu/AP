import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Group } from './routing.model';

@Injectable({
  providedIn: 'root'
})
export class RoutingService {

  constructor(public http: HttpClient) { }

  getAllGroups(): Observable<Group[]> {
    return this.http.get<Group[]>('/api/routing/groups');
  }
}
