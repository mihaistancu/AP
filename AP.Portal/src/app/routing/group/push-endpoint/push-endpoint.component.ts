import { Component, Input, OnInit } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-push-endpoint',
  templateUrl: './push-endpoint.component.html',
  styleUrls: ['./push-endpoint.component.css']
})
export class PushEndpointComponent implements OnInit {

  @Input() endpoint: Endpoint;

  constructor() { }

  ngOnInit(): void {
  }

}
