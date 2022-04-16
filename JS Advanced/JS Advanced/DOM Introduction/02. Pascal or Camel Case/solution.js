function solve() {
  let casing = document.getElementById('naming-convention').value;
  let text = document.getElementById('text').value;
  let resultConteiner = document.getElementById('result');
  let splited = text.split(' ');
  let result = '';
  if (casing == 'Camel Case') {
    result += splited[0][0].toLowerCase() + splited[0].slice(1, splited[0].length).toLowerCase();

    for (let i = 1; i < splited.length; i++) {
      result += splited[i][0].toUpperCase() + splited[i].slice(1, splited[i].length).toLowerCase();
    }
    resultConteiner.textContent = result;
  }else if(casing == 'Pascal Case'){
    for (let i = 0; i < splited.length; i++) {
      result += splited[i][0].toUpperCase() + splited[i].slice(1, splited[i].length).toLowerCase();
    }
    resultConteiner.textContent = result;
  }else{
    
    resultConteiner.textContent = 'Error!';
  }
  
}