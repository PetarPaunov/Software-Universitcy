import { html } from "../node_modules/lit-html/lit-html.js";
import { getAll } from "../src/api/data.js";

const homeTemplate = (items) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    
    ${items == 0? html`
        <p class="no-books">No books in database!</p>
    ` : html`
        <ul class="other-books-list"> 
            ${items.map(itemTemplate)}
        </ul>
    `} 
    <!-- Display paragraph: If there are no books in the database -->
</section>
`;

const itemTemplate = (item) => html`
<li class="otherBooks">
    <h3>${item.title}</h3>
    <p>Type: ${item.type}</p>
    <p class="img"><img src="${item.imageUrl}"></p>
    <a class="button" href="/details/${item._id}">Details</a>
</li>
`;

export async function homePage(ctx){
    const items = await getAll();
    
    ctx.render(homeTemplate(items));
}