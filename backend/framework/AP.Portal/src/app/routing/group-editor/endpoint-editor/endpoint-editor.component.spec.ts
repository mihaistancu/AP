import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EndpointEditorComponent } from './endpoint-editor.component';

describe('EndpointEditorComponent', () => {
  let component: EndpointEditorComponent;
  let fixture: ComponentFixture<EndpointEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EndpointEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EndpointEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
