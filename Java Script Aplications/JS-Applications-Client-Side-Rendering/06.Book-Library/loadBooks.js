import { bookTemplate } from "./book.js";
import { render } from "./utils.js";

export async function onLoad(){
    const url = `http://localhost:3030/jsonstore/collections/books`;
    let res = await fetch(url);
    let data = await res.json();
    let tbody = document.querySelector('tbody');
    let books = [];

    Object.entries(data).forEach(x => {
        let [id, book] = x;
        books.push(bookTemplate(id,book));
    })

    render(books, tbody);
}