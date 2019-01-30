import { TestBed } from '@angular/core/testing';

import { BerlinClockTimerService } from './berlin-clock-timer.service';

describe('BerlinClockTimerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BerlinClockTimerService = TestBed.get(BerlinClockTimerService);
    expect(service).toBeTruthy();
  });
});
