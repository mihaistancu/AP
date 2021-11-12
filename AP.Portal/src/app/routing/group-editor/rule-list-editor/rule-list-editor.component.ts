import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Rule } from '../../routing.model';

@Component({
  selector: 'app-rule-list-editor',
  templateUrl: './rule-list-editor.component.html',
  styleUrls: ['./rule-list-editor.component.css']
})
export class RuleListEditorComponent implements OnInit {

  @Input() public rules: Rule[];
  @Output() public rulesChange = new EventEmitter<Rule[]>();

  constructor() { }

  ngOnInit(): void {
  }

  trackByIndex(index: number) {
    return index;
  }

  delete(index: number) {
    this.rules.splice(index, 1);
    this.notify();
  }

  notify() {
    this.rulesChange.emit(this.rules);
  }
}
