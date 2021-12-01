import { Component, Input, OnInit } from '@angular/core';
import { PullEndpoint, PushEndpoint } from '../../routing.model';

@Component({
  selector: 'app-subscription-list-editor',
  templateUrl: './subscription-list-editor.component.html',
  styleUrls: ['./subscription-list-editor.component.css']
})
export class SubscriptionListEditorComponent implements OnInit {

  @Input() public endpoint: PushEndpoint | PullEndpoint;

  constructor() { }

  ngOnInit(): void {
  }

  delete(index: number) {
    this.endpoint.systemMessageSubscriptions.splice(index, 1);
  }

  add() {
    this.endpoint.systemMessageSubscriptions.unshift('');
  }
}
