function arrayDelimeter(input, inputDelimeter) {

    let array = input;
    let delimeter = inputDelimeter;

    let output = array.join(delimeter);

    console.log(output);
}

arrayDelimeter(['One',
    'Two',
    'Three',
    'Four',
    'Five'],
    '-')