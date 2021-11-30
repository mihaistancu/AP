import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PushEndpoint, PullEndpoint } from '../../routing.model';

@Component({
  selector: 'app-endpoint-list-editor',
  templateUrl: './endpoint-list-editor.component.html',
  styleUrls: ['./endpoint-list-editor.component.css']
})
export class EndpointListEditorComponent implements OnInit {

  @Input() public endpoints: (PushEndpoint | PullEndpoint)[];
  @Output() public endpointsChange = new EventEmitter<(PushEndpoint | PullEndpoint)[]>();

  constructor() { }

  ngOnInit(): void {
  }

  trackByIndex(index: number) {
    return index;
  }

  delete(index: number) {
    this.endpoints.splice(index, 1);
    this.notify();
  }

  add() {
    this.endpoints.unshift({
      type: 'push',
      name: '',
      naUrl: '',
      outboxUrl: '',
    });
  }

  notify() {
    this.endpointsChange.emit(this.endpoints);
  }
}
