import { browser, by, element } from 'protractor';

export class AppPage {
  async navigateTo() {
    return await browser.get('/');
  }

  async getParagraphText() {
    return await element(by.css('app-root h1')).getText();
  }
}
