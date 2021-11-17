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
import { EndpointEditorComponent } from './routing/group-editor/endpoint-editor/endpoint-editor.component';
import { EndpointListEditorComponent } from './routing/group-editor/endpoint-list-editor/endpoint-list-editor.component';
import { GroupUpdaterComponent } from './routing/group-updater/group-updater.component';
import { GroupCreatorComponent } from './routing/group-creator/group-creator.component';
import { BusinessMessageRuleEditorComponent } from './routing/group-editor/business-message-rule-editor/business-message-rule-editor.component';
import { BusinessMessageRuleComponent } from './routing/group/business-message-rule/business-message-rule.component';
import { SubscriptionListEditorComponent } from './routing/group-editor/subscription-list-editor/subscription-list-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutingComponent,
    GroupComponent,
    EndpointComponent,
    GroupEditorComponent,
    InstitutionListEditorComponent,
    EndpointEditorComponent,
    EndpointListEditorComponent,
    GroupUpdaterComponent,
    GroupCreatorComponent,
    BusinessMessageRuleEditorComponent,
    BusinessMessageRuleComponent,
    SubscriptionListEditorComponent
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
