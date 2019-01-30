import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BerlinClockDisplayComponent } from './berlin-clock-display.component';

describe('BerlinClockDisplayComponent', () => {
  let component: BerlinClockDisplayComponent;
  let fixture: ComponentFixture<BerlinClockDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BerlinClockDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BerlinClockDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
