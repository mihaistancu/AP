import { Component, Input, OnInit } from '@angular/core';
import { BusinessMessageRule } from '../../routing.model';

@Component({
  selector: 'app-business-message-rule',
  templateUrl: './business-message-rule.component.html',
  styleUrls: ['./business-message-rule.component.css']
})
export class BusinessMessageRuleComponent implements OnInit {

  @Input() public rule: BusinessMessageRule;

  constructor() { }

  ngOnInit(): void {
  }

}
