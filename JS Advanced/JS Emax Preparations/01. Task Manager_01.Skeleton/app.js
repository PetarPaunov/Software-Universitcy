function solve() {

    let sectionsElements = Array.from(document.querySelectorAll('.wrapper section'));
    
    let openSection = sectionsElements[1];
    let inProgresSection = sectionsElements[2];
    let complateSection = sectionsElements[3];

    let inputTaskElement = document.getElementById('task');
    let textAreaElement = document.getElementById('description');
    let inputDataEelement = document.getElementById('date');

    let button = document.getElementById('add');
    

    button.addEventListener('click', function(e){
        

        if(inputTaskElement.value == '' || textAreaElement.value == '' || inputDataEelement == ''){
            return;
        }

        let div = openSection.querySelector('div:nth-child(2)');
        
        let articalElement = document.createElement('article');

        let h3 = document.createElement('h3');
        h3.textContent = inputTaskElement.value;
        articalElement.appendChild(h3);

        let firstP = document.createElement('p');
        firstP.textContent = 'Description: ' + textAreaElement.value;
        articalElement.appendChild(firstP);

        let secondP = document.createElement('p');
        secondP.textContent = 'Due Date: ' + inputDataEelement.value;
        articalElement.appendChild(secondP);
        
        let openDiv = document.createElement('div');
        openDiv.setAttribute('class', 'flex');

        let finishButoon = document.createElement('button');
        finishButoon.setAttribute('class', 'orange');
        finishButoon.textContent = 'Finish'; /// Chek Here;
        finishButoon.addEventListener('click', function(e){
            let div = complateSection.querySelector('div:nth-child(2)');
            div.appendChild(articalElement);
            articalElement.removeChild(openDiv);
        })


        let startButton = document.createElement('button');
        startButton.setAttribute('class', 'green');
        startButton.textContent = 'Start';
        startButton.addEventListener('click', function(e){
            let div = inProgresSection.querySelector('div:nth-child(2)');
            openDiv.removeChild(startButton);
            openDiv.appendChild(finishButoon);
            div.appendChild(articalElement);
        });
        openDiv.appendChild(startButton);

        let deleteButton = document.createElement('button');
        deleteButton.setAttribute('class', 'red');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', function(e){
            articalElement.remove();
        });
        openDiv.appendChild(deleteButton);

        articalElement.appendChild(openDiv);
        div.appendChild(articalElement);

        e.preventDefault();
    })

}