import { createItem } from "../api/data.js";
import { notify } from "../api/notify.js";
import { html } from "../lib.js";

const createTemplate = (onCreate) => html`
<section id="create-meme">
    <form id="create-form" @submit="${onCreate}">
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
        </div>
    </form>
</section>
`;


export function createPage(ctx){
    ctx.render(createTemplate(onCreate));

    async function onCreate(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        if(title == '' || description == '' || imageUrl == ''){
            notify('All fields must be filed');
            return;
        }

        await createItem({title, description, imageUrl});
        ctx.page.redirect('/allmemes');
    }
}