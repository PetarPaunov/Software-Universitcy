function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getPosts);
    document.getElementById('btnViewPost').addEventListener('click', displayInformation);
}

attachEvents();

async function displayInformation(){
    let selectedId = document.getElementById('posts').value;

    let tytle = document.getElementById('post-title');
    let body = document.getElementById('post-body');

    let commentUl = document.getElementById('post-comments');
    commentUl.replaceChildren();
    tytle.textContent = 'Loading...'
    body.textContent = '';

    
    let filtredComments = await getCommentsById(selectedId);
    let curentPost = await getPostsById(selectedId);

    tytle.textContent = curentPost.title;
    body.textContent = curentPost.body;

    filtredComments.forEach(x => {
        let liElement = document.createElement('li');
        liElement.id = x.id;
        liElement.textContent = x.text;
        commentUl.appendChild(liElement);
    })

}

async function getPosts(){
    let postElement = document.getElementById('posts');
    postElement.replaceChildren();
    let url = `http://localhost:3030/jsonstore/blog/posts`;
    let res = await fetch(url);
    let data = await res.json();

    Object.values(data).forEach(x => {
        let optionElement = document.createElement('option');
        optionElement.textContent = x.title;
        optionElement.value = x.id;

        postElement.appendChild(optionElement);
    })
}

async function getCommentsById(postId){
    let url = `http://localhost:3030/jsonstore/blog/comments`;
    let res = await fetch(url);
    let data = await res.json();

    let commnets = Object.values(data).filter(x => x.postId == postId);

    return commnets;
}

async function getPostsById(postId){
    let url = `http://localhost:3030/jsonstore/blog/posts/${postId}`;
    let res = await fetch(url);
    let data = await res.json();

    return data;
}