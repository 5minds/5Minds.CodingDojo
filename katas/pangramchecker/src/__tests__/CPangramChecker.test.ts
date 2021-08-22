import CPangramChecker from '../CPangramChecker';

describe('CPangramChecker', () => {
  describe('CPangramChecker#fGetPangramType()', () => {
    it('Check all one example for all three cases', () => {
      let oPangramChecker:CPangramChecker = new CPangramChecker();
      const sExptedNone = "Hello World!";
      const sExpectedExact = "Th quick bwn fx jmps ver lazy dog";
      const sExpectedMore = "The quick brown fox jumps over the lazy dog";
      expect(oPangramChecker.fGetPangramType(sExptedNone)).toEqual(-1);
      expect(oPangramChecker.fGetPangramType(sExpectedExact)).toEqual(0);
      expect(oPangramChecker.fGetPangramType(sExpectedMore)).toEqual(1);
    });
  });
});
