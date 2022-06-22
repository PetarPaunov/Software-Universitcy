let flowerShop = require('./flowerShop');
let expect = require('chai').expect;

describe("Tests flowerShop", function() {
    describe("tests calcPriceOfFlowers", function() {
        it("shold Throw Error whit incorect inputs", function() {
            expect(() => flowerShop.calcPriceOfFlowers(1,1,1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers([],1,1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('str','str',1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('str',1.1,1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('str',1,'str')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('str',1,1.1)).to.throw(Error, 'Invalid input!');
        });

        it('Shold returnt corect ountPut', function(){
            let result = 1;
            expect(flowerShop.calcPriceOfFlowers('Kitka', 1, 1)).to.equal(`You need $${result.toFixed(2)} to buy Kitka!`);
        })
    });

    describe("checkFlowersAvailable Tests", function() {
        it("Shoud return curent flower if garthen has it", function() {
            expect(flowerShop.checkFlowersAvailable('Kitka', ['Cvete1', 'Cvete2', 'Kitka'])).to.equal(`The Kitka are available!`);
        });

        it("Shoud return that we dont have the flower", function() {
            expect(flowerShop.checkFlowersAvailable('Kitka', ['Cvete1', 'Cvete2'])).to.equal(`The Kitka are sold! You need to purchase more!`);
        });
    });

    describe("sellFlowers Tests", function() {
        it("Should Throw Error if input is incorect", function() {
            expect(() => flowerShop.sellFlowers('str', 1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers({}, 1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Cvete1', 'Cvete2'], 'str')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Cvete1', 'Cvete2'], 1.1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Cvete1', 'Cvete2'], -1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Cvete1', 'Cvete2'], 2)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Cvete1', 'Cvete2'], 3)).to.throw(Error, 'Invalid input!');
        });

        it("Should return corect outPut", function() {
            expect(flowerShop.sellFlowers(['Cvete1', 'Cvete2', 'Cvete3'], 2)).to.equal('Cvete1 / Cvete2');
        });
    });
});
