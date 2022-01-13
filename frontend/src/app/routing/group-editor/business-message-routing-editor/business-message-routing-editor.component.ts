import { Component, Input, OnInit } from '@angular/core';
import { PullEndpoint, PushEndpoint } from '../../routing.model';

@Component({
  selector: 'app-business-message-routing-editor',
  templateUrl: './business-message-routing-editor.component.html',
  styleUrls: ['./business-message-routing-editor.component.css']
})
export class BusinessMessageRoutingEditorComponent implements OnInit {

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
