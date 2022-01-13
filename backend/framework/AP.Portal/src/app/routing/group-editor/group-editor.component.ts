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

  notify() {
    this.groupChange.emit(this.group);
  }
}
