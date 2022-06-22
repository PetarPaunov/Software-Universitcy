import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";
import { logout } from "./api/data.js";
import { updateUserNav } from "./api/updateUser.js";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { homePage } from "./views/home.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";

updateUserNav();

const root = document.getElementById('main-content');
document.getElementById('logout').addEventListener('click', onLogout);

page(decorationMiddlewere);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/catalog', catalogPage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page.start();


function decorationMiddlewere(ctx, next){
    ctx.render = (content) => render(content, root);
    next(); 
}

async function onLogout(){
    await logout();
    updateUserNav();
    page.redirect('/');
}