import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-endpoint-editor',
  templateUrl: './endpoint-editor.component.html',
  styleUrls: ['./endpoint-editor.component.css']
})
export class EndpointEditorComponent implements OnInit {

  @Input() endpoint: Endpoint;
  @Output() endpointChange = new EventEmitter<Endpoint>();

  constructor() { }

  ngOnInit(): void {
  }

  notify() {
    this.endpointChange.emit(this.endpoint);
  }

  deleteRule() {
    delete this.endpoint.businessMessageRule;
    this.notify();
  }

  createSimpleRule() {
    this.endpoint.businessMessageRule = {
      type: 'equals',
      key: '',
      value: ''
    };
    this.notify();
  }

  createCompositeRule() {
    this.endpoint.businessMessageRule = {
      type: 'any',
      children: []
    };
    this.notify();
  }
}
