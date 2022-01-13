import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { InstitutionListEditorComponent } from './institution-list-editor.component';

describe('InstitutionListEditorComponent', () => {
  let component: InstitutionListEditorComponent;
  let fixture: ComponentFixture<InstitutionListEditorComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ InstitutionListEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstitutionListEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
