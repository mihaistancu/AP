import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PullEndpointComponent } from './pull-endpoint.component';

describe('EndpointComponent', () => {
  let component: PullEndpointComponent;
  let fixture: ComponentFixture<PullEndpointComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [PullEndpointComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PullEndpointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
