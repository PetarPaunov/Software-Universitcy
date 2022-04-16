import {html} from '../node_modules/lit-html/lit-html.js';
import { byQuery } from '../src/api/data.js';

const searchTemplate = (onSearch, onInput, items = []) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year" @input="${onInput}">
        <button class="button-list" @click="${onSearch}">Search</button>
    </div>
    <h2>Results:</h2>
    <div class="listings">
        
        ${items.length == 0 ? html`
            <p class="no-cars"> No results.</p>
        ` : 
          items.map(itemTemplate)      
        } 

    </div>
</section>
`;

const itemTemplate = (item) => html`
<div class="listing">
    <div class="preview">
        <img src="${item.imageUrl}">
    </div>
    <h2>${item.brand + ' ' + item.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${item.year}</h3>
            <h3>Price: ${item.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${item._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>
`;

export function searchPage(ctx){
    let curentYear = '';

    function onInput(e){
        curentYear = e.target.value
    }

    async function onSearch(){
        const items = await byQuery(curentYear);
        ctx.render(searchTemplate(onSearch, onInput, items));
    }

    ctx.render(searchTemplate(onSearch,onInput));
}

