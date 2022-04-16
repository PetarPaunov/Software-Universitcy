import { nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteItem, getById } from "../api/data.js";
import { html, until } from "../lib.js";

const detailsTemplate = (item) => html`
<section id="meme-details">
    ${until(item)}
</section>
`;

const itemTemplate = (item, isOwner, onDelete) => html`
<h1>Meme Title: ${item.title}

</h1>
<div class="meme-details">
    <div class="meme-img">
        <img alt="meme-alt" src="${item.imageUrl}">
    </div>
    <div class="meme-description">
        <h2>Meme Description</h2>
        <p>
            ${item.description}
        </p>

        <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
        ${isOwner ? html`
        <a class="button warning" href="/edit/${item._id}">Edit</a>
        <button class="button danger" @click="${onDelete}">Delete</button>` : nothing}
        
    </div>
</div>
`;

export function detailsPage(ctx){
    ctx.render(detailsTemplate(getItem(ctx.params.id, ctx)));
}

async function getItem(id, ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isOwner = null;
    const item = await getById(id);
    if(userData){
        isOwner = userData._id == item._ownerId;
    }

    async function onDelete(){
        if(confirm('Are you sure you want to delete this item?')){
            await deleteItem(id);
            ctx.page.redirect('/allmemes');
        }
    }
    return itemTemplate(item,isOwner,onDelete);
}