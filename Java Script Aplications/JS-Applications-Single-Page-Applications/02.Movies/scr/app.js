import { addMovieViwe } from "./addmovie.js";
import { homeViwe } from "./home.js";
import { loginViwe } from "./login.js";
import { registerViwe } from "./register.js";

const rauts ={
    '/': homeViwe,
    '/login': loginViwe,
    '/register': registerViwe,
    '/create' : addMovieViwe,
    '/logout' : logout,

}
let nav = document.querySelector('nav')
nav.addEventListener('click', onNavigate);
document.querySelector('#add-movie-button a').addEventListener('click', onNavigate);

export function updateNav(){
    let userData = JSON.parse(sessionStorage.getItem('userData'));

    if(userData != null){
        nav.querySelector('#welcomeMsg').textContent = 'Welcome,  ' + userData.email;
        [...nav.querySelectorAll('.user')].forEach(x => x.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'none');
        document.querySelector('#add-movie-button a').style.display = 'inline-block';
    }else{
        [...nav.querySelectorAll('.user')].forEach(x => x.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'block');
        document.querySelector('#add-movie-button a').style.display = 'none';

    }
}
updateNav();

function onNavigate(e){
    if(e.target.tagName == 'A' && e.target.href){
        e.preventDefault();
        let url = new URL(e.target.href);

        let view = rauts[url.pathname];
        if(typeof view == 'function'){
            view();
        }
    }
}

async function logout(){
    let { token } = JSON.parse(sessionStorage.getItem('userData'));

    await fetch('http://localhost:3030/users/logout', {
        headers: {
            'X-Authorization': token
        }
    });

    sessionStorage.removeItem('userData');
    updateNav();
    loginViwe();
}

homeViwe();



