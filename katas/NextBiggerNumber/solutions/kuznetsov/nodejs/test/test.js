var assert = require("assert");
const nextBigger = require("../app");
describe("Tests", function () {
    it('nextBigger(12)==21', function () {
        assert.equal(nextBigger(12), 21);
    }),
        it('nextBigger(513) == 531', function () { assert.equal(nextBigger(513), 531); }),
        it('nextBigger(2017)==2071', function () { assert.equal(nextBigger(2017),2071); }),
        it('nextBigger(459853)==483559', function () { assert.equal(nextBigger(459853), 483559); }),
        it('nextBigger(59884848459853)==59884848483559', function () { assert.equal(nextBigger(59884848459853), 59884848483559); }),
        it('nextBigger(9)==-1', function () { assert.equal(nextBigger(9), -1); }),
        it('nextBigger(111)==-1', function () { assert.equal(nextBigger(111), -1); }),
        it('nextBigger(531)==-1', function () { assert.equal(nextBigger(531), -1); })
});