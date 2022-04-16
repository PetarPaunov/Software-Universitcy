function subtract() {
    let firstNumber = document.getElementById('firstNumber');
    let secondNumebr = document.getElementById('secondNumber')

    firstNumber = Number(firstNumber.value);
    secondNumebr = Number(secondNumebr.value);

    let sum = firstNumber - secondNumebr;

    let result = document.getElementById('result');
    result.textContent = sum;
}