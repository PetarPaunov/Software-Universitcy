function crow(input){
    if (input.dizziness == false) {
        return input;
    }

    input.levelOfHydrated += input.weight * 0.1;
    input.dizziness = false;

    return input;
}

console.log(crow({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }));