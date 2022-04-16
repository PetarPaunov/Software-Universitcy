import {html} from '../node_modules/lit-html/lit-html.js';
import { register } from '../src/api/data.js';
import { updateUserNav } from '../src/api/updateUser.js';

const registerTemplate = (onRegister) => html`
<section id="register">
    <div class="container">
        <form id="register-form" @submit="${onRegister}">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>
`;

export function registerPage(ctx){
    ctx.render(registerTemplate(onRegister));

    async function onRegister(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const username = formData.get('username');
        const password = formData.get('password');
        const repeatPass = formData.get('repeatPass');

        if(password != repeatPass){
            alert('Passwords dont match');
            return;
        }

        if(username =='' || password == "" || repeatPass == ''){
            alert('incorect information');
            return;
        }

        await register(username, password);
        updateUserNav();
        ctx.page.redirect('/catalog');
    }
}