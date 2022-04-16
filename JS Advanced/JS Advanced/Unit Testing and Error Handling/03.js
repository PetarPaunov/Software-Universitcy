const describe = require('mocha').describe;
const assert = require('chai').assert;


function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}



describe('lookUpChar', () => {
    it('ShouldReturtUndifind', () => {
        assert.isUndefined(lookupChar(1, 1));
        assert.isUndefined(lookupChar('str', 1.2));
        assert.isUndefined(lookupChar('str', 's'));
    })

    it('ShouldReturtIncorrect index', () => {
        assert.equal(lookupChar('str', -1), "Incorrect index");
        assert.equal(lookupChar('str', 4), "Incorrect index");
        assert.equal(lookupChar('str', 3), "Incorrect index");
    })
    it('ShouldReturtCharAtTheGivenIndex', () => {
        assert.equal(lookupChar('str', 1), "t");
        assert.equal(lookupChar('str', 0), "s");
    })
})
