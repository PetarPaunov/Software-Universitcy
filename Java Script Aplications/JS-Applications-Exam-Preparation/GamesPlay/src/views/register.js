import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "../api/data.js";
import { updateUserNav } from "../api/updateUser.js";

const registerTemplate = (onRegister) => html`
<section id="register-page" class="content auth">
    <form id="register" @submit="${onRegister}">
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </div>
    </form>
</section>
`;


export function registerPage(ctx){
    ctx.render(registerTemplate(onRegister));

    async function onRegister(e){
        e.preventDefault();
        const formData = new FormData(e.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('confirm-password');

        if(email == '' || password == '' || rePass == ''){
            alert('All filds must be filled');
            return;
        }
        if(password != rePass){
            alert('incorect passwords');
            return;
        }

        await register(email, password);
        updateUserNav();
        ctx.page.redirect('/');
    }
}