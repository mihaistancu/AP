import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstitutionListEditorComponent } from './institution-list-editor.component';

describe('InstitutionListEditorComponent', () => {
  let component: InstitutionListEditorComponent;
  let fixture: ComponentFixture<InstitutionListEditorComponent>;

  beforeEach(async(() => {
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
