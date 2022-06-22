import {html} from '../node_modules/lit-html/lit-html.js';
import { deleteItem, getById } from '../src/api/data.js';

const detailsTemplate = (item, isAuthor, onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${item.imageUrl}">
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${item.brand}</li>
            <li><span>Model:</span>${item.model}</li>
            <li><span>Year:</span>${item.year}</li>
            <li><span>Price:</span>${item.price}$</li>
        </ul>

        <p class="description-para">${item.description}</p>

        ${isAuthor ? html`
        <div class="listings-buttons">
            <a href="/edit/${item._id}" class="button-list">Edit</a>
            <a href="javascript:void(0)" class="button-list" @click="${onDelete}">Delete</a>
        </div>
        ` : null}
    </div>
</section>
`;

export async function detailsPage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isAuthor = null;
    const item = await getById(ctx.params.id);
    if(userData && userData._id == item._ownerId){
        isAuthor = true;
    }

    async function onDelete(){
        if(confirm('Are you sure you want to delete this item?')){
            await deleteItem(ctx.params.id);
            ctx.page.redirect('/catalog');
        }
    }

    ctx.render(detailsTemplate(item, isAuthor, onDelete));
}

