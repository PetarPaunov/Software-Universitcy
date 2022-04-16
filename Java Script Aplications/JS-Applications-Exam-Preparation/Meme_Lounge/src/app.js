import { render } from "./lib.js";
import page from "../node_modules/page/page.mjs";
import { homePage } from "./views/home.js";
import { updateUserNav } from "./api/updateUser.js";
import { loginPage } from "./views/login.js";
import { registerPage } from "./views/register.js";
import { logout } from "./api/data.js";
import { createPage } from "./views/create.js";
import { memesPage } from "./views/allmemes.js";
import { detailsPage } from "./views/details.js";
import { editPage } from "./views/edit.js";
import { profilePage } from "./views/profile.js";

const root = document.querySelector('main');
document.getElementById('logout').addEventListener('click', onLogout);

updateUserNav();

page(decorationMiddlewhere);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/create', createPage)
page('/allmemes', memesPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/profile', profilePage)
page.start();


function decorationMiddlewhere(ctx, next){
    ctx.render = (content) => render(content, root);
    next();
}

async function onLogout(){
    await logout();
    updateUserNav();
    page.redirect('/')
}