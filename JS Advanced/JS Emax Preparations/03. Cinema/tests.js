let cinema  = require('./cinema');
let expect = require('chai').expect;

describe("cinema tests", function() {
    describe("showMovies tests", function() {
        it('Should return that the arr is epty', function() {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        });

        it('Should return movies joined by comma', function() {
            expect(cinema.showMovies(['Film1 Film2'])).to.equal('Film1 Film2');
            expect(cinema.showMovies(['Film1', 'Film2'])).to.equal('Film1, Film2');
        });
     });

     describe('ticketPrice', function(){
         it('Should retrund the price for the curent projection', function(){
             expect(cinema.ticketPrice('Premiere')).to.eql(12.00);
             expect(cinema.ticketPrice('Normal')).to.eql(7.50);
             expect(cinema.ticketPrice('Discount')).to.eql(5.50);
         })

         it('Should throw error if curent projecion is not in the obj', function(){
            expect(() => cinema.ticketPrice('PrimierNormal')).to.throw(Error, 'Invalid projection type.');
            expect(() => cinema.ticketPrice('NormalPrimier')).to.throw(Error, 'Invalid projection type.');
        })
     })

     describe('swapSeatsInHall', function(){
         it('Should sucsesful change the sits',function(){
             expect(cinema.swapSeatsInHall(1,20)).to.equal("Successful change of seats in the hall.");
             expect(cinema.swapSeatsInHall(5,2)).to.equal("Successful change of seats in the hall.");
         })

         it('Should throw Error if first argumant is incorect',function(){
             expect(cinema.swapSeatsInHall(5.5, 6)).to.equal("Unsuccessful change of seats in the hall.");
             expect(cinema.swapSeatsInHall(-5, 6)).to.equal("Unsuccessful change of seats in the hall.");
             expect(cinema.swapSeatsInHall(0, 6)).to.equal("Unsuccessful change of seats in the hall.");
             expect(cinema.swapSeatsInHall(21, 6)).to.equal("Unsuccessful change of seats in the hall.");
        })

        it('Should throw Error if second argumant is incorect',function(){
            expect(cinema.swapSeatsInHall(6, 5.5)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(6, -5)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(6, 0)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(6, 21)).to.equal("Unsuccessful change of seats in the hall.");
            expect(cinema.swapSeatsInHall(6, 6)).to.equal("Unsuccessful change of seats in the hall.");
       })
     })
     
});
