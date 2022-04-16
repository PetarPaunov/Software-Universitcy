function carCreater(input){

    function getEngine(power){
        let engines = [
            { power: 90, volume: 1800 },
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 }
        ]

        return engines.find(x => x.power >= power);
    }

    function getCarriage(carriage, color){
         return {
             type: carriage,
             color
         }
    }

    function getWhiles(whiles){
        let weel = Math.floor(whiles) % 2 == 0 ? Math.floor(whiles) - 1 :  Math.floor(whiles);
        return [weel, weel, weel, weel];
    }
    
    let finaleProduct = {
        model: input.model,
        engine: getEngine(input.power),
        carriage: getCarriage(input.carriage, input.color),
        wheels: getWhiles(input.wheelsize)
    };

    return finaleProduct;
}

console.log(carCreater({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));