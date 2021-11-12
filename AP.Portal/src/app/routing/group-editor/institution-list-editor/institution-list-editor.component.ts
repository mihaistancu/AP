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

  onChange(value: string, index: number) {
    this.institutionIds[index] = value;
    this.notify();
  }

  delete(index: number) {
    this.institutionIds.splice(index, 1);
    this.notify();
  }

  notify() {
    this.institutionIdsChange.emit(this.institutionIds);
  }
}
