import { homeViwe } from "./home.js";
import { showViwe } from "./rauter.js";

let addMovieSection = document.querySelector('#add-movie');

export function addMovieViwe(){
    showViwe(addMovieSection);
}

let form = addMovieSection.querySelector('form');

form.addEventListener('submit', addMovie);

async function addMovie(e){
    e.preventDefault();
    let formData = new FormData(e.target);
    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');
    let { token } = JSON.parse(sessionStorage.getItem('userData'));
    const url = `http://localhost:3030/data/movies`;
    let res = await fetch(url,{
        method: 'POST',
        headers:{
            'Content-Type': 'aplication/json',
            'X-Authorization': token
        },
        body: JSON.stringify({
            title,
            description,
            img: imageUrl
        })
    })
    let data = await res.json();

    homeViwe();
}