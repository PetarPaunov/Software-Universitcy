function search() {
   let listItems = Array.from(document.querySelectorAll('ul li'));
   let text = document.getElementById('searchText').value;
   let matches = 0;
   let items = listItems.forEach(x => {
      if(x.textContent.includes(text)){
         x.style.fontWeight = 'bold';
         x.style.textDecoration = 'underline';
         matches++;
      }else{
         x.style.fontWeight = '';
         x.style.textDecoration = '';
      }
   })
   document.getElementById('result').textContent = `${matches} matches found`;
}
