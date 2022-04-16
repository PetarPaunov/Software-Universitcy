function getInfo() {
    let inputElement = document.getElementById('stopId');
    let url = `http://localhost:3030/jsonstore/bus/businfo/${inputElement.value}`;
    let bussesElemet = document.getElementById('buses');

    fetch(url)
        .then(body => body.json())
        .then(stopInfo => {
            document.getElementById('stopName').textContent = stopInfo.name;
            bussesElemet.querySelectorAll('li').forEach(li => li.remove());
            Object.entries(stopInfo.buses).forEach(x => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`;
                bussesElemet.appendChild(liElement);
            })
        })
        .catch(err => {
            document.getElementById('stopName').textContent = 'Error';
            bussesElemet.querySelectorAll('li').forEach(li => li.remove());
        })
}