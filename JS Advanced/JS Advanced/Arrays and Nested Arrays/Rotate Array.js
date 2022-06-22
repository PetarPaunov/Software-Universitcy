function rotateElements(input, rotate) {
    let rotatedArray = input;
    
    for (let i = 0; i < rotate; i++) {
        let currentElement = rotatedArray.pop();
        rotatedArray.unshift(currentElement);

    }

    console.log(rotatedArray.join(' '));
}

rotateElements(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15)