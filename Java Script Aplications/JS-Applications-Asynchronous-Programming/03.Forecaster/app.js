function attachEvents() {
    let submitBtn = document.getElementById('submit');
    let locationInput = document.getElementById('location');

    let forcastElement = document.getElementById('forecast');

    let upCommingDiv = document.getElementById('upcoming');

    let div = document.getElementById('current');

    let conditions = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',

    }

    submitBtn.addEventListener('click', function(e){

        Array.from(upCommingDiv.querySelectorAll('div')).forEach((x, i) => {
            i != 0 ? x.remove() : x;
        })

        Array.from(div.querySelectorAll('div')).forEach((x, i) => {
            i != 0 ? x.remove() : x;
        })
      
        let locationUrl = `http://localhost:3030/jsonstore/forecaster/locations`;
        fetch(locationUrl)
        .then(data => data.json())
        .then(location => {
            let locationName = locationInput.value;
            let curentLocation = location.find(x => x.name == locationName);
            return fetch(`http://localhost:3030/jsonstore/forecaster/today/${curentLocation.code}`)
            .then(data => data.json())
            .then(curentWheder => ({code: curentLocation.code, curentWheder}));
        })
        .then(({code, curentWheder}) => {
            createForcastCurentElement(curentWheder);
            return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`);
        })
        .then(date => date.json())
        .then(wetherForNextThreeDays => {
            console.log(wetherForNextThreeDays);
            threeDaysForecast(wetherForNextThreeDays);
        })
    })


    function threeDaysForecast(wetherForNextThreeDays){

        let threeDaysForecastDiv = document.createElement('div');
        threeDaysForecastDiv.classList.add('forecast-info');

        for (let i = 0; i < 3; i++) {
            let upCommingSpan = document.createElement('span');
            upCommingSpan.classList.add('upcoming');

            let span1 = document.createElement('span');
            span1.classList.add('symbol');
            span1.textContent = conditions[wetherForNextThreeDays.forecast[i].condition];
            upCommingSpan.appendChild(span1);

            let span2 = document.createElement('span');
            span2.classList.add('forecast-data');
            span2.textContent = `${wetherForNextThreeDays.forecast[i].low}°/${wetherForNextThreeDays.forecast[i].high}°`;
            upCommingSpan.appendChild(span2);

            let span3 = document.createElement('span');
            span3.classList.add('forecast-data');
            span3.textContent = wetherForNextThreeDays.forecast[i].condition;
            upCommingSpan.appendChild(span3);

            threeDaysForecastDiv.appendChild(upCommingSpan);
        }

        upCommingDiv.appendChild(threeDaysForecastDiv);
    }



    function createForcastCurentElement(whetehrReport){

        forcastElement.style.display = 'block';

        let forcastDiv = document.createElement('div');
        forcastDiv.setAttribute('class', 'forecasts');

        let conditionSymbolSpan = document.createElement('span');
        conditionSymbolSpan.setAttribute('class', 'condition symbol');
        conditionSymbolSpan.textContent = conditions[whetehrReport.forecast.condition];

        let conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');

        let forecastSpan1 = document.createElement('span');
        forecastSpan1.classList.add('forecast-data');
        forecastSpan1.textContent = whetehrReport.name;
        conditionSpan.appendChild(forecastSpan1);

        let forecastSpan2 = document.createElement('span');
        forecastSpan2.classList.add('forecast-data');
        forecastSpan2.textContent = `${whetehrReport.forecast.low}°/${whetehrReport.forecast.high}°`;
        conditionSpan.appendChild(forecastSpan2);

        let forecastSpan3 = document.createElement('span');
        forecastSpan3.classList.add('forecast-data');
        forecastSpan3.textContent = whetehrReport.forecast.condition;
        conditionSpan.appendChild(forecastSpan3);
        

        forcastDiv.appendChild(conditionSymbolSpan);
        forcastDiv.appendChild(conditionSpan);

        div.appendChild(forcastDiv);
    }
}

attachEvents();