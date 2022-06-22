import { showViwe } from "./rauter.js";

let editSection = document.querySelector('#edit-movie');

export function editViwe(movieId){
    showViwe(editSection);
    movieInfo(movieId);
}

let form = editSection.querySelector('form');




function movieInfo(e){
    let info = e.target.parentElement.parentElement

    let h1 = info.querySelector('h1').textContent;
    let titleElement = h1.split(': ')[1];
    
    let p = info.querySelector('p').textContent;

    let img = info.querySelector('img');
    let src = img.src;

    return { h1, p, src};
}