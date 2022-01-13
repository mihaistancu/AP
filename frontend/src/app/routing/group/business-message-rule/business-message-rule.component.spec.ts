import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessMessageRuleComponent } from './business-message-rule.component';

describe('ConditionComponent', () => {
  let component: BusinessMessageRuleComponent;
  let fixture: ComponentFixture<BusinessMessageRuleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BusinessMessageRuleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusinessMessageRuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
