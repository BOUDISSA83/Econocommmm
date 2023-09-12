import { TestBed } from '@angular/core/testing';

import { WorkspaceEndpointService } from './workspace-endpoint.service';

describe('WorkspaceEndpointService', () => {
  let service: WorkspaceEndpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkspaceEndpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
