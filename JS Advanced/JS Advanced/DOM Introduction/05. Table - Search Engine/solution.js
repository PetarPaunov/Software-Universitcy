function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementById('searchField');
      let elements = Array.from(document.querySelectorAll('tbody tr'));
      let text = input.value.toLowerCase();
      elements.forEach(x => {
         curentElement = x.textContent.toLowerCase();

         if(curentElement.includes(text)){
            x.classList.add('select');
         }else{
            x.classList.remove('select');
         }
      });
      input.value ='';
   }
   
}