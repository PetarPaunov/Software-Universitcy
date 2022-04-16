function sortNum(inputArray){
    let isBiggest = false;
    let finaleRessult = [];
    inputArray.sort((a,b) => a - b);
    while(inputArray.length > 0){
        if (!isBiggest) {
            isBiggest = true;
            finaleRessult.push(inputArray.shift());
        }
        else{
            isBiggest = false;
            finaleRessult.push(inputArray.pop());
        }
    }

    return finaleRessult;

}

console.log(sortNum([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));

function sortNum(inputArray){
    
    let finaleRessult = [];
    inputArray.sort((a,b) => a - b);
    let bigNumbers = (inputArray.splice(inputArray.length / 2 , inputArray.length - 1)).reverse();

    for (let i = 0; i < inputArray.length; i++) {

        finaleRessult.push(inputArray[i], bigNumbers[i]);
        
    }

    return finaleRessult;

}

console.log(sortNum([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));