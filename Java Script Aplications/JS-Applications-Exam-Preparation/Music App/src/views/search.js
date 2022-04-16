import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { byQueary } from "../api/data.js";

const searchTemplate = (onSubmit, onInput, items = [], isLoged) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name" @input="${onInput}">
        <button class="button-list" @click="${onSubmit}">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="search-result">

    <!--Show after click Search button-->
    ${items.length == 0 ? html`
        <p class="no-result">No result.</p>
    ` : 
    items.map(x => itemTemplate(x, isLoged))
    }
    </div>

</section>
`;

const itemTemplate = (item, isLoged) => html`
    <!--If have matches-->
    <div class="card-box">
        <img src="${item.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${item.name}</p>
                <p class="artist">Artist: ${item.artist}</p>
                <p class="genre">Genre: ${item.genre}</p>
                <p class="price">Price: $${item.price}</p>
                <p class="date">Release Date: ${item.date}</p>
            </div>
            ${isLoged() ? html`
            <div class="btn-group">
                <a href="/details/${item._id}" id="details">Details</a>
            </div>            
            ` : nothing}
        </div>
    </div>
`;

export function searchPage(ctx){
    let input = '';

    function onInput(e){
        input = e.target.value;
    }
    
    async function onSearch(){
        const items = await byQueary(input);
        ctx.render(searchTemplate(onSearch, onInput, items, isLoged));
    }

    ctx.render(searchTemplate(onSearch, onInput));
}

function isLoged(){
    const userData = JSON.parse(localStorage.getItem('user'));
    let isLoged = null;
    if(userData){
        isLoged = true;
    }

    return isLoged;
}