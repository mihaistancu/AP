import { Component, Input, OnInit } from '@angular/core';
import { PullEndpoint } from '../../routing.model';

@Component({
  selector: 'app-pull-endpoint',
  templateUrl: './pull-endpoint.component.html',
  styleUrls: ['./pull-endpoint.component.css']
})
export class PullEndpointComponent implements OnInit {

  @Input() endpoint: PullEndpoint;

  constructor() { }

  ngOnInit(): void {
  }
}
