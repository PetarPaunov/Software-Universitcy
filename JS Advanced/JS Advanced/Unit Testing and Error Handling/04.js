const describe = require('mocha').describe;
const assert = require('chai').assert;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('Should Return Undefinded', () => {
            assert.isUndefined(mathEnforcer.addFive('str'));
            assert.isUndefined(mathEnforcer.addFive(undefined));
        })

        it('Should Return Given Number + 5', () => {
            assert.equal(mathEnforcer.addFive(5), 10)
            assert.equal(mathEnforcer.addFive(2.5), 7.5)
            assert.equal(mathEnforcer.addFive(-6), -1)
            assert.closeTo(mathEnforcer.addFive(3.12), 8.12, 0.1)
        })
    })
    
    describe('subtractTen', () => {
        it('Should Return Undefinded', () => {
            assert.isUndefined(mathEnforcer.subtractTen('str'));
            assert.isUndefined(mathEnforcer.subtractTen(undefined));
        })

        it('Should Return Subtract 10 From The Given Number', () => {
            assert.equal(mathEnforcer.subtractTen(0), -10);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
            assert.equal(mathEnforcer.subtractTen(9), -1);
            assert.equal(mathEnforcer.subtractTen(20), 10);
            assert.equal(mathEnforcer.subtractTen(11.5), 1.5);
        })
    })
    
    describe('sum', () => {
        it('Should Return Undefinded', () => {
            assert.isUndefined(mathEnforcer.sum('str', 1));
            assert.isUndefined(mathEnforcer.sum(1, 'str'));
        })

        it('Should Return The Sum Of Two Numbers', () => {
            assert.equal(mathEnforcer.sum(10, 10), 20);
            assert.equal(mathEnforcer.sum(-10, 10), 0);
            assert.equal(mathEnforcer.sum(5.5, 4.5), 10);
            assert.equal(mathEnforcer.sum(-5, -4), -9);
            assert.closeTo(mathEnforcer.sum(10, 10.2), 22.2, 22.1);

        })
    })
})