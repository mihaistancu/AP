import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RoutingComponent } from './routing/routing.component';
import { GroupComponent } from './routing/group/group.component';
import { EndpointComponent } from './routing/group/endpoint/endpoint.component';
import { GroupEditorComponent } from './routing/group-editor/group-editor.component';
import { InstitutionListEditorComponent } from './routing/group-editor/institution-list-editor/institution-list-editor.component';
import { RuleEditorComponent } from './routing/group-editor/rule-editor/rule-editor.component';
import { RuleListEditorComponent } from './routing/group-editor/rule-list-editor/rule-list-editor.component';
import { GroupUpdaterComponent } from './routing/group-updater/group-updater.component';
import { GroupCreatorComponent } from './routing/group-creator/group-creator.component';
import { ConditionEditorComponent } from './routing/group-editor/condition-editor/condition-editor.component';
import { BusinessMessageRuleComponent } from './routing/group/business-message-rule/business-message-rule.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutingComponent,
    GroupComponent,
    EndpointComponent,
    GroupEditorComponent,
    InstitutionListEditorComponent,
    RuleEditorComponent,
    RuleListEditorComponent,
    GroupUpdaterComponent,
    GroupCreatorComponent,
    ConditionEditorComponent,
    BusinessMessageRuleComponent
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
