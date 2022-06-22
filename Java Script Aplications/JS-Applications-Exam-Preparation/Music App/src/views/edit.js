import { html } from "../../node_modules/lit-html/lit-html.js";
import { getById, updateItem } from "../api/data.js";

const editTemplate = (onEdit, item) => html`
<section class="editPage">
<form @submit="${onEdit}">
    <fieldset>
        <legend>Edit Album</legend>

        <div class="container">
            <label for="name" class="vhide">Album name</label>
            <input id="name" name="name" class="name" type="text" .value="${item.name}">

            <label for="imgUrl" class="vhide">Image Url</label>
            <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" .value="${item.imgUrl}">

            <label for="price" class="vhide">Price</label>
            <input id="price" name="price" class="price" type="text" .value="${item.price}">

            <label for="releaseDate" class="vhide">Release date</label>
            <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" .value="${item.releaseDate}">

            <label for="artist" class="vhide">Artist</label>
            <input id="artist" name="artist" class="artist" type="text" .value="${item.artist}">

            <label for="genre" class="vhide">Genre</label>
            <input id="genre" name="genre" class="genre" type="text" .value="${item.genre}">

            <label for="description" class="vhide">Description</label>
            <textarea name="description" class="description" rows="10"
                cols="10">${item.description}</textarea>

            <button class="edit-album" type="submit">Edit Album</button>
        </div>
    </fieldset>
</form>
</section>
`;

export async function editPage(ctx){
    const id = ctx.params.id;
    const item = await getById(id);

    ctx.render(editTemplate(onEdit, item));

    async function onEdit(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const name = formData.get('name')
        const imgUrl = formData.get('imgUrl')
        const price = formData.get('price')
        const releaseDate = formData.get('releaseDate')
        const artist = formData.get('artist')
        const genre = formData.get('genre')
        const description = formData.get('description')

        if(name == '' || imgUrl == '' || price == '' || releaseDate == '' || artist == '' || genre == '' || description == ''){
            alert('All fields must be filed');
            return;           
        }

        await updateItem(id, {name, imgUrl, price, releaseDate, artist, genre, description});

        ctx.page.redirect(`/details/${id}`);
      
    }
}