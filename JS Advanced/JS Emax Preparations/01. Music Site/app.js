window.addEventListener('load', solve);

function solve() {
    let ganreElement = document.getElementById('genre');
    let songNameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');
    let addButtun = document.getElementById('add-btn');

    let divToAppendAtElement = document.querySelector('.all-hits-container');

    addButtun.addEventListener('click', function(e){
        e.preventDefault();

        if(ganreElement.value == '' || songNameElement.value == '' || authorElement.value == '' || dateElement.value == ''){
            return;
        }

        let divElement = document.createElement('div');
        divElement.setAttribute('class', 'hits-info');

        let img = document.createElement('img');
        img.setAttribute('src', './static/img/img.png');
        divElement.appendChild(img);

        let result1 = `Genre: ${ganreElement.value}`;
        let firstH2 = document.createElement('h2');
        firstH2.textContent = result1;
        divElement.appendChild(firstH2);

        let result2 = `Name: ${songNameElement.value}`;
        let secondH2 = document.createElement('h2');
        secondH2.textContent = result2;
        divElement.appendChild(secondH2);

        let result3 = `Author: ${authorElement.value}`;
        let thirdH2 = document.createElement('h2');
        thirdH2.textContent = result3;
        divElement.appendChild(thirdH2);

        let result4 = `Date: ${dateElement.value}`;
        let h3 = document.createElement('h3');
        h3.textContent = result4;
        divElement.appendChild(h3);

        let saveBtn = document.createElement('button');
        saveBtn.setAttribute('class', 'save-btn');
        saveBtn.textContent = 'Save song';

        saveBtn.addEventListener('click', function(e){
            let divToAppend = document.querySelector('.saved-container');
            divElement.removeChild(saveBtn);
            divElement.removeChild(likeBtn);
            divToAppend.appendChild(divElement);
        })

        divElement.appendChild(saveBtn);

        let likeBtn = document.createElement('button');
        likeBtn.setAttribute('class', 'like-btn');
        likeBtn.textContent = 'Like song';

        likeBtn.addEventListener('click', function(e){
            let likes = document.querySelector('.likes p');
            let cunrentLikesValu = Number(likes.textContent.split(': ')[1]);
            cunrentLikesValu++;
            likes.textContent = `Total Likes: ${cunrentLikesValu}`;

            likeBtn.disabled = true;

        })
        divElement.appendChild(likeBtn);

        let deleteBtn = document.createElement('button');
        deleteBtn.setAttribute('class', 'delete-btn');
        deleteBtn.textContent = 'Delete';

        deleteBtn.addEventListener('click', function(e){
            deleteBtn.parentElement.remove();
        })

        divElement.appendChild(deleteBtn);


        divToAppendAtElement.appendChild(divElement);

        ganreElement.value = '';
        songNameElement.value = '';
        authorElement.value = '';
        dateElement.value = '';

    })
}