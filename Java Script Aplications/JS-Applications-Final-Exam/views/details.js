import { html, nothing } from '../node_modules/lit-html/lit-html.js';
import { deleteItem, donate, donationCout, getById, isDonator } from '../src/api/data.js';

const detailsTemplate = (item, isCreator, onDelete, isLogedIn, postDonate, donations, hasDonate) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${item.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${item.name}</h1>
                <h3>Breed: ${item.breed}</h3>
                <h4>Age: ${item.age}</h4>
                <h4>Weight: ${item.weight}</h4>
                <h4 class="donation">Donation: ${donations}$</h4>
            </div>
            <!-- if there is no registered user, do not display div-->
            <div class="actionBtn">
                <!-- Only for registered user and creator of the pets-->
                ${isCreator ? html`
                    <a href="/edit/${item._id}" class="edit">Edit</a>
                    <a @click="${onDelete}" href="#" class="remove">Delete</a>
                ` : nothing}
                <!--(Bonus Part) Only for no creator and user-->
                ${isLogedIn && !isCreator  && hasDonate == 0 ? html`
                    <a @click="${postDonate}" href="#" class="donate">Donate</a>
                ` : nothing}
            </div>
        </div>
    </div>
</section>
`;

export async function detailsPage(ctx){
    let isLogedIn = false;
    const userData = JSON.parse(localStorage.getItem('user'));
    const id = ctx.params.id;
    const item = await getById(id);
    if(userData){
        isLogedIn = true;
    }
    let isCreator = userData && userData._id == item._ownerId;
    let donations = await donationCout(id);
    donations = Number(donations) * 100;
    let hasDonate = await isDonator(id, userData._id);
    ctx.render(detailsTemplate(item ,isCreator, onDelete, isLogedIn, postDonate, donations, hasDonate));

    async function onDelete(){
        await deleteItem(id);
        ctx.page.redirect('/');
    }

    async function postDonate(){
        await donate({petId: id})
        ctx.page.redirect(`/details/${id}`);
    }
}