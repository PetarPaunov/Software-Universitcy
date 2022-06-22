import { editViwe } from "./edit.js";
import { homeViwe } from "./home.js";
import { showViwe } from "./rauter.js";

let ditailsSection = document.querySelector('#movie-example');

export function ditailsViwe(movieId){
    getMovie(movieId);
    showViwe(ditailsSection);
}
let userData = JSON.parse(sessionStorage.getItem('userData'));

async function getMovie(id){
    let p = document.createElement('p').textContent = 'Loading...'
    ditailsSection.replaceChildren(p);
    let requests = [
        fetch(`http://localhost:3030/data/movies/` + id),
        fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`),
    ];

    if(userData != null){
        requests.push(fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userData.id}%22`))
    };

    let [moviesRes, moviesLikes, hasLikledRes] = await Promise.all(requests)
    let [movieData, likes, hasLiked] = await Promise.all([
        moviesRes.json(),
        moviesLikes.json(),
        hasLikledRes && hasLikledRes.json()
    ])
    ditailsSection.replaceChildren(ditailMovie(movieData, likes, hasLiked));
}

function ditailMovie(movie, likes, hasLiked){
    let headDiv = document.createElement('div');
    headDiv.setAttribute('class', "container");

    let secondDiv = document.createElement('div');
    secondDiv.setAttribute('class', "row bg-light text-dark");

    let h1 = document.createElement('h1');
    h1.textContent = `Movie title: ${movie.title}`;
    secondDiv.appendChild(h1);

    let imageDiv = document.createElement('div');
    imageDiv.setAttribute('class', "col-md-8");

    let img = document.createElement('img');
    img.setAttribute('class', "img-thumbnail");
    img.setAttribute('src', movie.img);
    img.setAttribute('alt', 'Movie');
    imageDiv.appendChild(img);
    secondDiv.appendChild(imageDiv);

    let thirdDiv = document.createElement('div');
    thirdDiv.setAttribute('class', "col-md-4 text-center");

    let h3 = document.createElement('h3');
    h3.setAttribute('class', 'my-3');
    h3.textContent = 'Movie Description';
    thirdDiv.appendChild(h3);

    let p = document.createElement('p');
    p.textContent = movie.description;
    thirdDiv.appendChild(p);

    let userData = JSON.parse(sessionStorage.getItem('userData'));
    if(userData != null){
        if(userData.id == movie._ownerId){
            let deleteA = document.createElement('a');
            deleteA.setAttribute('class', "btn btn-danger");
            deleteA.setAttribute('href', '#');
            deleteA.textContent = 'Delete'
            deleteA.addEventListener('click', onDelete);
            thirdDiv.appendChild(deleteA);


            let editA = document.createElement('a');
            editA.setAttribute('class', "btn btn-warning");
            editA.setAttribute('href', '#');
            editA.textContent = 'Edit'
            editA.addEventListener('click', editViwe);
            thirdDiv.appendChild(editA);
        }else{
            if(hasLiked.length > 0){
                let likeA = document.createElement('a');
                likeA.setAttribute('class', "btn btn-primary");
                likeA.setAttribute('href', '#');
                likeA.textContent = 'Unlike'
                likeA.addEventListener('click', onUnlike);
                thirdDiv.appendChild(likeA);
            }else{
                let likeA = document.createElement('a');
                likeA.setAttribute('class', "btn btn-primary");
                likeA.setAttribute('href', '#');
                likeA.textContent = 'Like';
                likeA.addEventListener('click', onLike);
                thirdDiv.appendChild(likeA);
            }
        }
    }
    let span = document.createElement('span');
    span.setAttribute('class', "enrolled-span");
    span.textContent = `Likes ${likes}`;
    thirdDiv.appendChild(span);

    secondDiv.appendChild(thirdDiv);
    headDiv.appendChild(secondDiv);

    async function onLike(e){
        e.preventDefault();
        let res = await fetch(`http://localhost:3030/data/likes`,{
            method: 'POST',
            headers: {
                'Content-Type': 'aplication/json',
                'X-Authorization': userData.token
            },
            body: JSON.stringify({ movieId: movie._id})
        });
        ditailsViwe(movie._id);
    }

    async function onUnlike(e){
        e.preventDefault();
        let likedId = hasLiked[0]._id;
        let res = await fetch(`http://localhost:3030/data/likes/${likedId}`,{
            method: 'DELETE',
            headers: {
                'X-Authorization': userData.token
            },
        });
    
        ditailsViwe(movie._id);
    }

    async function onDelete(e){
        e.preventDefault();
        let url = `http://localhost:3030/data/movies/${movie._id}`;
        let res = await fetch(url,{
            method: 'DELETE',
            headers: {
                'X-Authorization': userData.token
            },
        });
        homeViwe();
    }

    return headDiv;
}

