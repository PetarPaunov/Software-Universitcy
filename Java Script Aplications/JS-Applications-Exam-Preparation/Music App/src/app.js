import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";
import { homePage } from "./views/home.js";
import { updateUserNav } from "./api/updateUser.js";
import { registerPage } from "./views/register.js";
import { loginPage } from "./views/login.js";
import { logout } from "./api/data.js";
import { catalogPage } from "./views/catalog.js";
import { createPage } from "./views/create.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { searchPage } from "./views/search.js";



const root = document.getElementById('main-content');
document.getElementById('logout').addEventListener('click', onLogout);
updateUserNav();

page(decorationMiddlewere);
page('/', homePage);
page('/register', registerPage);
page('/login', loginPage);
page('/catalog', catalogPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/search', searchPage);
page.start();



async function onLogout(){
    await logout();
    updateUserNav();
    page.redirect('/');
}


function decorationMiddlewere(ctx, next){
    ctx.render = (content) => render(content, root);
    next();
}