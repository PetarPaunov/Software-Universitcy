import { homeViwe } from "./home.js";
import { showViwe } from "./rauter.js";
import { updateNav } from "./app.js"

let loginSection = document.querySelector('#form-login');
export function loginViwe(){
    showViwe(loginSection);
}

let form = document.querySelector('#form-login form');

form.addEventListener('submit', onLogin);

async function onLogin(e){
    e.preventDefault();
    let formData = new FormData(e.target);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();

    try {
        let res = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'aplication/json'
            },
            body: JSON.stringify({email, password})
    
        });
        if(res.ok != true){
            let error = await res.json();
            throw new Error(error.message);
        }
        let data = await res.json();

        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }))

        form.reset();
        updateNav();
        homeViwe();
    } catch (error) {
        alert(error.message);
    }
}

