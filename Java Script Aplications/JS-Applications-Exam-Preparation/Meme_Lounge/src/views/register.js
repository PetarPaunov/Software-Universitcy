import { login, register } from "../api/data.js";
import { notify } from "../api/notify.js";
import { updateUserNav } from "../api/updateUser.js";
import { html } from "../lib.js";

const registerTemplate = (onRegister) => html`
<section id="register">
    <form id="register-form" @submit="${onRegister}">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>
`;


export function registerPage(ctx){
    ctx.render(registerTemplate(onRegister));

    async function onRegister(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const username = formData.get('username');
        const email = formData.get('email');
        const password = formData.get('password');
        const repeatPass = formData.get('repeatPass');
        const gender = formData.get('gender');

        if(username == '' || email == '' || password == '' || repeatPass == '' || gender == ''){
            notify('All fields must be filed');
            return
        }

        if(repeatPass != password){
            notify("Passwords dont match");
            return;
        }

        await register(username, email, password, gender);
        updateUserNav();
        ctx.page.redirect('/allmemes');
    }
}