function printNthElement(array, elementNumber) {
    let elements = array;
    let elNumber = elementNumber;
    let outputArray = [];
    for (let i = 0; i < elements.length; i += elNumber) {
        outputArray.push(elements[i]);
    }

    return outputArray;
}

printNthElement(['5', 
'20', 
'31', 
'4', 
'20'], 
2);

function printEveryNthElementFromAnArray(input, step) {
    return input.filter((element, index) => index % step == 0);
}

console.log(printEveryNthElementFromAnArray(['5', 
'20', 
'31', 
'4', 
'20'], 
2));



