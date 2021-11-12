import { Component, Input, OnInit } from '@angular/core';
import { Rule } from '../../routing.model';

@Component({
  selector: 'app-rule-editor',
  templateUrl: './rule-editor.component.html',
  styleUrls: ['./rule-editor.component.css']
})
export class RuleEditorComponent implements OnInit {

  @Input() rule: Rule;

  constructor() { }

  ngOnInit(): void {
  }

}
