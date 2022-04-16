function sortByCreteria(input) {
    input.sort((a, b) => {
        if (a.length == b.length) {
            return a.localeCompare(b);
        }
        return a.length - b.length;
        
    });
    for (const item of input) {
        console.log(item);
    }
}

console.log(sortByCreteria(['alpha', 
'beta', 
'gamma']

));