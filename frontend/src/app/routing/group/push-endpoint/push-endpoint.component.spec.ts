import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PushEndpointComponent } from './push-endpoint.component';

describe('PushEndpointComponent', () => {
  let component: PushEndpointComponent;
  let fixture: ComponentFixture<PushEndpointComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PushEndpointComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PushEndpointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
