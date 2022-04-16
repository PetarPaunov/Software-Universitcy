import { html } from "../node_modules/lit-html/lit-html.js";
import { register } from "../src/api/data.js";
import { updateUserNav } from "../src/api/updateUser.js";

const registerTemplate = (onRegister) => html`
<section id="register-page" class="register">
    <form id="register-form" action="" method="" @submit="${onRegister}">
        <fieldset>
            <legend>Register Form</legend>
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
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
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
        const rePass = formData.get('confirm-pass');

        if(password == '' || email == '', rePass == ''){
            alert('All fields should be filed');
            return;
        }

        if(password != rePass){
            alert('incorect Passwords');
            return;
        }

        await register(email, password);
        updateUserNav();
        ctx.page.redirect('/');
    }
}
