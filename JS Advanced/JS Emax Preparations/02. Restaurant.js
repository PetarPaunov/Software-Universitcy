class Restaurant {
    constructor(budget) {
        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {

        products.forEach(x => {
            let curentProduct = x.split(' ');
            let [productName, productQuantity, productTotalPrice] = curentProduct;
            productTotalPrice = Number(productTotalPrice);
            productQuantity = Number(productQuantity);
            if(productTotalPrice <= this.budgetMoney){
                this.stockProducts[productName] = productQuantity;
                this.budgetMoney -= Number(productTotalPrice);
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }else{
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
         })

         return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price){
        if(this.menu.hasOwnProperty(meal)){
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let newMeal = {
            products: [],
            price: Number(price)
        }

        neededProducts.forEach(x => {
            let [productName, productQuantity] = x.split(' ');
            let allProducts = {
                productName,
                productQuantity
            }
            newMeal.products.push(allProducts);
        })

        this.menu[meal] = newMeal;

        let mealsCount = Object.keys(this.menu);

        if(mealsCount.length == 1){
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }else{
            return `Great idea! Now with the ${meal} we have ${mealsCount.length} meals in the menu, other ideas?`;
        }
        
    }

    showTheMenu(){
        let result = [];
        let mealsCount = Object.keys(this.menu);

        if(mealsCount.length == 0){
            return "Our menu is not ready yet, please come later...";
        }

        for(let i = 0; i < mealsCount.length; i++){
            result.push(`${mealsCount[i]} - $ ${this.menu[mealsCount[i]].price}`);
        }

        return result.join('\n');

    }

    makeTheOrder(meal){
        if(!this.menu.hasOwnProperty(meal)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let neededProducts = this.menu[meal].products;
        let price = this.menu[meal].price;
        let haveAll = false;

        for (const product of neededProducts) {
            if(this.stockProducts.hasOwnProperty(product.productName)){
                if(this.stockProducts[product.productName] >= product.productQuantity){
                    haveAll = true;
                    continue;
                }else{
                    haveAll = false;
                    break;
                }
            }
        }

        if(!haveAll){
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }else{
            this.budgetMoney += Number(price);
            for (const product of neededProducts) {
                this.stockProducts[product.productName]--;
            }
            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`;
        }
    }

}