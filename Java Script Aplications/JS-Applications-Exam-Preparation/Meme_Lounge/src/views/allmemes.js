import { getAll } from "../api/data.js";
import { html, until } from "../lib.js";

const memesTemplate = (memes) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${memes == 0 ? html`
        <p class="no-memes">No memes in database.</p>
        ` 
        : memes.map(itemTemplate)}
    </div>
</section>
`;

const itemTemplate = (item) => html `
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${item.title}</p>
            <img class="meme-image" alt="meme-img" src="${item.imageUrl}">
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${item._id}">Details</a>
        </div>
    </div>
</div>
`;

export async function memesPage(ctx){
    let memes = await getAll();
    ctx.render(memesTemplate(memes));
}

