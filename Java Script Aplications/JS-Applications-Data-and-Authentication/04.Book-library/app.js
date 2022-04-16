let tbodyElement = document.querySelector('tbody');
tbodyElement.addEventListener('click', onTableClick);
document.getElementById('loadBooks').addEventListener('click', getAllBooks);
let createForm = document.getElementById('createForm');
createForm.addEventListener('submit', postNewBook);
let editForm = document.getElementById('editForm');
editForm.addEventListener('submit', onEditSubmit);

async function onEditSubmit(e){
    e.preventDefault();

    let bookInfo = new FormData(e.target);

    let id = bookInfo.get('id');
    let title = bookInfo.get('title');
    let author = bookInfo.get('author');

    if(title == '' || author == ''){
        return;
    }

    let updatedBook = {
        "author": author,
        "title": title
    }

    onEdit(id, updatedBook);

    createForm.style.display = 'block';
    editForm.style.display = 'none';
}

async function onTableClick(e){
    if(e.target.classList == 'delete'){
        deleteBook(e.target);
    }else if(e.target.classList == 'edit'){
        editBook(e.target);
    }
}
async function editBook(target){
    let book = await loadBookById(target.dataset.id);

    createForm.style.display = 'none';
    editForm.style.display = 'block';
    
    editForm.querySelector('[name="id"]').value = target.dataset.id;
    editForm.querySelector('[name="author"]').value = book.author;
    editForm.querySelector('[name="title"]').value = book.title;

}

async function onEdit(id, book){
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;
    let responce = await fetch(url,{
        method: 'PUT',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify(book)
    });
    getAllBooks();

}

async function loadBookById(id){
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    let responce = await fetch(url);
    let data = await responce.json();

    return data;
}


async function deleteBook(target){
    let url = `http://localhost:3030/jsonstore/collections/books/${target.dataset.id}`;
    let responce = await fetch(url,{
        method: 'DELETE',
    });

    target.parentElement.parentElement.remove();
}

async function getAllBooks(){
    let url = `http://localhost:3030/jsonstore/collections/books`;
    let responce = await fetch(url);
    let data = await responce.json();

    let el = tbodyElement.querySelectorAll('tr');
    el.forEach(x => x.remove());
    Object.entries(data).map(([id, book]) => createNewBook(id, book))
}

async function postNewBook(e){
    e.preventDefault();

    let bookInfo = new FormData(e.target);
    let title = bookInfo.get('title');
    let author = bookInfo.get('author');

    if(title == '' || author == ''){
        return;
    }

    let createdBook = {
        "author": author,
        "title": title
    }

    let url = `http://localhost:3030/jsonstore/collections/books`;

    let responce = await fetch(url,{
        method: 'POST',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify(createdBook)
    });
    let data = await responce.json();

}

function createNewBook(id, book){
    let tr = document.createElement('tr');

    let tdTitleElement = document.createElement('td');
    tdTitleElement.textContent = book.title;
    tr.appendChild(tdTitleElement);

    let tdAuthorElement = document.createElement('td');
    tdAuthorElement.textContent = book.author;
    tr.appendChild(tdAuthorElement);

    let tdButtonElements = document.createElement('td');

    let editButtun = document.createElement('button');
    editButtun.textContent = 'Edit';
    editButtun.classList.add('edit')
    editButtun.setAttribute('data-id', id);
    tdButtonElements.appendChild(editButtun);

    let deleteButtun = document.createElement('button');
    deleteButtun.textContent = 'Delete';
    deleteButtun.classList.add('delete');
    deleteButtun.setAttribute('data-id', id);
    tdButtonElements.appendChild(deleteButtun);

    tr.appendChild(tdButtonElements);

    tbodyElement.appendChild(tr);
}


