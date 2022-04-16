const { should } = require('chai');
let numberOperations = require(`./03. Number Operations_Resources`);
let expect = require('chai').expect;

describe('numberOperations', () => {
    describe('powNumber', () => {
        it('Should return given number powored by it', () => {
            expect(numberOperations.powNumber(2)).to.eql(4);
        })
        it('Should return given number powored by it', () => {
            expect(numberOperations.powNumber(-2)).to.eql(4);
        })
    })
    describe('numberChecker', () => {
        it('Should throw if input in NaN', () => {
            expect(() => numberOperations.numberChecker('str')).to.throw(Error, 'The input is not a number!');
        })
        it('Should throw if input in NaN', () => {
            expect(() => numberOperations.numberChecker({})).to.throw(Error, 'The input is not a number!');
        })
        it('Should throw if input in NaN', () => {
            expect(() => numberOperations.numberChecker(NaN)).to.throw(Error, 'The input is not a number!');
        })

        it('Should return when input is less then 100', () => {
            expect(numberOperations.numberChecker(80)).to.equal('The number is lower than 100!');
        })

        it('Should return when input is bigger then 100', () => {
            expect(numberOperations.numberChecker(110)).to.equal('The number is greater or equal to 100!');
        })

        it('Should return when input is negativ number', () => {
            expect(numberOperations.numberChecker(-100)).to.equal('The number is lower than 100!');
        })
    })
    describe('sumArrays', () => {
        it('Should sum both arrays', () => {
            expect(numberOperations.sumArrays([1, 2, 3], [1, 2, 3])).to.eql([2, 4, 6]);
        })

        it('Should sum both arrays', () => {
            expect(numberOperations.sumArrays([-1, 2, 3], [1, -2, 3])).to.eql([0, 0, 6]);
        })
    })
})