class Bank {
    constructor(bankName){
        this._bankName = bankName;
        this.allCustomers = [];
        this.transactions = [];
    }

    newCustomer (customer){
        
        let curentCustomer = this.allCustomers.find(x => x.firstName == customer.firstName || x.lastName == customer.lastName);

        if(curentCustomer != undefined){
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney (personalId, amount){
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if(customer == undefined){
            throw new Error(`We have no customer with this ID!`);
        }

        if(!customer.hasOwnProperty('totalMoney')){
            customer['totalMoney'] = amount;
        }else{
            customer['totalMoney'] += amount;
        }

        

        this.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);

        return customer['totalMoney'] + '$';

    }

    withdrawMoney (personalId, amount){
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if(customer == undefined){
            throw new Error(`We have no customer with this ID!`);
        }

        if(customer.totalMoney - amount < 0){
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);                
        }

        customer.totalMoney -= amount;
        this.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return customer.totalMoney + '$';
    }

    customerInfo (personalId){
        let customer = this.allCustomers.find(x => x.personalId == personalId);

        if(customer == undefined){
            throw new Error(`We have no customer with this ID!`);
        }
        let result = '';
        let transactions = this.transactions.filter(x => x.includes(customer.firstName));
        transactions = transactions.reverse();
        let conut = transactions.length;
        

        result += `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer.totalMoney}$\n`;
        result += 'Transactions:\n';
        
        for (const transaction of transactions) {
            result += `${conut--}. ${transaction}\n`;
        }

        return result.trimEnd();
        

    }
}



let bank = new Bank('Softuni Bank');
 
bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 });
 
 
bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 3333333 });
 
bank.depositMoney(1111111, 250);
 
bank.depositMoney(1111111, 250);
 
bank.depositMoney(3333333, 555);
 
bank.withdrawMoney(1111111, 125);
 
console.log(bank.customerInfo(1111111));


