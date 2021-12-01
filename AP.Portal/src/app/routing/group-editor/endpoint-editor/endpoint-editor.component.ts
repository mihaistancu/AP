import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PushEndpoint, PullEndpoint } from '../../routing.model';

@Component({
  selector: 'app-endpoint-editor',
  templateUrl: './endpoint-editor.component.html',
  styleUrls: ['./endpoint-editor.component.css']
})
export class EndpointEditorComponent implements OnInit {

  @Input() endpoint: PushEndpoint | PullEndpoint;

  constructor() { }

  ngOnInit(): void {
  }

  deleteRule() {
    delete this.endpoint.businessMessageRule;
  }

  createSimpleRule() {
    this.endpoint.businessMessageRule = {
      type: 'equals',
      key: '',
      value: ''
    };
  }

  createCompositeRule() {
    this.endpoint.businessMessageRule = {
      type: 'any',
      children: []
    };
  }

}
