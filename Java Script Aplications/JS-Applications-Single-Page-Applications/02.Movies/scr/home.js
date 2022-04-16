import { ditailsViwe } from "./details.js";
import { showViwe } from "./rauter.js";

let homeSection = document.querySelector('#home-page');
let catalog = document.querySelector('.card-deck.d-flex.justify-content-center');

export function homeViwe(){
    showViwe(homeSection);
    getMovies();
}

catalog.addEventListener('click', function(e){
    e.preventDefault();
    let target = e.target;
    if(target.tagName == 'BUTTON'){
        target = target.parentElement;
    }
    if(target.tagName == 'A'){
        let id = target.dataset.id;
        ditailsViwe(id);
    }
})

async function getMovies(){
    const url = `http://localhost:3030/data/movies`;
    const res = await fetch(url);
    const data = await res.json();

    catalog.replaceChildren(...data.map(createMovies));
}   

function createMovies(movie){
    let headDiv = document.createElement('div');
    headDiv.setAttribute('class', 'card mb-4');
    headDiv.setAttribute('data-owner-id', movie._ownerId);
    
    let img = document.createElement('img');
    img.setAttribute('class', 'card-img-top');
    img.setAttribute('src', movie.img);
    img.setAttribute('alt', 'Card image cap');
    img.setAttribute('width', 400);
    headDiv.appendChild(img);

    let bodyDiv = document.createElement('div');
    bodyDiv.setAttribute('class', 'card-body');

    let h4 = document.createElement('h4');
    h4.setAttribute('class', 'card-title');
    h4.textContent = movie.title;
    bodyDiv.appendChild(h4);

    headDiv.appendChild(bodyDiv);

    let footerDiv = document.createElement('div');
    footerDiv.setAttribute('class', 'card-footer');

    let a = document.createElement('a');
    a.setAttribute('href', '#');
    a.setAttribute('data-id', movie._id);

    let button = document.createElement('button');
    button.type = 'button';
    button.setAttribute('class', "btn btn-info");
    button.textContent = 'Details';
    a.appendChild(button);
    footerDiv.appendChild(a);

    headDiv.appendChild(footerDiv);

    return headDiv;
}

