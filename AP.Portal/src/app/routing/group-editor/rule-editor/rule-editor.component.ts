import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Endpoint } from '../../routing.model';

@Component({
  selector: 'app-rule-editor',
  templateUrl: './rule-editor.component.html',
  styleUrls: ['./rule-editor.component.css']
})
export class RuleEditorComponent implements OnInit {

  @Input() endpoint: Endpoint;
  @Output() endpointChange = new EventEmitter<Endpoint>();

  constructor() { }

  ngOnInit(): void {
  }

  notify() {
    this.endpointChange.emit(this.endpoint);
  }

}
