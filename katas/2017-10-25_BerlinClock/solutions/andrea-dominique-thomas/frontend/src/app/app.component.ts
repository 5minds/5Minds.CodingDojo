import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  public lights: Array<boolean>;
  private appService: AppService;

  constructor(appService: AppService) {
    this.appService = appService;
  }

  public ngOnInit(): void {
    this.createTimer();
  }

  private createTimer(): void {
    window.setInterval(() => {
      this.appService.getLights()
        .subscribe((lights: Array<boolean>) => {
          this.lights = lights;
          console.log(lights);
        });
    }, 1000);
  }

  public getBackgroundColor(lightIndex: number): string {
    if (!this.lights || this.lights.length === 0) {
      return 'lightgray';
    }

    if (!this.lights[lightIndex]) {
      return '#e74c3c';
    }

    return '#27ae60';
  }

}
