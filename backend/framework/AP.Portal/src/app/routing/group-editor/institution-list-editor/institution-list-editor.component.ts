import { Component, Input, OnInit, Output } from '@angular/core';
import { Group } from '../../routing.model';

@Component({
  selector: 'app-institution-list-editor',
  templateUrl: './institution-list-editor.component.html',
  styleUrls: ['./institution-list-editor.component.css']
})
export class InstitutionListEditorComponent implements OnInit {

  @Input() public group: Group;

  constructor() { }

  ngOnInit(): void {
  }

  delete(index: number) {
    this.group.institutionIds.splice(index, 1);
  }

  add() {
    this.group.institutionIds.unshift('');
  }

  trackByIndex(index: number) {
    return index;
  }
}
