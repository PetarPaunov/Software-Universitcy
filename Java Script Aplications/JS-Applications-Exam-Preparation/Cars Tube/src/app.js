import page from "../node_modules/page/page.mjs";
import { render } from "../node_modules/lit-html/lit-html.js";
import { updateUserNav } from "./api/updateUser.js";
import { homePage } from "../views/home.js";
import { loginPage } from "../views/login.js";
import { registerPage } from "../views/register.js";
import { logout } from "./api/data.js";
import { catalogPage } from "../views/catalog.js";
import { createPage } from "../views/create.js";
import { detailsPage } from "../views/details.js";
import { editPage } from "../views/edit.js";
import { profilePage } from "../views/profile.js";
import { searchPage } from "../views/search.js";

const root = document.getElementById('site-content');
document.getElementById('logout').addEventListener('click', onLogot);
updateUserNav();

page(decorationMiddlelere);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/catalog', catalogPage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/profile', profilePage)
page('/search', searchPage)
page.start();


function decorationMiddlelere(ctx, next){
    ctx.render = (content) => render(content, root);
    next();
}

async function onLogot(){
    await logout();
    updateUserNav();
    page.redirect('/');
}