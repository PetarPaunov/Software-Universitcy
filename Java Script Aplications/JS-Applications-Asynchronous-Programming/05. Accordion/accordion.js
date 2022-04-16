async function solution() {
    let mainSection = document.getElementById('main');

    let url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    let data = await fetch(url);
    let information = await data.json();

    information.forEach(x => {
        createAcrodeonElement(x._id, x.title);
    })

    async function createAcrodeonElement(id, title){
        let acordeonDivElement = document.createElement('div');
        acordeonDivElement.classList.add('accordion');

        let headDivElement = document.createElement('div');
        headDivElement.classList.add('head');

        let spanElement = document.createElement('span');
        spanElement.textContent = title;
        headDivElement.appendChild(spanElement);

        let button = document.createElement('button');
        button.classList.add('button');
        button.id = id;
        button.textContent = 'More';
        button.addEventListener('click', setAcordeon);
        headDivElement.appendChild(button);

        acordeonDivElement.appendChild(headDivElement);

        let url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
        let data = await fetch(url);
        let curentDivInfo = await data.json();

        let extraDiv = document.createElement('div');
        extraDiv.classList.add('extra');

        let pElement = document.createElement('p');
        pElement.textContent = curentDivInfo.content;
        extraDiv.appendChild(pElement);

        acordeonDivElement.appendChild(extraDiv);

        mainSection.appendChild(acordeonDivElement);
    }

    function setAcordeon(e){
        let button = e.target;
        let displayElement = button.parentNode.parentNode.querySelector('div:nth-child(2)');

        button.textContent = button.textContent == 'More' 
        ? button.textContent = 'Less' 
        : button.textContent = 'More';
        
        displayElement.style.display = displayElement.style.display == 'block'
        ? displayElement.style.display = 'none'
        : displayElement.style.display = 'block';
        
    };

}

solution();