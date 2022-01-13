import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessMessageRoutingEditorComponent } from './business-message-routing-editor.component';

describe('BusinessMessageRoutingEditorComponent', () => {
  let component: BusinessMessageRoutingEditorComponent;
  let fixture: ComponentFixture<BusinessMessageRoutingEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BusinessMessageRoutingEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessMessageRoutingEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
