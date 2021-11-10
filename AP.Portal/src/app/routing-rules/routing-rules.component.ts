import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RoutingRule } from './routing-rules.model';
import { RoutingRulesService } from './routing-rules.service';

@Component({
  selector: 'app-routing-rules',
  templateUrl: './routing-rules.component.html',
  styleUrls: ['./routing-rules.component.css']
})
export class RoutingRulesComponent implements OnInit {

  rules$: Observable<RoutingRule[]>;

  constructor(
    public service: RoutingRulesService
  ) { }

  public isAddingNewGroup: boolean;
  public institutionId: string;

  ngOnInit(): void {
    this.rules$ = this.service.getRules();
  }

  addGroup() {
    this.isAddingNewGroup = true;
  }

  saveGroup() {
    this.service.createGroupWith(this.institutionId)
      .subscribe(group => { console.log(group.groupId); });

    this.isAddingNewGroup = false;
  }

  cancelGroup() {
    this.isAddingNewGroup = false;
    this.institutionId = '';
  }
}
