function attachEvents() {
    getMessages();
    document.getElementById('refresh').addEventListener('click', getMessages);
    document.getElementById('submit').addEventListener('click', sendMessages);
}

attachEvents();
let texareaElement = document.getElementById('messages');

async function getMessages(){
    const url = `http://localhost:3030/jsonstore/messenger`;
    let res = await fetch(url);
    let data = await res.json();

    let result = Object.values(data).map(x => `${x.author}: ${x.content}`).join('\n');
    texareaElement.value = result;
}

async function sendMessages(){
    let nameElemtn = document.querySelector('[name="author"]').value;
    let messageElement = document.querySelector('[name="content"]').value;
    let jsonElement = {
        "author": nameElemtn,
        "content": messageElement
    }
    const url = `http://localhost:3030/jsonstore/messenger`;
    let options = {
        method: 'post',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify(jsonElement)
    }
    let res = await fetch(url, options)
    let result = await res.json();


    return result;
}