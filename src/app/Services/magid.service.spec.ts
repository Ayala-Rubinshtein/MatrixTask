import { TestBed } from '@angular/core/testing';

import { MagidService } from './magid.service';

describe('MagidService', () => {
  let service: MagidService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MagidService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
