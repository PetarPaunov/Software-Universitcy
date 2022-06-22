function encodeAndDecodeMessages() {
    
    document.getElementById('main').addEventListener('click', function(e){

        if(e.target.tagName == 'BUTTON'){
            if(e.target.textContent == 'Encode and send it'){
                let inputElements = e.target.parentNode.querySelector('textarea').value;
                let result = '';
                for (let i = 0; i < inputElements.length; i++) {

                    let char = inputElements[i];
                    let index = 0;

                    let curentChar = char.charCodeAt(index) + 1
                    curentChar = String.fromCharCode(curentChar);
                    result += curentChar;
                }
                document.querySelector('#main div:nth-child(2) textarea').textContent = result;
                e.target.parentNode.querySelector('textarea').value = '';
            }else if(e.target.textContent == 'Decode and read it'){
                let inputElements = e.target.parentNode.querySelector('textarea').value;
                let result = '';

                for (let i = 0; i < inputElements.length; i++) {

                    let char = inputElements[i];
                    let index = 0;

                    let curentChar = char.charCodeAt(index) - 1
                    curentChar = String.fromCharCode(curentChar);
                    result += curentChar;
                }
                document.querySelector('#main div:nth-child(2) textarea').textContent = result;
            }
            
        }
    })
    
}