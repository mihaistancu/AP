import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Group } from '../routing.model';
import { RoutingService } from '../routing.service';

@Component({
  selector: 'app-group-updater',
  templateUrl: './group-updater.component.html',
  styleUrls: ['./group-updater.component.css']
})
export class GroupUpdaterComponent implements OnInit {

  public id: string;
  public group: Group;

  constructor(
    private route: ActivatedRoute,
    private service: RoutingService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getGroup(this.id).subscribe(group => { this.group = group; });
  }

  update() {
    this.service.update(this.id, this.group).subscribe(_ => {
      this.router.navigate(['/routing']);
    });
  }

}
