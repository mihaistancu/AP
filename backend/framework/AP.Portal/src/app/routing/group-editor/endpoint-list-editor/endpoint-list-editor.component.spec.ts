import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EndpointListEditorComponent } from './endpoint-list-editor.component';

describe('EndpointListEditorComponent', () => {
  let component: EndpointListEditorComponent;
  let fixture: ComponentFixture<EndpointListEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EndpointListEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EndpointListEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
