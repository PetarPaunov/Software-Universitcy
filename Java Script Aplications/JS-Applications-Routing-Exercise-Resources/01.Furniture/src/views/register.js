import { register } from "../api/data.js";
import { updateUserNav } from "../api/updateUser.js";
import { html } from "../lib.js";

const registerTemplate = (onRegister) => html`
<form @submit= ${onRegister}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>
`;

export function showRegister(ctx){
    ctx.render(registerTemplate(onRegister));

    async function onRegister(e){
        e.preventDefault();
    
        const formData = new FormData(e.target);
    
        let email = formData.get('email');
        let password = formData.get('password');
        let rePass = formData.get('rePass');
    
        if(email == '' || password == ''){
            return alert('All fields are required');
        }

        if(password != rePass){
            return alert('Passwords don\'t match');
        }
    
        const data = await register(email, password);

        updateUserNav();
        ctx.page.redirect('/');
    }
}

