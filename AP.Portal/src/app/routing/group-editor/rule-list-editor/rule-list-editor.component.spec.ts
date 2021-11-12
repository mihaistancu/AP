import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RuleListEditorComponent } from './rule-list-editor.component';

describe('RuleListEditorComponent', () => {
  let component: RuleListEditorComponent;
  let fixture: ComponentFixture<RuleListEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RuleListEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RuleListEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
