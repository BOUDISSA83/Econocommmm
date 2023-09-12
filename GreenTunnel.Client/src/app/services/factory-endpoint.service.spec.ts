import { TestBed } from '@angular/core/testing';

import { FactoryEndpointService } from './factory-endpoint.service';

describe('FactoryEndpointService', () => {
  let service: FactoryEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FactoryEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
