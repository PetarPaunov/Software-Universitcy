function solve() {
    let stopName = document.querySelector('#info span');
    let departBtn = document.getElementById('depart')
    let arriveBtn = document.getElementById('arrive')
    let stop = {
        next: 'depot',
    }

    function depart() {
        let url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        fetch(url)
        .then(data => data.json())
        .then(stopInfo => {
            stop = stopInfo;
            stopName.textContent = `Next stop ${stopInfo.name}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        })
        .catch(err => {
            stopName.textContent = 'Error';
        })
    }

    function arrive() {
        stopName.textContent = `Arriving at ${stop.name}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();