class SummerCamp{
    constructor(organizer, location){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        } 
        this.listOfParticipants = [];
    }

    registerParticipant (name, condition, money){

        if(!this.priceForTheCamp.hasOwnProperty(condition)){
            throw new Error("Unsuccessful registration at the camp.");
        }

        if(this.listOfParticipants.some(x => x.name == name)){
            return `The ${name} is already registered at the camp.`;
        }

        if(this.priceForTheCamp[condition] > Number(money)){
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name: name,
            condition: condition,
            power: 100,
            wins: 0
        })

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant (name){

        if(!this.listOfParticipants.some(x => x.name == name)){
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x.name != name);
        return `The ${name} removed successfully.`;
    }

    timeToPlay (typeOfGame, participant1, participant2){
        

        if(typeOfGame == 'WaterBalloonFights'){

            if((!this.listOfParticipants.some(x => x.name == participant1)) 
            || (!this.listOfParticipants.some(x => x.name == participant2))){
                throw new Error(`Invalid entered name/s.`);
            }

            let playerOne = this.listOfParticipants.find(x => x.name == participant1);
            let playerTwo = this.listOfParticipants.find(x => x.name == participant2);

            if(playerOne.condition != playerTwo.condition){
                throw new Error(`Choose players with equal condition.`);
            }

            if(playerOne.power > playerTwo.power){
                playerOne.wins++;
                return `The ${participant1} is winner in the game ${typeOfGame}.`;
            }else if(playerTwo.power > playerOne.power){
                playerTwo.wins++;
                return `The ${participant2} is winner in the game ${typeOfGame}.`;
            }

            return `There is no winner.`;


        }else if(typeOfGame == 'Battleship'){
            if(!this.listOfParticipants.some(x => x.name == participant1)){
                throw new Error(`Invalid entered name/s.`);
            } 
            let player = this.listOfParticipants.find(x => x.name == participant1);
            player.power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString(){
        let result = [];
        let numberOfParticipants = this.listOfParticipants.length;
        result.push(`${this.organizer} will take ${numberOfParticipants} participants on camping to ${this.location}`);

        this.listOfParticipants.sort((a, b) => b.wins - a.wins).forEach(x => {
            result.push(`${x.name} - ${x.condition} - ${x.power} - ${x.wins}`);
        })

        return result.join('\n');
    } 


}


const camp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
camp.registerParticipant('Petar Petarson', 'student', 300), "The Petar Petarson was successfully registered.";
camp.registerParticipant('Sara Dickinson', 'child', 200), "The Sara Dickinson was successfully registered.";
camp.unregisterParticipant('Sara Dickinson'), "The Sara Dickinson removed successfully.";
