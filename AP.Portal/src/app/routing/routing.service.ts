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

  getGroup(groupId: string): Observable<Group> {
    return this.http.get<Group>(`/api/routing/groups/${groupId}`);
  }

  delete(groupId: string) {
    return this.http.delete(`/api/routing/groups/${groupId}`);
  }

  update(groupId: string, group: Group) {
    return this.http.put(`/api/routing/groups/${groupId}`, group);
  }
}
