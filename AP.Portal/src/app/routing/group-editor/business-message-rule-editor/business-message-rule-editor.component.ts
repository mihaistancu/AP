import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Aggregate, BusinessMessageRule } from '../../routing.model';

@Component({
  selector: 'app-business-message-rule-editor',
  templateUrl: './business-message-rule-editor.component.html',
  styleUrls: ['./business-message-rule-editor.component.css']
})
export class BusinessMessageRuleEditorComponent implements OnInit {

  @Input() rule: BusinessMessageRule;
  @Output() ruleChange = new EventEmitter<BusinessMessageRule>();

  constructor() { }

  ngOnInit(): void {
    
  }

  addPredicate(rule: Aggregate) {
    rule.children.unshift({
      type: 'equals',
      key: '',
      value: ''
    });
    this.notify();
  }

  addAggregate(rule: Aggregate) {
    rule.children.unshift({
      type: 'all',
      children: [{
        type: 'equals',
        key: '',
        value: ''
      }]
    });
    this.notify();
  }

  deleteChild(rule: Aggregate, index: number) {
    rule.children.splice(index, 1);
    this.notify();
  }

  notify() {
    this.ruleChange.emit(this.rule);
  }
}