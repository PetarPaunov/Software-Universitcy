import {html} from '../node_modules/lit-html/lit-html.js';
import { createItem } from '../src/api/data.js';

const createTemplate = (onCreate) => html`
<section id="create-listing">
    <div class="container">
        <form id="create-form" @submit="${onCreate}">
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>
`;

export function createPage(ctx){
    ctx.render(createTemplate(onCreate));
    async function onCreate(e){
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
        
        await createItem({brand, model, description, year, imageUrl, price})

        ctx.page.redirect('/catalog');
    }
}