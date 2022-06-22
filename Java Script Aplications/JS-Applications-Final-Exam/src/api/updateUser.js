export function updateUserNav(){
    const userData = JSON.parse(localStorage.getItem('user'));
    if(userData){
        document.querySelectorAll('#user').forEach(x => x.style.display = 'block');
        document.querySelectorAll('#guest').forEach(x => x.style.display = 'none');
    }else{
        document.querySelectorAll('#guest').forEach(x => x.style.display = 'block');
        document.querySelectorAll('#user').forEach(x => x.style.display = 'none');
    }
}


