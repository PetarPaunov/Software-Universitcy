import { getAll } from "../api/data.js";
import { updateUserNav } from "../api/updateUser.js";
import { html, until } from "../lib.js";

const catalogTemplate = (dataPromis) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
   ${until(dataPromis, html`<p>Loading &hellip;</p>`)}
</div>
`

const itemTemplate = (item) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
                <img src=${item.img} />
                <p>${item.description}</p>
                <footer>
                    <p>Price: <span>${item.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${item._id}" class="btn btn-info">Details</a>
                </div>
        </div>
    </div>
</div>
`


export function showCatalog(ctx){
    ctx.render(catalogTemplate(getItems()))
    updateUserNav();
}

async function getItems(){
    let data = await getAll();
    return data.map(itemTemplate);
}