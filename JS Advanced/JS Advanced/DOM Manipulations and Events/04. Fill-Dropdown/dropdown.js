function addItem() {
    let inputText = document.getElementById('newItemText');
    let inputValue = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');

    optionElement.textContent = inputText.value;
    optionElement.value = inputValue.value;

    let selectElement = document.getElementById('menu');

    selectElement.appendChild(optionElement);
    
    inputText.value = '';
    inputValue.value = '';
}