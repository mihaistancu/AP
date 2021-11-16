import { Component, Input, OnInit } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-rule',
  templateUrl: './rule.component.html',
  styleUrls: ['./rule.component.css']
})
export class RuleComponent implements OnInit {

  @Input() endpoint: Endpoint;

  constructor() { }

  ngOnInit(): void {
  }

}
