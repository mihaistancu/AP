import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-endpoint-list-editor',
  templateUrl: './endpoint-list-editor.component.html',
  styleUrls: ['./endpoint-list-editor.component.css']
})
export class EndpointListEditorComponent implements OnInit {

  @Input() public endpoints: Endpoint[];
  @Output() public endpointsChange = new EventEmitter<Endpoint[]>();

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
      name: '',
      type: 'pull',
      url: '',
      systemMessageSubscriptions: []
    });
  }

  notify() {
    this.endpointsChange.emit(this.endpoints);
  }
}
