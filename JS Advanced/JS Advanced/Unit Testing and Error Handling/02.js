    const describe = require('mocha').describe;
    const assert = require('chai').assert;


function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe('evenOrOdd', () =>{

    it('ShowdReturnUndifindIfInputIsNotString', () => {
        let expected = undefined;
        let result = isOddOrEven(123);

        assert.equal(result, expected);
    })

    it('SholdReturnOddIfStringLength%2IsEqualTo0', () =>{
        let expected = 'even';
        let result = isOddOrEven('even');

        assert.equal(expected, result);
    })

    it('SholdReturtOddIfStringHasOddLength', () =>{
        let expected = 'odd';
        let result = isOddOrEven('odd');

        assert.equal(expected, result);
    })

})
