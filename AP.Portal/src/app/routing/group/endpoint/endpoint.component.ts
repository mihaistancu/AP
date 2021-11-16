import { Component, Input, OnInit } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-endpoint',
  templateUrl: './endpoint.component.html',
  styleUrls: ['./endpoint.component.css']
})
export class EndpointComponent implements OnInit {

  @Input() endpoint: Endpoint;

  constructor() { }

  ngOnInit(): void {
  }

}
