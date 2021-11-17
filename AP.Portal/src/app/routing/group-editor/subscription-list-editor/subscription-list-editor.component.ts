import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-subscription-list-editor',
  templateUrl: './subscription-list-editor.component.html',
  styleUrls: ['./subscription-list-editor.component.css']
})
export class SubscriptionListEditorComponent implements OnInit {

  @Input() public subscriptions: string[];
  @Output() public subscriptionsChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }

  delete(index: number) {
    this.subscriptions.splice(index, 1);
    this.notify();
  }

  add() {
    this.subscriptions.unshift('');
    this.notify();
  }

  notify() {
    this.subscriptionsChange.emit(this.subscriptions);
  }

  trackByIndex(index: number) {
    return index;
  }
}
