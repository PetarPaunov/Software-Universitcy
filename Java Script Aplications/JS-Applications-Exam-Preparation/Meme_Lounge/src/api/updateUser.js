export function updateUserNav(){
    const userData = JSON.parse(localStorage.getItem('user'));
    if(userData){
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.user span').textContent = `Welcome, ${userData.email}`
    }else{
        document.querySelector('.guest').style.display = 'block';
        document.querySelector('.user').style.display = 'none';
    }
}

export function updataProfile(memesCount){
    const userData = JSON.parse(localStorage.getItem('user'));

    let pArray = document.querySelectorAll('.user-content p');
    pArray[0].textContent = `Username: ${userData.username}`;
    pArray[1].textContent = `Email: ${userData.email}`;
    pArray[2].textContent = `My memes count: ${memesCount}`;
}
