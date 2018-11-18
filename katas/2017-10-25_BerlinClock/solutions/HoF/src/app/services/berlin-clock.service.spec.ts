import { TestBed } from '@angular/core/testing';

import { BerlinClockService } from './berlin-clock.service';

describe('BerlinClockService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BerlinClockService = TestBed.get(BerlinClockService);
    expect(service).toBeTruthy();
  });
});
