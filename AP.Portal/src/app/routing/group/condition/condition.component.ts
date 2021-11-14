import { Component, Input, OnInit } from '@angular/core';
import { Condition } from '../../routing.model';

@Component({
  selector: 'app-condition',
  templateUrl: './condition.component.html',
  styleUrls: ['./condition.component.css']
})
export class ConditionComponent implements OnInit {

  @Input() public condition: Condition;

  constructor() { }

  ngOnInit(): void {
  }

}
