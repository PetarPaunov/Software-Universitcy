import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteItem, getById, getComments, postComment } from "../api/data.js";

const detailsTemplate = (item, comments, isOwner, onDelete, onComment, isLogedIn) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src="${item.imageUrl}" />
            <h1>${item.title}</h1>
            <span class="levels">MaxLevel: ${item.maxLevel}</span>
            <p class="type">${item.category}</p>
        </div>

        <p class="text">
        ${item.summary}
        </p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            ${comments.length == 0 ? html`
            <p class="no-comment">No comments.</p>
            ` : 
            html`
            <ul>
                <!-- list all comments for current game (If any) -->
                ${comments.map(commentTemplate)}
            </ul>
            `
            }
            <!-- Display paragraph: If there are no games in the database -->
        </div>

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        ${isOwner ? html`
        <div class="buttons">
            <a href="/edit/${item._id}" class="button">Edit</a>
            <a href="javascript:void(0)" class="button" @click="${onDelete}">Delete</a>
        </div>
        ` : 
        nothing
        }
    </div>
    ${isOwner || !isLogedIn ? nothing : html`
    <article class="create-comment">
        <label>Add new comment:</label>
        <form class="form" @submit="${onComment}">
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
        </form>
    </article>
    `}
</section>
`;

const commentTemplate = (comment) => html`
<li class="comment">
    <p>Content: ${comment.comment}.</p>
</li>
`;



export async function detailsPage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isOwner = false;
    let isLogedIn = true;
    const id = ctx.params.id;
    const item = await getById(id);
    const comments = await getComments(id);

    if(!userData){
        isLogedIn = false;
    }
    
    if(userData && userData._id == item._ownerId){
        isOwner = true;
    }
    ctx.render(detailsTemplate(item, comments, isOwner, onDelete, onComment, isLogedIn));

    async function onDelete(){
        await deleteItem(id);
        ctx.page.redirect('/');
    }

    async function onComment(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const comment = formData.get('comment');

        if(comment == ''){
            alert('Shold add comment');
            return;
        }
        await postComment({gameId : id, comment});
        e.target.reset();
        ctx.page.redirect(`/details/${id}`);


    }
}