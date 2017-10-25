import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AppService {

  private http: Http;

  constructor(http: Http) {
    this.http = http;
  }

  public getLights(): Observable<Array<boolean>> {
    return this.http.get('http://localhost:5000/api/BerlinTime')
      .map((response: Response) => {
        return response.json();
      });
  }

}
