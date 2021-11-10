import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Group, RoutingRule } from './routing-rules.model';
import { RoutingRulesService } from './routing-rules.service';

@Component({
  selector: 'app-routing-rules',
  templateUrl: './routing-rules.component.html',
  styleUrls: ['./routing-rules.component.css']
})
export class RoutingRulesComponent implements OnInit {

  constructor(
    public service: RoutingRulesService
  ) { }

  public groups: Group[];
  public isAddingNewGroup: boolean;
  public institutionId: string;

  ngOnInit(): void {
    this.service.getAllGroups()
      .subscribe(groups => this.groups = groups);
  }

  addGroup() {
    this.isAddingNewGroup = true;
  }

  saveGroup() {
    this.service.createGroupWith(this.institutionId)
      .subscribe(group => {
        this.groups.unshift({
          groupId: group.groupId,
          institutionIds: [this.institutionId]
        });
        this.institutionId = '';
      });

    this.isAddingNewGroup = false;
  }

  cancelGroup() {
    this.isAddingNewGroup = false;
    this.institutionId = '';
  }
}
