import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-institution-list-editor',
  templateUrl: './institution-list-editor.component.html',
  styleUrls: ['./institution-list-editor.component.css']
})
export class InstitutionListEditorComponent implements OnInit {

  @Input() public institutionIds: string[];
  @Output() public institutionIdsChange = new EventEmitter<string[]>();

  constructor() { }

  ngOnInit(): void {
  }

  delete(index: number) {
    this.institutionIds.splice(index, 1);
    this.notify();
  }

  add() {
    this.institutionIds.push('');
    this.notify();
  }

  notify() {
    this.institutionIdsChange.emit(this.institutionIds);
  }

  trackByIndex(index: number) {
    return index;
  }
}
