
function speedLimit(currentSpeed, area) {
    let diference = 0;
    if (area == 'motorway') {
        if (currentSpeed <= 130) {
            console.log(`Driving ${currentSpeed} km/h in a ${130} zone`);
        }else{
            diference = currentSpeed - 130;
            let speedingType = logSpeeding(diference);
            
            console.log(`The speed is ${diference} km/h faster than the allowed speed of ${130} - ${speedingType}`)
        }
        
    }else if (area == 'interstate') {
        if (currentSpeed <= 90) {
            console.log(`Driving ${currentSpeed} km/h in a ${90} zone`);
        }else{
            diference = currentSpeed - 90;
            let speedingType = logSpeeding(diference);
            
            console.log(`The speed is ${diference} km/h faster than the allowed speed of ${90} - ${speedingType}`)
        }
    }else if (area == 'city') {
        if (currentSpeed <= 50) {
            console.log(`Driving ${currentSpeed} km/h in a ${50} zone`);
        }else{
            diference = currentSpeed - 50;
            let speedingType = logSpeeding(diference);
            
            console.log(`The speed is ${diference} km/h faster than the allowed speed of ${50} - ${speedingType}`)
        }
    }else if (area == 'residential') {
        if (currentSpeed <= 20) {
            console.log(`Driving ${currentSpeed} km/h in a ${20} zone`);
        }else{
            diference = currentSpeed - 20;
            let speedingType = logSpeeding(diference);
            
            console.log(`The speed is ${diference} km/h faster than the allowed speed of ${20} - ${speedingType}`)
        }
    }
    function logSpeeding(diference) {
        let speedingType = '';
        if (diference <= 20) {
            speedingType = 'speeding';
        } else if (diference <= 40) {
            speedingType = 'excessive speeding';
        } else {
            speedingType = 'reckless driving';
        }
        return speedingType;
    } 
}

  


console.log(speedLimit(200, 'motorway'))