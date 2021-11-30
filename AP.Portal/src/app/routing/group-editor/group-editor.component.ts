import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Group, PushEndpoint, PullEndpoint } from '../routing.model';

@Component({
  selector: 'app-group-editor',
  templateUrl: './group-editor.component.html',
  styleUrls: ['./group-editor.component.css']
})
export class GroupEditorComponent implements OnInit {

  @Input() public group: Group;
  @Output() public groupChange = new EventEmitter<Group>();

  constructor(
  ) { }

  ngOnInit(): void {
  }

  notifyInstitutionIds(institutionIds: string[]) {
    this.group.institutionIds = institutionIds;
    this.groupChange.emit(this.group);
  }

  notifyEndpoints(endpoints: (PushEndpoint | PullEndpoint)[]) {
    this.group.endpoints = endpoints;
    this.groupChange.emit(this.group);
  }
}
