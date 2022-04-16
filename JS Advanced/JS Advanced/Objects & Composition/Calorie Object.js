function caloriObject(input){
    let caloriObj = {}

    for (let i = 0; i < input.length; i += 2) {
        caloriObj[input[i]] = Number(input[i + 1]);
        
    }

    return caloriObj;
}

console.log(caloriObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));