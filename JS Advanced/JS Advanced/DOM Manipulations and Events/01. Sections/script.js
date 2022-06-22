function create(words) {
   let divElemtnts = document.getElementById('content');

   for(let i = 0; i < words.length; i++){
      let div = document.createElement('div');
      let paragraph = document.createElement('p');

      paragraph.textContent = words[i];
      paragraph.style.display = 'none';
      div.appendChild(paragraph);
      divElemtnts.appendChild(div);
   }

   divElemtnts.addEventListener('click', function(e){
      if(e.target.children[0].style.display == 'none'){
         e.target.children[0].style.display = 'block';
      }else{
         e.target.children[0].style.display = 'none';
      }
   })

}