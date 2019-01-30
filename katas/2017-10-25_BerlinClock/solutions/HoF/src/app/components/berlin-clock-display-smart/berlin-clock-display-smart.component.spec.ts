import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BerlinClockDisplaySmartComponent } from './berlin-clock-display-smart.component';
import { BerlinClockDisplayComponent } from '../berlin-clock-display/berlin-clock-display.component';

describe('BerlinClockDisplaySmartComponent', () => {
  let component: BerlinClockDisplaySmartComponent;
  let fixture: ComponentFixture<BerlinClockDisplaySmartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        BerlinClockDisplaySmartComponent,
        BerlinClockDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BerlinClockDisplaySmartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
