function parseToJson(input){
    
    let[pattern, ...table] = input;
    let finalResult = [];
    let obj = {};
    function split(input){
        return input.split('|').filter(x => x != '').map(x => x.trim()).map(x => isNaN(x) ? x : Number(Number(x).toFixed(2)));
    }

    let coloms = split(pattern);
    for (const items of table) {
        let splitedItems = split(items);
        for (let i = 0; i < splitedItems.length; i++) {
            obj[coloms[i]] = splitedItems[i];
            
        }

        let coppy = JSON.parse(JSON.stringify(obj))
     finalResult.push(coppy);
    }

    let result = JSON.stringify(finalResult);

    console.log(result);
}


parseToJson(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);