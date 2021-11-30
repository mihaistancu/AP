import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Group } from '../../routing.model';

@Component({
  selector: 'app-institution-list-editor',
  templateUrl: './institution-list-editor.component.html',
  styleUrls: ['./institution-list-editor.component.css']
})
export class InstitutionListEditorComponent implements OnInit {

  @Input() public group: Group;
  @Output() public groupChange = new EventEmitter<Group>();

  constructor() { }

  ngOnInit(): void {
  }

  delete(index: number) {
    this.group.institutionIds.splice(index, 1);
    this.notify();
  }

  add() {
    this.group.institutionIds.unshift('');
    this.notify();
  }

  notify() {
    this.groupChange.emit(this.group);
  }

  trackByIndex(index: number) {
    return index;
  }
}
