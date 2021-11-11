import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupEditorComponent } from './routing/group-editor/group-editor.component';
import { RoutingComponent } from './routing/routing.component';

const routes: Routes = [
  { path: 'routing', component: RoutingComponent },
  { path: 'routing/:id', component: GroupEditorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
