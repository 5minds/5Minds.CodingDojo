import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { BerlinClockDisplayComponent } from './components/berlin-clock-display/berlin-clock-display.component';
import { BerlinClockDisplaySmartComponent } from './components/berlin-clock-display-smart/berlin-clock-display-smart.component';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        BerlinClockDisplayComponent,
        BerlinClockDisplaySmartComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'BerlinClock'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('BerlinClock');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Welcome to BerlinClock!');
  });
});
