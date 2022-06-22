function subsetArray(inputArray) {
    let ressult = [];
    ressult.push(inputArray.reduce((acc, num) =>{
        if (num >= acc) {
            acc = num;
            ressult.push(acc);
        }

        return acc;
    }, 0))
    ressult.pop();
    return ressult;
}
subsetArray([20, 
    3, 
    2, 
    15,
    6, 
    1])