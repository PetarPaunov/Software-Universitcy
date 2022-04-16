import { html } from "../node_modules/lit-html/lit-html.js";
import { login } from "../src/api/data.js";
import { updateUserNav } from "../src/api/updateUser.js";

const loginTemplate = (onLogin) => html`
<section id="login-page" class="login">
    <form id="login-form" action="" method="" @submit="${onLogin}">
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
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

        if(password == '' || email == ''){
            alert('All fields should be filed');
            return;
        }

        await login(email, password);
        updateUserNav();
        ctx.page.redirect('/');
    }
}
