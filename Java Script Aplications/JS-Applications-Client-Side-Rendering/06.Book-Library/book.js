import { html } from "../node_modules/lit-html/lit-html.js";

export const bookTemplate = (id, book) => html`
    <tr data-id="${id}">
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td>
            <button>Edit</button>
            <button>Delete</button>
        </td>
    </tr>
`;