import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RoutingService } from '../routing.service';

@Component({
  selector: 'app-group-editor',
  templateUrl: './group-editor.component.html',
  styleUrls: ['./group-editor.component.css']
})
export class GroupEditorComponent implements OnInit {

  public id: string;

  constructor(
    private route: ActivatedRoute,
    private service: RoutingService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
  }

}
