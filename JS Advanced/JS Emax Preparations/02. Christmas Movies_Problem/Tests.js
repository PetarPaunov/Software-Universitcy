const describe = require('mocha').describe;
const expect = require('chai').expect;
const ChristmasMovies = require('./02. Christmas Movies_Resources');




describe('ChristmasMovies', () => {

    let christmas;
	beforeEach(function() {
		christmas = new ChristmasMovies();
	})

    describe('Constructor propertis should work corectly', () => {

        it('Should work corectly', () => {
            expect(christmas.movieCollection).to.eql([]);
            expect(christmas.movieCollection.length).to.deep.equal(0);
            expect(christmas.watched).to.eql({});
            expect(christmas.actors).to.eql([]);
            expect(christmas.actors.length).to.deep.equal(0);
        })
    })

    describe('buyMovie', () => {
        
        it('Should returt that the moveie is added to the colection', () => {
            let output = christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);

            expect(output).to.equal('You just got Home Alone 2 to your collection in which Macaulay Culkin are taking part!')
        })

        it('Should returt that the moveie is added to the colection whit arr of actors', () => {
            let output = christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

            expect(output).to.equal('You just got The Grinch to your collection in which Benedict Cumberbatch, Pharrell Williams are taking part!')
        })

         it('Should Throw exeption when allredy have the movie in our colection', () => {
             christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

             expect(() => christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']))
             .to.throw(Error, 'You already own The Grinch in your collection!');
         })
    })

    describe('discardMovie', () => {
        it('Should thorl if movie is not in your colection', () => {

            expect(() => christmas.discardMovie('The Grinch')).to.throw(Error, 'The Grinch is not at your collection!')
        })

        it('Should throw error if movie is not whatched', () => {
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);

            expect(() => christmas.discardMovie('The Grinch')).to.throw(Error, 'The Grinch is not watched!')

        })

        it('Should that the movie is discarded', () => {
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
            christmas.watchMovie('The Grinch');

            expect(christmas.discardMovie('The Grinch')).to.equal('You just threw away The Grinch!');
        })
    })

    describe('watchMovie', () => {
    
        it('Should add one to watched movies', () => {
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
            christmas.watchMovie('The Grinch');
            expect(christmas.watched['The Grinch']).to.deep.equal(1);

        })

        it('Should uppdate movie wached times', () => {
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
            christmas.watchMovie('The Grinch');
            christmas.watchMovie('The Grinch');
            expect(christmas.watched['The Grinch']).to.deep.equal(2);

        })

        it('Should throw if thre is no movie in the colection', () => {
            expect(() => christmas.watchMovie('The Grinch')).to.throw(Error, 'No such movie in your collection!');
        })
    })

    describe('favouriteMovie', () => {
        it('Should return favorite movie', () => {
            christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.watchMovie('Home Alone')
            christmas.watchMovie('The Grinch');
            christmas.watchMovie('The Grinch');

            expect(christmas.favouriteMovie()).to.equal('Your favourite movie is The Grinch and you have watched it 2 times!');
        })

        it('Should throw error if no moveis are watched', () => {
            expect(() => christmas.favouriteMovie()).to.throw(Error, 'You have not watched a movie yet this year!');
        })
    })

    describe('mostStarredActor', () => {
        it('Should return how is most starredActor', () => {
            christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
            christmas.buyMovie('Home Alone 3', ['Macaulay Culkin', 'Emilia Clarke']);
            christmas.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);

            christmas.watchMovie('Home Alone');

            expect(christmas.mostStarredActor()).to.equal('The most starred actor is Macaulay Culkin and starred in 3 movies!');
        })

        it('Should throw if no movie is watch this year', () => {
            expect(() => christmas.mostStarredActor()).to.throw(Error, 'You have not watched a movie yet this year!');
        })
    })
})