import { Component, Input, OnInit } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-pull-endpoint',
  templateUrl: './pull-endpoint.component.html',
  styleUrls: ['./pull-endpoint.component.css']
})
export class PullEndpointComponent implements OnInit {

  @Input() endpoint: Endpoint;

  constructor() { }

  ngOnInit(): void {
  }
}
