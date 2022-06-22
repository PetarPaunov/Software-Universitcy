
import { render } from "./lib.js";
import page from "../node_modules/page/page.mjs";
import { showCatalog } from "./views/catalog.js";
import { showCreate } from "./views/create.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showLogin } from "./views/login.js";
import { showMy } from "./views/my-furnitures.js";
import { showRegister } from "./views/register.js";
import { logout } from "./api/data.js";


const root = document.querySelector('div.container');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', showCatalog);
page('/create', showCreate);
page('/my-furniture', showMy);
page('/edit/:id', showEdit);
page('/login', showLogin);
page('/register', showRegister);
page('/details/:id', showDetails);

page.start();


function decorateContext(ctx, next){
    ctx.render = (content) => render(content, root)
    next();
}

async function onLogout(){
    await logout();
    page.redirect('/');
}

