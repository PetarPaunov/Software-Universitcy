
let library = require('./library');
let expect = require('chai').expect;

describe("library Test", function() {
    describe("calcPriceOfBook test", function() {
        it("Should throw Error whit incorect input", function() {
            expect(() => library.calcPriceOfBook(1990, 1990)).to.throw(Error, "Invalid input");
            expect(() => library.calcPriceOfBook('SomeBook', '1990')).to.throw(Error, "Invalid input");
        });

        it("Shoud make discount if year is less then 1980", function() {
            expect(library.calcPriceOfBook('Book', 1980)).to.equal('Price of Book is 10.00');
            expect(library.calcPriceOfBook('Book', 1978)).to.equal('Price of Book is 10.00');
        });

        it("Shoud not make discount", function() {
            expect(library.calcPriceOfBook('Book', 1981)).to.equal('Price of Book is 20.00');
            expect(library.calcPriceOfBook('Book', 2000)).to.equal('Price of Book is 20.00');
        });
     });

     describe("findBook test", function() {
        it("Shoud thorw Error if input Array length is zero", function() {
            expect(() => library.findBook([], 'Book')).to.throw(Error, "No books currently available");
        });

        it("Shoud return reqired Book", function() {
            expect(library.findBook(['Book1', 'Book2', 'Book3'], 'Book2')).to.equal("We found the book you want.");
            expect(library.findBook(['Book1'], 'Book1')).to.equal("We found the book you want.");
        });

        it("Shoud return that book is not faund", function() {
            expect(library.findBook(['Book1', 'Book2', 'Book3'], 'Book4')).to.equal("The book you are looking for is not here!");
            expect(library.findBook(['Book1'], 'Book2')).to.equal("The book you are looking for is not here!");
        });
     });
     

     describe("arrangeTheBooks test", function() {
        it("Should throw Error whit incorect input", function() {
            expect(() => library.arrangeTheBooks('3')).to.throw(Error, "Invalid input");
            expect(() => library.arrangeTheBooks(-1)).to.throw(Error, "Invalid input");
        });

        it("Should return that libraly have space of the books", function() {
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(25)).to.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(1)).to.equal("Great job, the books are arranged.");
        });

        it("Should return that libraly dont have space of the books", function() {
            expect(library.arrangeTheBooks(41)).to.equal("Insufficient space, more shelves need to be purchased.");
            expect(library.arrangeTheBooks(55)).to.equal("Insufficient space, more shelves need to be purchased.");
            expect(library.arrangeTheBooks(100)).to.equal("Insufficient space, more shelves need to be purchased.");
        });
     });
});
