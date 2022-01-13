import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessMessageRuleEditorComponent } from './business-message-rule-editor.component';

describe('BusinessMessageRuleEditorComponent', () => {
  let component: BusinessMessageRuleEditorComponent;
  let fixture: ComponentFixture<BusinessMessageRuleEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BusinessMessageRuleEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessMessageRuleEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
