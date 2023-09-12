import { TestBed } from '@angular/core/testing';
import { MouldEndpointService } from './mould-endpoint.service';

describe('MouldEndpointService', () => {
  let service: MouldEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MouldEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
