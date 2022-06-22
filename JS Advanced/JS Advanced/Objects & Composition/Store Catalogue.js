function catalog(input){
    let sortedInput = input.sort((a, b ) => a.localeCompare(b));
    let curentChar = '';

    for (const products of sortedInput) {
        if (curentChar != products[0][0]) {
            curentChar = products[0][0];
            console.log(curentChar);
        }
        let productToLog = products.split(' : ');
        console.log(`  ${productToLog[0]}: ${productToLog[1]}`);
    }
    

}

catalog(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);