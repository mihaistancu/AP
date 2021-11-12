import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Group } from '../routing.model';
import { RoutingService } from '../routing.service';

@Component({
  selector: 'app-group-editor',
  templateUrl: './group-editor.component.html',
  styleUrls: ['./group-editor.component.css']
})
export class GroupEditorComponent implements OnInit {

  public group: Group;

  constructor(
    private route: ActivatedRoute,
    private service: RoutingService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getGroup(id).subscribe(g => { this.group = g; console.log("hello"); });
  }
}
