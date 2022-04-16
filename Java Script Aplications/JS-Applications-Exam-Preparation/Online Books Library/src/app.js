import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";
import { detailsPage } from "../views/catalog.js";
import { createPage } from "../views/create.js";
import { editPage } from "../views/edit.js";
import { homePage } from "../views/home.js";
import { loginPage } from "../views/login.js";
import { myBooksPage } from "../views/myBooks.js";
import { registerPage } from "../views/register.js";
import { logout } from "./api/data.js";
import { updateUserNav } from "./api/updateUser.js";

updateUserNav();

const root = document.getElementById('site-content');
document.getElementById('logout').addEventListener('click', onLogin);

page(decorationMiddleware);
page('/login', loginPage);
page('/register', registerPage);
page('/', homePage);
page('/details/:id', detailsPage)
page('/create', createPage)
page('/edit/:id', editPage)
page('/my-books', myBooksPage)
page.start();



function decorationMiddleware(ctx, next){
    ctx.render = (content) => render(content, root);
    next();
}


async function onLogin(){
    await logout();
    updateUserNav();
    page.redirect('/');
}