import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteItem, getById } from "../api/data.js";

const detailsTemplate = (item, isOwner, onDelete) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${item.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${item.name}</h1>
                <h3>Artist: ${item.artist}</h3>
                <h4>Genre: ${item.genre}</h4>
                <h4>Price: $${item.price}</h4>
                <h4>Date: ${item.releaseDate}</h4>
                <p>Description: ${item.description}</p>
            </div>

            ${isOwner ? html`
                <div class="actionBtn">
                    <a href="/edit/${item._id}" class="edit">Edit</a>
                    <a href="javascript:void(0)" class="remove" @click="${onDelete}">Delete</a>
                </div>
            ` : 
                nothing}
        </div>
    </div>
</section>
`;

export async function detailsPage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    const id = ctx.params.id;
    const item = await getById(id);
    let isOwner = null;
    if(userData && userData._id == item._ownerId){
        isOwner = true;
    }

    async function onDelete(){
        if(confirm('Are you sure you want to delete this item?')){
            await deleteItem(id);
            ctx.page.redirect('/catalog');
        }
    }

    ctx.render(detailsTemplate(item, isOwner, onDelete));
}

