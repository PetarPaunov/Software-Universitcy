import { html } from '../node_modules/lit-html/lit-html.js';
import { getById, updateItem } from "../src/api/data.js";

const editTemplate = (item, onEdit) => html`
<section id="editPage">
    <form class="editForm" @submit="${onEdit}">
        <img src="./images/editpage-dog.jpg">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" .value="${item.name}">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" .value="${item.breed}">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" .value="${item.age}">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" .value="${item.weight}">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" .value="${item.image}">
            </div>
            <button class="btn" type="submit">Edit Pet</button>
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

        const name = formData.get('name');
        const breed = formData.get('breed');
        const age = formData.get('age');
        const weight = formData.get('weight');
        const image = formData.get('image');

        if(name == '' || breed == '' || age == '' || weight == '' || image == ''){
            notify('All fields must be filed');
            return;
        }

        await updateItem(id, {name, breed, age, weight, image});
        ctx.page.redirect(`/details/${id}`); 
    }
}