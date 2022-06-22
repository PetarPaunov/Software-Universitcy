import { login } from "../api/data.js";
import { notify } from "../api/notify.js";
import { updateUserNav } from "../api/updateUser.js";
import { html } from "../lib.js";

const loginTemplate = (onLogin) => html`
<section id="login">
    <form id="login-form" @submit="${onLogin}">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
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

        if(email == '' || password == ''){
            notify('All fields shold fild')
            return;
        }

        await login(email, password);
        updateUserNav();
        ctx.page.redirect('/allmemes')
    }
}