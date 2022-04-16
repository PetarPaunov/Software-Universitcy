async function lockedProfile() {
    let url = `http://localhost:3030/jsonstore/advanced/profiles`;
    
    let data = await fetch(url);
    let information = await data.json();
    document.querySelector('#main div').remove();
    let main = document.getElementById('main');


    
    Object.keys(information).forEach((x, i) => {
        let profile = information[x];
        let htmlElement = createProfile(i+1, profile.username, profile.email, profile.age);
        main.appendChild(htmlElement);
    })

    function createProfile(userId, name, email, age){
        let profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');

        let img = document.createElement('img');
        img.setAttribute('src', './iconProfile2.png');
        img.classList.add('userIcon');
        profileDiv.appendChild(img);

        let lockedLable = document.createElement('label');
        lockedLable.textContent = 'Lock';
        profileDiv.appendChild(lockedLable);


        let lockedRadio = document.createElement('input');
        lockedRadio.type = 'radio';
        lockedRadio.name = `user${userId}Locked`;
        lockedRadio.value = 'lock';
        lockedRadio.checked = true;
        profileDiv.appendChild(lockedRadio);



        let unlockedLable = document.createElement('label');
        unlockedLable.textContent = 'Unlock';
        profileDiv.appendChild(unlockedLable);


        let unlockedRadio = document.createElement('input');
        unlockedRadio.type = 'radio';
        unlockedRadio.name = `user${userId}Locked`;
        unlockedRadio.value = 'unlock';
        unlockedRadio.checked = false;
        let br = document.createElement('br');
        unlockedRadio.appendChild(br);
        let hr = document.createElement('hr');
        unlockedRadio.appendChild(hr);
        profileDiv.appendChild(unlockedRadio);



        let usernameLable = document.createElement('label');
        usernameLable.textContent = 'Username';
        profileDiv.appendChild(usernameLable);


        let usernameInput = document.createElement('input');
        usernameInput.type = 'text';
        usernameInput.name = `user${userId}Username`;
        usernameInput.value = name;
        usernameInput.disabled = true; 
        usernameInput.readOnly = true;
        profileDiv.appendChild(usernameInput);


        let userHidenFieldsDiv = document.createElement('div');
        userHidenFieldsDiv.id = `user${userId}HiddenFields`;
        userHidenFieldsDiv.style.display = 'none'


        let userhr = document.createElement('hr');
        userHidenFieldsDiv.appendChild(userhr);

        let emailLable = document.createElement('label');
        emailLable.textContent = 'Email';
        let emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `user${userId}Email`;
        emailInput.value = email;
        emailInput.disabled = true;
        emailInput.readOnly = true;
        userHidenFieldsDiv.appendChild(emailLable);
        userHidenFieldsDiv.appendChild(emailInput);

        let ageLable = document.createElement('label');
        ageLable.textContent = 'Age';
        let ageInput = document.createElement('input');
        ageInput.type = 'email';
        ageInput.name = `user${userId}Age`;
        ageInput.value = age;
        ageInput.disabled = true;
        ageInput.readOnly = true;
        userHidenFieldsDiv.appendChild(ageLable);
        userHidenFieldsDiv.appendChild(ageInput);

        profileDiv.appendChild(userHidenFieldsDiv);


        let showMoreButton = document.createElement('button');
        showMoreButton.textContent = 'Show more';
        showMoreButton.addEventListener('click', showInformation)
        profileDiv.appendChild(showMoreButton);


        return profileDiv;
    }

    function showInformation(e){
        let profile = e.target.parentNode;
        let showMoreButtun = e.target;
        let divToShow = e.target.previousElementSibling;

        let radioButton = profile.querySelector('input[type="radio"]:checked')

        if(radioButton.value != 'unlock'){
            return;
        }

        divToShow.style.display = divToShow.style.display == 'block' ? 'none' : 'block';

        showMoreButtun.textContent = showMoreButtun.textContent == 'Show more' ? 'Hide it' : 'Show more'
    }
}