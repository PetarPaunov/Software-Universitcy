import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { updateUserNav } from "./api/updateUser.js";
import { loginPage } from "../views/login.js";
import { registerPage } from "../views/register.js";
import { homePage } from "../views/home.js";
import { logout } from "./api/data.js";
import { createPage } from "../views/create.js";
import { detailsPage } from "../views/details.js";
import { editPage } from "../views/edit.js";
import { profilePage } from "../views/profile.js";

updateUserNav();
const root = document.getElementById('content');
document.querySelector('.logout').addEventListener('click', onLogout);

page(decorationMiddleWere);
page('/login', loginPage)
page('/register', registerPage)
page('/', homePage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/profile', profilePage)
page.start();




function decorationMiddleWere(ctx, next){
    ctx.render = (content) => render(content, root);
    next();
}

async function onLogout(){
    await logout();
    updateUserNav();
    page.redirect('/');
}