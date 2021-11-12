import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Group } from '../routing.model';
import { RoutingService } from '../routing.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-group-editor',
  templateUrl: './group-editor.component.html',
  styleUrls: ['./group-editor.component.css']
})
export class GroupEditorComponent implements OnInit {

  public id: string;
  public group: Group;

  constructor(
    private route: ActivatedRoute,
    private service: RoutingService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getGroup(this.id).subscribe(group => { this.group = group; });
  }

  save() {
    this.service.update(this.id, this.group).subscribe(_ => { });
  }

  trackById(index: number) {
    return index;
  }
}
