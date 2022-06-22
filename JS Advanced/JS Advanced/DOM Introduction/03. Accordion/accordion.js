function toggle() {
    let button = document.querySelector('.button');
    button.textContent = button.textContent == 'More' ? 'Less' : 'More';

    let extra = document.getElementById('extra')
    extra.style.display = extra.style.display == 'none' || extra.style.display == '' ? 
        extra.style.display = 'block' : extra.style.display = 'none';

   
}