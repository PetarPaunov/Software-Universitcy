function solve() {
  let text = document.getElementById('input').value;
  let splitedText = text.split('.').filter(x => x != '');
  let curentParaghphElement = '';
  let output = document.getElementById('output');
  let count = 0;
  for (let i = 0; i < splitedText.length; i++) {
    if(count == 3){
      output.innerHTML += `<p>${curentParaghphElement}.</p>`;
      curentParaghphElement = '';
      count = 0;
    }
    curentParaghphElement += splitedText[i]
    count++;
  }
  output.innerHTML += `<p>${curentParaghphElement}.</p>`;
  
}