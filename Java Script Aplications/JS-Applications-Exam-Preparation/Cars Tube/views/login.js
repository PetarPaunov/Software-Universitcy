import {html} from '../node_modules/lit-html/lit-html.js';
import { login } from '../src/api/data.js';
import { updateUserNav } from '../src/api/updateUser.js';

const loginTemplate = (onLogin) => html`
<section id="login">
    <div class="container">
        <form id="login-form" action="#" method="post" @submit=${onLogin}>
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>
`;

export function loginPage(ctx){
    ctx.render(loginTemplate(onLogin));

    async function onLogin(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const username = formData.get('username');
        const password = formData.get('password');

        if(username =='' || password == ""){
            alert('incorect information');
            return;
        }

        await login(username, password);
        updateUserNav();
        ctx.page.redirect('/catalog');
    }
}