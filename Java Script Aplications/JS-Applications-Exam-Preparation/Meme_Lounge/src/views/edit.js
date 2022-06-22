import { getById, updateItem } from "../api/data.js";
import { notify } from "../api/notify.js";
import { html } from "../lib.js";

const editTemplate = (item, onEdit) => html`
<section id="edit-meme">
    <form id="edit-form" @submit="${onEdit}">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value="${item.title}">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value="${item.description}">
                </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value="${item.imageUrl}">
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`;


export async function editPage(ctx){
    const id = ctx.params.id;
    const item = await getById(id);
    ctx.render(editTemplate(item, onEdit));

    async function onEdit(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        if(title == '' || description == '' || imageUrl == ''){
            notify('All fields must be filed');
            return;
        }

        await updateItem(id, {title, description, imageUrl});
        ctx.page.redirect('/allmemes');
    }
}

