import { render } from "../node_modules/lit-html/lit-html.js";
import page from "../node_modules/page/page.mjs";
import { logout } from "./api/data.js";
import { updateUserNav } from "./api/updateUser.js";
import { loginPage } from "../views/login.js";
import { registerPage } from "../views/register.js";
import { homePage } from "../views/home.js";
import { dashBoardPage } from "../views/dashboard.js";
import { createPage } from "../views/create.js";
import { detailsPage } from "../views/details.js";
import { editPage } from "../views/edit.js";

const root = document.querySelector('main');
document.querySelector('.logoutUser').addEventListener('click', onLogout);

updateUserNav();

page(decorationMiddlewhere);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/dashboard', dashBoardPage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
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