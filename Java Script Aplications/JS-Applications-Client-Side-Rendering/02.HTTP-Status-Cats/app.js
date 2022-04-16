import { render, html } from "../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";

let root = document.getElementById('allCats');

let catTemplate = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn" >Show status code</button>
        <div class="status" style="display: none" id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>
`;

root.addEventListener('click', function(e){
    if(e.target.tagName == 'BUTTON'){
        let div = e.target.parentElement.querySelector('.status');
        if(div.style.display == 'none'){
            div.style.display = 'block'
            e.target.textContent = 'Hide status code'
        }else{
            div.style.display = 'none'
            e.target.textContent = 'Show status code'
        }
    }
    
})

render(html`<ul>${cats.map(catTemplate)}</ul>`, root);