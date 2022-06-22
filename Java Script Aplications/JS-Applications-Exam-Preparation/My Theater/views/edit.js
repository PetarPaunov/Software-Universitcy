import { html } from "../node_modules/lit-html/lit-html.js";
import { getById, updateItem } from "../src/api/data.js";

const editTemplate = (item, onEdit) => html`
<section id="editPage">
    <form @submit="${onEdit}" class="theater-form">
        <h1>Edit Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" .value="${item.title}">
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year" .value="${item.date}">
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author"
                .value="${item.author}">
        </div>
        <div>
            <label for="description">Theater Description:</label>
            <textarea id="description" name="description"
                placeholder="Description">${item.description}</textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
                .value="${item.imageUrl}">
        </div>
        <button class="btn" type="submit">Submit</button>
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
        const date = formData.get('date');
        const author = formData.get('author');
        const imageUrl = formData.get('imageUrl');
        const description = formData.get('description');

        if(title == '' || date == '' || author == '' || imageUrl == '' || description == ''){
            alert('All fields must be filed!');
            return;
        }

        await updateItem(id, {title, date, author, imageUrl, description});
        ctx.page.redirect('/')
    }

}