import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscriptionListEditorComponent } from './subscription-list-editor.component';

describe('SubscriptionListEditorComponent', () => {
  let component: SubscriptionListEditorComponent;
  let fixture: ComponentFixture<SubscriptionListEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubscriptionListEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubscriptionListEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
