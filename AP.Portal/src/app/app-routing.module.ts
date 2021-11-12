import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupCreatorComponent } from './routing/group-creator/group-creator.component';
import { GroupUpdaterComponent } from './routing/group-updater/group-updater.component';
import { RoutingComponent } from './routing/routing.component';

const routes: Routes = [
  { path: 'routing', component: RoutingComponent },
  { path: 'routing/update/:id', component: GroupUpdaterComponent },
  { path: 'routing/create', component: GroupCreatorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    relativeLinkResolution: 'legacy',
    onSameUrlNavigation: 'reload'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
