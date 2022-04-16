class LibraryCollection{
    constructor(capacity){

        this.capacity = capacity;
        this.books = [];  
    }

    addBook (bookName, bookAuthor){
        if(this.books.length == this.capacity){
            throw new Error("Not enough space in the collection.");
        }

        let curentBook = {
            bookName: bookName,
            bookAuthor: bookAuthor,
            payed: false
        }

        this.books.push(curentBook);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook( bookName ){
        let book = this.books.find(x => x.bookName == bookName);
        if(book == undefined){
            throw new Error(`${bookName} is not in the collection.`);
        }

        if(book.payed == true){
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName){
        let book = this.books.find(x => x.bookName == bookName);

        if(book == undefined){
            throw new Error("The book, you're looking for, is not found.");
        }

        if(book.payed == false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books.filter(x => x.bookName != bookName);

        return `${bookName} remove from the collection.`;
    } 

    getStatistics(bookAuthor){
        let result = [];
        if(bookAuthor == undefined){
            let emptySlots = this.capacity - this.books.length;
            result.push(`The book collection has ${emptySlots} empty spots left.`);
            this.books.sort((a,b) => a.bookName.localeCompare(b.bookName));

            this.books.forEach(x => {

                result.push(`${x.bookName} == ${x.bookAuthor} - ${x.payed == true ? `Has Paid` : `Not Paid`}.`);
            })

            return result.join('\n');
        }else{
            let curentAuthorBooks = [];

            for (const iterator of this.books) {
                if(iterator.bookAuthor == bookAuthor){
                    curentAuthorBooks.push(iterator);
                }
            }

            if(curentAuthorBooks.length == 0){
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            curentAuthorBooks.forEach(x => {
                result.push(`${x.bookName} == ${x.bookAuthor} - ${x.payed == true ? `Has Paid` : `Not Paid`}.`);
            })

            return result.join('\n');
        }
    }


}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());



