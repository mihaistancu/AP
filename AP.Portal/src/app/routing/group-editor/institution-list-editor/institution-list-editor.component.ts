import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-institution-list-editor',
  templateUrl: './institution-list-editor.component.html',
  styleUrls: ['./institution-list-editor.component.css']
})
export class InstitutionListEditorComponent implements OnInit {

  @Input() public institutionIds: string[];

  constructor() { }

  ngOnInit(): void {
    console.log(this.institutionIds);
  }

  delete(index: number) {
    this.institutionIds.splice(index, 1);
  }
}
