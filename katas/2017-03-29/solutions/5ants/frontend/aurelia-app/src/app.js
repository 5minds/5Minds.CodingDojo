import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class App {


    constructor(httpClient) {
        this.httpClient = httpClient;
        this.field = [['s'], ['w']];
    }

    attached() {
        setInterval(() => {
            return this.httpClient.createRequest('is-username-free')
                .asGet()
                .withBaseUrl(this.getServer())
                .withParams({
                    kantenlaenge: 50,
                    startpos: [5, 5],
                    blickrichtung: 'o'
                })
                .send()
                .then((httpResponse) => {
                    console.log(httpResponse);
                    this.field = JSON.parse(httpResponse);
                });

        }, 3000);

    }

    getServer() {
        return 'http://localhost:3000';
    }
}
