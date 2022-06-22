import { html } from "../node_modules/lit-html/lit-html.js";
import { getMyItems } from "../src/api/data.js";

const myBooksTemplate = (items) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <!-- Display ul: with list-items for every user's books (if any) -->

    ${items == 0 ? html`
        <p class="no-books">No books in database!</p>
    ` : html`
        <ul class="my-books-list">
            ${items.map(itemTemplate)}
        </ul>
    `}
    <!-- Display paragraph: If the user doesn't have his own books  -->
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

export async function myBooksPage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    const userId = userData._id;
    const items = await getMyItems(userId);
    console.log(items);
    
    ctx.render(myBooksTemplate(items));
}