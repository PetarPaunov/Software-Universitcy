import { html } from "../node_modules/lit-html/lit-html.js";
import { createItem, getById, updateItem } from "../src/api/data.js";

const editTemplate = (item, onEdit) => html`
 <section id="edit-page" class="edit">
    <form id="edit-form" action="#" method="" @submit="${onEdit}">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value="${item.title}">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"id="description">${item.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value="${item.imageUrl}">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value="${item.type}">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
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
        const type = formData.get('type');

        if(title == '' || description == '' || imageUrl == '' || type == ''){
            alert('All fields must be filed');
            return;
        }

        await updateItem(id, {title, description, imageUrl, type});
        ctx.page.redirect(`/details/${id}`);
    }
}