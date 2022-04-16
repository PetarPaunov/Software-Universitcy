function solve(arr, sortingCriteria){
    let tickeds = [];
    class Ticket{
        constructor(destinationName, price, status){
            this.destination = destinationName;
            this.price = price;
            this.status = status;
        }
    }

    arr.forEach(element => {
        let info = element.split('|');
        let ticked = new Ticket(info[0], Number(info[1]), info[2]);
        tickeds.push(ticked);
    });

    if(sortingCriteria == 'destination'){
        tickeds.sort((a,b) => a.destination.localeCompare(b.destination));
    }else if(sortingCriteria == 'price'){
        tickeds.sort((a,b) => a.price - b.price);

    }else if(sortingCriteria == 'status'){
        tickeds.sort((a,b) => a.status.localeCompare(b.status));
    }

    return tickeds;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));