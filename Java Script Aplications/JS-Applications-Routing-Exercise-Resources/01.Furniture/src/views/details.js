import { deleteItem, getById } from "../api/data.js";
import { html, until } from "../lib.js";

const detailsTemplate = (itemPromis) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    ${until(itemPromis, html`<p>Loading...</p>`)}
</div>
`;

const itemTemplate = (item, isOwner, onDelete) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src="${item.img}" />
        </div>
    </div>
</div>
<div class="col-md-4">
    <p>Make: <span>${item.make}</span></p>
    <p>Model: <span>${item.model}</span></p>
    <p>Year: <span>${item.year}</span></p>
    <p>Description: <span>${item.description}</span></p>
    <p>Price: <span>${item.price}</span></p>
    <p>Material: <span>${item.material}</span></p>
    ${isOwner ? html`<div>
        <a href="/eidt/${item._id}" class="btn btn-info">Edit</a>
        <a href="javascript:void(0)" @click=${onDelete} class="btn btn-red">Delete</a>
    </div>` : null}
</div>
`;

export function showDetails(ctx){
    const id = ctx.params.id;
    ctx.render(detailsTemplate(loandItem(id, ctx)));
    
    
}

async function loandItem(id, ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isOwner = null;
    let data = await getById(id); 
    if(userData){
        isOwner = userData._id == data._ownerId;
    }
    async function onDelete(e){
        e.preventDefault();
        await deleteItem(id);
        ctx.page.redirect('/');
    }
    return itemTemplate(data, isOwner, onDelete);
}

