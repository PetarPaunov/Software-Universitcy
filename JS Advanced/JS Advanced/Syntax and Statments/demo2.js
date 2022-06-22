function longWalk(steps, meters, kmh) {
    let mInSec = kmh * (5/18);
    let distance = steps * meters;
    let rest = Math.floor(distance / 500)*60;
    let time = distance / mInSec + rest;

    let hours = Math.floor(time / 60 / 60).toFixed(0).padStart(2, '0');
    let minutes = Math.floor((time - hours * 3600) / 60).toFixed(0).padStart(2, '0');
    let seconds = (time - hours *60*60 - minutes * 60).toFixed(0).padStart(2, '0');

    return `${hours}:${minutes}:${seconds}`
}


console.log(longWalk(4000, 0.60, 5));