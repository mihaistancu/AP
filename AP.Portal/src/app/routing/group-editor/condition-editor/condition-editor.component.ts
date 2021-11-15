import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Aggregate, Condition } from '../../routing.model';

@Component({
  selector: 'app-condition-editor',
  templateUrl: './condition-editor.component.html',
  styleUrls: ['./condition-editor.component.css']
})
export class ConditionEditorComponent implements OnInit {

  @Input() condition: Condition;
  @Output() conditionChange = new EventEmitter<Condition>();

  constructor() { }

  ngOnInit(): void {
    
  }

  addPredicate(condition: Aggregate) {
    condition.children.unshift({
      type: 'equals',
      key: '',
      value: ''
    });
    this.notify();
  }

  addAggregate(condition: Aggregate) {
    condition.children.unshift({
      type: 'all',
      children: [{
        type: 'equals',
        key: '',
        value: ''
      }]
    });
    this.notify();
  }

  deleteChild(condition: Aggregate, index: number) {
    condition.children.splice(index, 1);
    this.notify();
  }

  notify() {
    this.conditionChange.emit(this.condition);
  }
}
