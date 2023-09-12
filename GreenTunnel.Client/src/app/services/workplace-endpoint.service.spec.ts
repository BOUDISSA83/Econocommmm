import { TestBed } from '@angular/core/testing';

import { WorkplaceEndpointService } from './workplace-endpoint.service';

describe('WorkplaceEndpointService', () => {
  let service: WorkplaceEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkplaceEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
