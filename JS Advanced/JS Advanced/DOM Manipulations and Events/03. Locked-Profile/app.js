function lockedProfile() {
    
    document.getElementById('main').addEventListener('click', function(e){

        if(e.target.tagName == 'BUTTON'){

            let profile = e.target.parentNode;
            let isLocked = profile.querySelector('input[type=radio]:checked').value === 'lock';

            if(isLocked){
                return;
            }
            
            let div = profile.querySelector('div');

            let isVisilbe = div.style.display == 'block';

            if(isVisilbe){
                div.style.display = 'none';
                e.target.textContent = 'Show more';
            }else{
                div.style.display = 'block';
                e.target.textContent = 'Hide it';
            }
        }
    })
    
     
    
}