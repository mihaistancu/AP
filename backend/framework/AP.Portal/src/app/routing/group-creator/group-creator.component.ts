import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Group } from '../routing.model';
import { RoutingService } from '../routing.service';

@Component({
  selector: 'app-group-creator',
  templateUrl: './group-creator.component.html',
  styleUrls: ['./group-creator.component.css']
})
export class GroupCreatorComponent implements OnInit {

  public group: Group = {
    groupId: '',
    institutionIds: [],
    endpoints: []
  }

  constructor(
    public service: RoutingService,
    public router: Router
  ) { }

  ngOnInit(): void {
  }

  create() {
    this.service.create(this.group).subscribe(_ => {
      this.router.navigate(['/routing']);
    });
  }
}
