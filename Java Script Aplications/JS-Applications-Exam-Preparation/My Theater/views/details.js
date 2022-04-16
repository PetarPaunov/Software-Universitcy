import { html, nothing } from "../node_modules/lit-html/lit-html.js";
import { deleteItem, getById, getCountLikes, getHasLike, postLike } from "../src/api/data.js";

const detailsTemplate = (item, onDelete, isCreator, isLogedIn, hasLike, like, getCount) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${item.title}</h1>
            <div>
                <img src="${item.imageUrl}" />
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${item.description}</p>
            <h4>Date: ${item.date}</h4>
            <h4>Author: ${item.author}</h4>
            <div class="buttons">
                ${isCreator ? html`
                    <a @click="${onDelete}" class="btn-delete" href="javascript:void(0)">Delete</a>
                    <a class="btn-edit" href="/edit/${item._id}">Edit</a>
                ` : nothing}
                ${isLogedIn && hasLike == 0 && !isCreator? html`
                    <a @click="${like}" class="btn-like" href="#">Like</a>
                ` : nothing}
            </div>
            <p class="likes">Likes: ${getCount}</p>
        </div>
    </div>
</section>
`;

export async function detailsPage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isLogedIn = false;
    const id = ctx.params.id;
    const item = await getById(id);
    let getCount = await getCountLikes(id)
    let isCreator = userData && userData._id == item._ownerId;
    if(userData){
        isLogedIn = true;
    }
    let hasLike = userData ? await getHasLike(id, userData._id) : false;

    ctx.render(detailsTemplate(item, onDelete, isCreator, isLogedIn, hasLike, like, getCount))

    async function onDelete(){

        if(confirm('Are you sure you want to delete this item?')){
            await deleteItem(id);
            ctx.page.redirect('/profile');
        }
        
    }

    async function like(){
        await postLike({theaterId: id});
        ctx.page.redirect(`/details/${id}`);
    }

    
}