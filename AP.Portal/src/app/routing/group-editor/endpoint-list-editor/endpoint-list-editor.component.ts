import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PushEndpoint, PullEndpoint, Group } from '../../routing.model';

@Component({
  selector: 'app-endpoint-list-editor',
  templateUrl: './endpoint-list-editor.component.html',
  styleUrls: ['./endpoint-list-editor.component.css']
})
export class EndpointListEditorComponent implements OnInit {

  @Input() public group: Group;
  @Output() public groupChange = new EventEmitter<Group>();

  constructor() { }

  ngOnInit(): void {
  }

  trackByIndex(index: number) {
    return index;
  }

  delete(index: number) {
    this.group.endpoints.splice(index, 1);
    this.notify();
  }

  add() {
    this.group.endpoints.unshift({
      type: 'push',
      name: '',
      naUrl: '',
      outboxUrl: '',
    });
  }

  notify() {
    this.groupChange.emit(this.group);
  }
}
