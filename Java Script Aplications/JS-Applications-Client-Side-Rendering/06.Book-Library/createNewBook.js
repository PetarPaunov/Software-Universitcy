import { onLoad } from "./loadBooks.js";


export async function onAdd(e){
    e.preventDefault();
    let form = new FormData(e.target);

    let title = form.get('title');
    let author = form.get('author');

    if(title == '' || author == ''){
        return;
    }

    const url = `http://localhost:3030/jsonstore/collections/books`;
    const res = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({title, author})
    })
    let data = await res.json();

    e.target.reset();
    onLoad()

}
