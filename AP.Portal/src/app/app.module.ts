import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoutingComponent } from './routing/routing.component';
import { GroupComponent } from './routing/group/group.component';
import { RuleComponent } from './routing/group/rule/rule.component';
import { GroupEditorComponent } from './routing/group-editor/group-editor.component';
import { InstitutionListEditorComponent } from './routing/group-editor/institution-list-editor/institution-list-editor.component';
import { RuleEditorComponent } from './routing/group-editor/rule-editor/rule-editor.component';
import { RuleListEditorComponent } from './routing/group-editor/rule-list-editor/rule-list-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutingComponent,
    GroupComponent,
    RuleComponent,
    GroupEditorComponent,
    InstitutionListEditorComponent,
    RuleEditorComponent,
    RuleListEditorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
