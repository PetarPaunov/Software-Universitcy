import { html, nothing } from "../node_modules/lit-html/lit-html.js";
import { deleteItem, getById, getLikes, like, myLikes } from "../src/api/data.js";



const detailsTemplate = (item, onDelete, isOwner, isLogedIn, onLike, likesCount, hasLiked) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src="${item.imageUrl}"></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${isOwner ? html`
                <a class="button" href="/edit/${item._id}">Edit</a>
                <a class="button" href="javascript:void(0)" @click="${onDelete}">Delete</a>
            ` : nothing}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${isLogedIn && !isOwner && !hasLiked ? html`
                <a @click="${onLike}" class="button" href="javascript:void(0)">Like</a>
            ` : nothing}

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likesCount}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>
`;

export async function detailsPage(ctx){
    let isOwner = false;
    let isLogedIn = false;
    let hasLiked = 0;
    const userData = JSON.parse(localStorage.getItem('user'));


    const id = ctx.params.id;
    const item = await getById(id);

    if(userData && userData._id == item._ownerId){
        isOwner = true;
    }
    if(userData){
        isLogedIn = true;
        hasLiked = await myLikes(id, userData._id)
    }


    async function onDelete(){
        if(confirm('Are you sure you want to delete this item?')){
            await deleteItem(id);
            ctx.page.redirect('/');
        }
    }

    async function onLike(){
        await like({bookId: id});
        ctx.page.redirect(`/details/${id}`);
    }

    const likesCount = await getLikes(id);

    
    ctx.render(detailsTemplate(item, onDelete, isOwner, isLogedIn, onLike, likesCount, hasLiked));
}