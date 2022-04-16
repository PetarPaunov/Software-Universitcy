let phoneesUlElement = document.getElementById('phonebook');

function attachEvents() {
    loadPhoneNumbers();
    document.getElementById('btnLoad').addEventListener('click', loadPhoneNumbers);
    document.getElementById('btnCreate').addEventListener('click', createUser);
    phoneesUlElement.addEventListener('click', deletePhoneNumber);
}

attachEvents();

async function createUser(){
    let personElement = document.getElementById('person').value;
    let phoneElement = document.getElementById('phone').value;

    let element = {
        "person": personElement,
        "phone": phoneElement
    }

    personElement = '';
    phoneElement = '';

    let url = `http://localhost:3030/jsonstore/phonebook`;
    let res = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify(element)
        
    })
    let data = await res.json();


}

async function loadPhoneNumbers(){
    let url = `http://localhost:3030/jsonstore/phonebook`;
    let res = await fetch(url);
    let data = await res.json();    
    phoneesUlElement.replaceChildren();
    Object.values(data).forEach(x => {
        let liElement = document.createElement('li');
        liElement.textContent = `${x.person}: ${x.phone}`;

        let deleteButtun = document.createElement('button');
        deleteButtun.textContent = 'Delete';
        deleteButtun.setAttribute('data-id', x._id);
        liElement.appendChild(deleteButtun);

        phoneesUlElement.appendChild(liElement);
    })
}

async function deletePhoneNumber(e){
    let id = e.target.dataset.id;
    if(id !== undefined){
        const url = `http://localhost:3030/jsonstore/phonebook/${id}`
        let res = await fetch(url, {
            method: 'DELETE',
        });
        let data = await res.json();

        e.target.parentElement.remove();
    }
}