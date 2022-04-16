export function updateUserNav(){
    const userData = JSON.parse(localStorage.getItem('user'));
    if(userData){
        document.querySelectorAll('#user').forEach(x => x.style.display = 'inline-block')
        document.querySelectorAll('#guest').forEach(x => x.style.display = 'none')
    }else{
        document.querySelectorAll('#user').forEach(x => x.style.display = 'none')
        document.querySelectorAll('#guest').forEach(x => x.style.display = 'inline-block')
    }
}

export function updataProfile(memesCount){
    const userData = JSON.parse(localStorage.getItem('user'));

    let pArray = document.querySelectorAll('.user-content p');
    pArray[0].textContent = `Username: ${userData.username}`;
    pArray[1].textContent = `Email: ${userData.email}`;
    pArray[2].textContent = `My memes count: ${memesCount}`;
}
