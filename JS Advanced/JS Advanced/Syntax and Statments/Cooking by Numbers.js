function numberOperations(inputNumber, command1, command2, command3,command4,command5) {
    let number = Number(inputNumber);
    let inputCommands = [command1, command2, command3,command4,command5];

    for (let i = 0; i < inputCommands.length; i++) {
         if (inputCommands[i] == 'chop') {
             number /= 2;
         }
         if (inputCommands[i] == 'dice') {
             number = Math.sqrt(number);
        }
        if (inputCommands[i] == 'spice') {
             number++;
        }
        if (inputCommands[i] == 'bake') {
             number *= 3;
        }
        if (inputCommands[i] == 'fillet') {
             number *= 0.80;
             number = number.toFixed(1);
        }

        console.log(number);
        
    }
}

numberOperations('9', 'dice', 'spice', 'chop', 'bake', 'fillet');