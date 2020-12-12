import { SafenetTemplatePage } from './app.po';

describe('Safenet App', function() {
  let page: SafenetTemplatePage;

  beforeEach(() => {
    page = new SafenetTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
