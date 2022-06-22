import {html} from '../node_modules/lit-html/lit-html.js';
import { getById, updateItem } from '../src/api/data.js';

const editTemplate = (item, onEdit) => html`
<section id="edit-listing">
    <div class="container">

        <form id="edit-form" @submit="${onEdit}">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value="${item.brand}">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value="${item.model}">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value="${item.description}">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value="${item.year}">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value="${item.imageUrl}">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value="${item.price}">

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>
`;

export async function editPage(ctx){
    const id = ctx.params.id;
    const item = await getById(id);

    async function onEdit(e){
        e.preventDefault();

        const formData = new FormData(e.target);
        const brand = formData.get('brand');
        const model = formData.get('model');
        const description = formData.get('description');
        let year = formData.get('year');
        year = Number(year);
        const imageUrl = formData.get('imageUrl');
        let price = formData.get('price');
        price = Number(price);

        if(Number(year) < 0 || Number(price) < 0){
            alert('Year and Price shold be possitiv numbers!!')
            return;
        }

        if(brand == '' || model == '' || description == '' || year == ''
        || imageUrl == '' || price == ''){
            alert('All fields must be filed');
            return;
        }
        
        await updateItem(id, {brand, model, description, year, imageUrl, price})

        ctx.page.redirect('/catalog');
    }

    ctx.render(editTemplate(item, onEdit));
}