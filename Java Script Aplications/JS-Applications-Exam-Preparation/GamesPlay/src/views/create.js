import { html } from "../../node_modules/lit-html/lit-html.js";
import { createItem, register } from "../api/data.js";
import { updateUserNav } from "../api/updateUser.js";

const createTemplate = (onCreate) => html`
<section id="create-page" class="auth">
    <form id="create" @submit="${onCreate}">
        <div class="container">

            <h1>Create Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" placeholder="Enter game title...">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" placeholder="Enter game category...">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary"></textarea>
            <input class="btn submit" type="submit" value="Create Game">
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
        const category = formData.get('category');
        const maxLevel = formData.get('maxLevel');
        const imageUrl = formData.get('imageUrl');
        const summary = formData.get('summary');


        if(title == '' || category == '' || maxLevel == '' || imageUrl == '' || summary == ''){
            alert('All filds must be filled');
            return;
        }

        await createItem({title, category, maxLevel, imageUrl, summary});
        ctx.page.redirect('/');
    }
}