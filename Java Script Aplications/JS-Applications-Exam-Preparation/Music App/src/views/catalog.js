import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { getAll } from "../api/data.js";

const catalogTemplate = (items, isLoged) => html`
<section id="catalogPage">
    <h1>All Albums</h1>

    ${items.length == 0 ? html`
    <p>No Albums in Catalog!</p>
    ` :
    items.map(x => itemTemplate(x, isLoged))
    }
</section>
`;

const itemTemplate = (item, isLoged) => html`
<div class="card-box">
    <img src="${item.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${item.name}</p>
            <p class="artist">Artist: ${item.artist}</p>
            <p class="genre">Genre: ${item.genre}</p>
            <p class="price">Price: $${item.price}</p>
            <p class="date">Release Date: ${item.releaseDate}</p>
        </div>
        ${isLoged() ? html`
            <div class="btn-group">
                <a href="/details/${item._id}" id="details">Details</a>
            </div>
        ` : 
        nothing
        }
</div>
</div>
`;

export async function catalogPage(ctx){
    
    const items = await getAll();
    ctx.render(catalogTemplate(items, isLoged));
}

function isLoged(){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isLoged = null;
    if(userData){
        isLoged = true;
    }

    return isLoged;
}