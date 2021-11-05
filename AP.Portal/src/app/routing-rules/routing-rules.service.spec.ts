import { TestBed } from '@angular/core/testing';

import { RoutingRulesService } from './routing-rules.service';

describe('RoutingRulesService', () => {
  let service: RoutingRulesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoutingRulesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
