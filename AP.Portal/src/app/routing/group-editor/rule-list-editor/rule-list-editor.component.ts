import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Rule } from '../../routing.model';

@Component({
  selector: 'app-rule-list-editor',
  templateUrl: './rule-list-editor.component.html',
  styleUrls: ['./rule-list-editor.component.css']
})
export class RuleListEditorComponent implements OnInit {

  @Input() public rules: Rule[];
  @Output() public rulesChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }

  trackByIndex(index: number) {
    return index;
  }

}
