import { bookViwe } from "./bookViwe.js";
import { createViwe } from "./create.js";
import { onAdd } from "./createNewBook.js";
import { onLoad } from "./loadBooks.js";
import { updateViwe } from "./update.js";
import { render } from "./utils.js";

let root = document.querySelector('body');

const ctx = {
    render: (template) => render(template, root)
}

ctx.render([
    bookViwe(),
    createViwe(),
]);

document.getElementById('loadBooks').addEventListener('click', onLoad);
document.getElementById('add-form').addEventListener('submit', onAdd);
root.addEventListener('click', onDelete);


async function onEdit(e){
    e.preventDefault();
    let form = new FormData(e.target);

    let id = form.get('id');
    let title = form.get('title');
    let author = form.get('author');

    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;
    let res = await fetch(url,{
        method: 'PUT',
        headers:{
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify({title, author})

    })
    onLoad();
}

async function onDelete(e){
    let event = e.target;
    if(event.tagName == 'BUTTON'){
        if(event.textContent == 'Delete'){
            e.preventDefault();

            let id = event.parentElement.parentElement.dataset.id;
            let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

            let res = await fetch(url,{
                method: 'DELETE'
            })
            let data = await res.json();
            onLoad();

        }else if(event.textContent == 'Edit'){
            e.preventDefault();
            ctx.render([
                bookViwe(),
                updateViwe(),
            ]);
            let id = event.parentElement.parentElement.dataset.id;
            let title = event.parentElement.parentElement.querySelector('td:nth-child(1)').textContent;
            let author = event.parentElement.parentElement.querySelector('td:nth-child(2)').textContent;
            let form = document.getElementById('edit-form');
            let inputTitle = form.querySelector('input[name="title"]').value = title;
            let inputAuthor = form.querySelector('input[name="author"]').value = author;
            let inputHidden = form.querySelector('input[name="id"]').value = id;

            document.getElementById('edit-form').addEventListener('submit', onEdit);

        }
    }
}




