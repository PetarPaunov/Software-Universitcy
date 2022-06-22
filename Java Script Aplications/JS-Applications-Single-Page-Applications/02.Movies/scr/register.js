import { updateNav } from "./app.js";
import { homeViwe } from "./home.js";
import { showViwe } from "./rauter.js";

let registerSection = document.querySelector('#form-sign-up');

export function registerViwe(){
    showViwe(registerSection);
}

let form = registerSection.querySelector('form');

form.addEventListener('submit', onRegister);

async function onRegister(e){
    e.preventDefault();
    
    let formData = new FormData(e.target);
    let email = formData.get('email')
    let password = formData.get('password');
    let repass = formData.get('repeatPassword');

    if(password != repass){
        alert('Repass doesnt match');
        form.reset();
        return;
    }
    if(password.length < 6){
        alert('Password must be atlist 6 symbols');
        form.reset();
        return;
    }
    if(email == undefined){
        alert('Shold feel email input field');
        form.reset();
        return;
    }

    let url = `http://localhost:3030/users/register`;
    let res = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'aplication/json',
        },
        body: JSON.stringify({email, password})
    })
    let data = await res.json();

    sessionStorage.setItem('userData', JSON.stringify({
        email: data.email,
        id: data._id,
        token: data.accessToken
    }))
    
    form.reset();

    updateNav();
    homeViwe();

}