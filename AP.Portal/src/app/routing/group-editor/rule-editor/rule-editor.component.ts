import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Rule } from '../../routing.model';

@Component({
  selector: 'app-rule-editor',
  templateUrl: './rule-editor.component.html',
  styleUrls: ['./rule-editor.component.css']
})
export class RuleEditorComponent implements OnInit {

  @Input() rule: Rule;
  @Output() ruleChange = new EventEmitter<Rule>();

  constructor() { }

  ngOnInit(): void {
  }

  notify() {
    this.ruleChange.emit(this.rule);
  }

}
