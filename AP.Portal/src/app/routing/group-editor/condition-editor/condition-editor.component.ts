import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Condition } from '../../routing.model';

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

  notify() {
    this.conditionChange.emit(this.condition);
  }
}
