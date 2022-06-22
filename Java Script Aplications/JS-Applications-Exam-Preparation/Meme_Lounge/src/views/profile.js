import { getMyItems } from "../api/data.js";
import { updataProfile } from "../api/updateUser.js";
import { html } from "../lib.js";

const profileTemplate = (memes) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/female.png">
        <div class="user-content">
            <p>Username: Mary</p>
            <p>Email: mary@abv.bg</p>
            <p>My memes count: 2</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) --> 
        ${memes == 0 ? html`
        <p class="no-memes">No memes in database.</p>
        `
        : memes.map(itemTemplate)}
        <!-- Display : If user doesn't have own memes  --> 
    </div>
</section>
`;

const itemTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
    <a class="button" href="/details/${meme._id}">Details</a>
</div>
`;

export async function profilePage(ctx){
    const userData = JSON.parse(localStorage.getItem('user'));
    const id = userData._id;
    const myMemes = await getMyItems(id);

    ctx.render(profileTemplate(myMemes));
    updataProfile(myMemes.length);
}