import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "../api/data.js";
import { updateUserNav } from "../api/updateUser.js";

const loginTemplate = (onLogin) => html`
<section id="loginPage">
    <form @submit="${onLogin}">
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="#">here</a></span>
            </p>
        </fieldset>
    </form>
</section>
`;

export function loginPage(ctx){
    
    ctx.render(loginTemplate(onLogin));
    
    async function onLogin(e){
        e.preventDefault();

        const formData = new FormData(e.target);
        const email = formData.get('email');
        const password = formData.get('password');

        if(email == ''|| password == ''){
            alert('allFields must be filed');
            return;
        }

        await login(email, password);
        updateUserNav();
        ctx.page.redirect('/');
    }
}