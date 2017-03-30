import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class App {


    constructor(httpClient) {
        this.httpClient = httpClient;
        this.field = [];
        this.l = '0px';
    }

    attached() {
        return this.httpClient.createRequest(this.getServer())
            .asGet()
            .send()
            .then((httpResponse) => {
                const newUrl = `http://192.168.161.41:5000/api/ant/next/${JSON.parse(httpResponse.response)}`;
                return newUrl;
            }).then((newUrl) => {
                setInterval(() => {

                    return this.httpClient.createRequest(newUrl)
                        .asGet()
                        .send()
                        .then((httpRes) => {
                            const board = JSON.parse(httpRes.response).board;
                            this.field = board;

                            this.field = this.field.reduce((total, elem) => {
                                return total.concat(elem);
                            });

                            this.l = `${Math.sqrt(this.field.length) * 68}px`;
                        });
                }, 3000);

            });
    }

    getServer() {
        return 'http://192.168.161.41:5000/api/ant/init/10/3,3/n';
    }
}
