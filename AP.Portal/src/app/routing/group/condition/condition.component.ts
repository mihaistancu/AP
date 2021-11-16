import { Component, Input, OnInit } from '@angular/core';
import { BusinessMessageRule } from '../../routing.model';

@Component({
  selector: 'app-condition',
  templateUrl: './condition.component.html',
  styleUrls: ['./condition.component.css']
})
export class ConditionComponent implements OnInit {

  @Input() public rule: BusinessMessageRule;

  constructor() { }

  ngOnInit(): void {
  }

}
