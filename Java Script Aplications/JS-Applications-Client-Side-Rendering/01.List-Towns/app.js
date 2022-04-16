import { render, html } from "../node_modules/lit-html/lit-html.js";

let townTemplate = (towns) => html`
<ul>
    ${towns.map(x => html`<li>${x}</li>`)}
</ul>`;
let root = document.getElementById('root');


document.getElementById('btnLoadTowns').addEventListener('click', function(e){
    e.preventDefault();
    let input = document.getElementById('towns').value.split(',');

    render(townTemplate(input), root);

})

