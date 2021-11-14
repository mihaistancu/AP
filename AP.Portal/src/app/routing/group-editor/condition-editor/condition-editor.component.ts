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

  public conditionText;

  constructor() { }

  ngOnInit(): void {
    this.conditionText = JSON.stringify(this.condition);
  }

  notify() {
    this.condition = JSON.parse(this.conditionText);
    this.conditionChange.emit(this.condition);
  }
}
