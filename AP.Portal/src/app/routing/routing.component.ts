import { Component, OnInit } from '@angular/core';
import { Group } from './routing.model';
import { RoutingService } from './routing.service';

@Component({
  selector: 'app-routing',
  templateUrl: './routing.component.html',
  styleUrls: ['./routing.component.css']
})
export class RoutingComponent implements OnInit {

  constructor(public service: RoutingService) { }

  public groups: Group[];

  ngOnInit(): void {
    this.service.getAllGroups().subscribe(
      groups => { this.groups = groups; }
    );
  }

}
