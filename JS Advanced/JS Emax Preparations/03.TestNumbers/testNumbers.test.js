let testNumbers = require('./testNumbers');
let expect = require('chai').expect;

describe('testNumbers Tests', function(){

    describe('sumNumbers tests', function(){

        it('Should return Undifind if iputs are not numbers', function(){
            expect(testNumbers.sumNumbers('1', 2)).to.equal(undefined);
            expect(testNumbers.sumNumbers([], 2)).to.equal(undefined);
            expect(testNumbers.sumNumbers({}, 2)).to.equal(undefined);
            expect(testNumbers.sumNumbers(2, '1')).to.equal(undefined);
            expect(testNumbers.sumNumbers(2, [])).to.equal(undefined);
            expect(testNumbers.sumNumbers(2, {})).to.equal(undefined);
        })

        it('Should retrun the sum ot the input numbers toFixed(2)', function(){
            let expected = 3;
            let expected2 = 2.50;
            expected = expected.toFixed(2);
            expect(testNumbers.sumNumbers(1,2)).to.eql(expected);
            expect(testNumbers.sumNumbers(1.5,1.5)).to.eql(expected);
            expect(testNumbers.sumNumbers(1.25,1.25)).to.eql(expected2.toFixed(2));
        })

    })

    describe('numberChecker Tests', function(){
        it('Should thorw if input is NaN', function(){
            expect(() =>testNumbers.numberChecker('str')).to.throw(Error, 'The input is not a number!');
            expect(() =>testNumbers.numberChecker()).to.throw(Error, 'The input is not a number!');
            expect(() =>testNumbers.numberChecker({})).to.throw(Error, 'The input is not a number!');
        })

        it('Should return if numbers are even', function(){
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(4)).to.equal('The number is even!');
            expect(testNumbers.numberChecker(-4)).to.equal('The number is even!');
        })
        
        
        it('Should return if numbers are odd', function(){
            expect(testNumbers.numberChecker(3)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(5)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(-5)).to.equal('The number is odd!');
        })
    })

    describe('averageSumArray Tests', function(){
        it('Should return the sum of the arays of numbers devided by two', function(){
            expect(testNumbers.averageSumArray([1,2,3,4,5])).to.eql(3);
        })

        it('Should return the sum of the arays of negativ numbers devided by two', function(){
            expect(testNumbers.averageSumArray([-1,-2,3,4,5])).to.eql(1.8);
        })
    })
    

})