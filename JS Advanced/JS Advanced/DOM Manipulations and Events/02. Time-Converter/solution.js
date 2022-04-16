function attachEventsListeners() {
    let daysElemtnt = document.getElementById('days')
    let hoursElemtnt = document.getElementById('hours')
    let minutesElemtnt = document.getElementById('minutes')
    let secondsElemtnt = document.getElementById('seconds')

    let daysButton = document.getElementById('daysBtn');
    let hoursButton = document.getElementById('hoursBtn');
    let minutesButton = document.getElementById('minutesBtn');
    let secondsButton = document.getElementById('secondsBtn');
    

    daysButton.addEventListener('click', function(e){
        let days = daysElemtnt.value;
        hoursElemtnt.value = days * 24;
        minutesElemtnt.value = days * 1440;
        secondsElemtnt.value = days * 86400;
    })

    hoursButton.addEventListener('click', function(e){
        let hours = hoursElemtnt.value;
        daysElemtnt.value = hours / 24;
        minutesElemtnt.value = hours * 60;
        secondsElemtnt.value = hours * 60 * 60;
    })

    minutesButton.addEventListener('click', function(e){
        let minutes = minutesElemtnt.value;
        daysElemtnt.value = minutes / 60 / 24;
        hoursElemtnt.value = minutes / 60;
        secondsElemtnt.value = minutes * 60;
    })

    secondsButton.addEventListener('click', function(e){
        let secundes = secondsElemtnt.value;
        daysElemtnt.value = secundes / 60 / 60 / 24;
        hoursElemtnt.value = secundes / 60 /60;
        minutesElemtnt.value = secundes / 60;
    })
}