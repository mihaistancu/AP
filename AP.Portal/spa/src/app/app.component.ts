import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <app-routing-rules></app-routing-rules>
    <router-outlet></router-outlet>
  `,
  styles: []
})
export class AppComponent {
  title = 'Portal';
}
