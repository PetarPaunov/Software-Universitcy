
function printRessult(x1, y1, x2, y2) {

    console.log(result(x1, y1, 0, 0));
    console.log(result(x2, y2, 0, 0));
    console.log(result(x1, y1, x2, y2));



    function result(x1, y1, x2, y2) {
        let distance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
        let isValid = Number.isInteger(distance) ? 'valid' : 'invalid';
        return `{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid}`;
    }

}

printRessult(3, 0, 0, 4)

