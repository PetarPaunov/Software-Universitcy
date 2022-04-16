function rectangle(width, height, color){
    function capitalLeher(word){
        return word[0].toUpperCase() + word.slice(1);
    }

    function calcArea(){
        return this.width * this.height;
    }

    return {
        width,
        height,
        color: capitalLeher(color),
        calcArea
    }

}



let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());