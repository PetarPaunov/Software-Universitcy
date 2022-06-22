function addRemoveElemets(input) {
    let array = [];
    for (let i = 0; i < input.length; i++) {
        
        if (input[i] == 'add') {
            array.push(i + 1);
        }else{
            array.pop();
        }
        
    }
    if (array.length == 0) {
        console.log('Empty');
        
    }else{
        for (const num of array) {
            console.log(num);
        }
    }
    
}

addRemoveElemets(['add', 
'add', 
'add', 
'add']
)