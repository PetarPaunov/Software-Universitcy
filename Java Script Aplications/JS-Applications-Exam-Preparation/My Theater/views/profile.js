import { html } from "../node_modules/lit-html/lit-html.js";
import { getMyItems } from "../src/api/data.js";

const profileTemplate = (items, userEmail) => html`
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="./images/profilePic.png">
        </div>
        <h2>${userEmail}</h2>
    </div>
    <div class="board">
        <!--If there are event-->
        
        ${items == 0 ? html`
            <div class="no-events">
                <p>This user has no events yet!</p>
            </div>
        ` : items.map(itemTemplate)}
        <!--If there are no event-->
        
    </div>
</section>
`;

const itemTemplate = (item) => html`
<div class="eventBoard">
    <div class="event-info">
        <img src="${item.imageUrl}">
        <h2>${item.title}</h2>
        <h6>${item.date}</h6>
        <a href="/details/${item._id}" class="details-button">Details</a>
    </div>
</div>
`;

export async function profilePage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    const userEmail = userData.email;
    const items = await getMyItems(userData._id);

    ctx.render(profileTemplate(items, userEmail));
}