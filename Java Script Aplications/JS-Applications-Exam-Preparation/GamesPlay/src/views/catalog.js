import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAll } from "../api/data.js";

const catalogTemplate = (items) => html`
<section id="catalog-page">
    <h1>All Games</h1>

    ${items.length == 0 ? html`
        <h3 class="no-articles">No articles yet</h3>
        ` : 
        items.map(itemTemplate)
    }
</section>
`;

const itemTemplate = (item) => html`
<div class="allGames">
<div class="allGames-info">
    <img src="${item.imageUrl}">
    <h6>${item.category}</h6>
    <h2>${item.title}</h2>
    <a href="/details/${item._id}" class="details-button">Details</a>
</div>

</div>
`;


export async function catalogPage(ctx){
    const items = await getAll();
    ctx.render(catalogTemplate(items));
}