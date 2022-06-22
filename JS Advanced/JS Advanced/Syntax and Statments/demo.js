let fruit = "orange";
let weight = 2500;
let pricePerKg = 1.80;

function calcolateFruitMoney(fruit, weight, pricePerKg) {
    let currentWeight = weight / 1000;
    let moenyNeeded = currentWeight * pricePerKg;
    console.log(`I need $${moenyNeeded.toFixed(2)} to buy ${currentWeight.toFixed(2)} kilograms ${fruit}.`)
}

calcolateFruitMoney(fruit, weight, pricePerKg);