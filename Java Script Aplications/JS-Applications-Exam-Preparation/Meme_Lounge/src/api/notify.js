const section = document.getElementById('errorBox');
const span = section.querySelector('span');

export function notify(msg){
    span.textContent = msg;
    section.style.display = 'block';

    setTimeout(() => section.style.display = 'none', 3000);
}