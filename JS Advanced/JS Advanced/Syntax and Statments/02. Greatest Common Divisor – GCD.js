function nextDay2(year, month, day) {
    let dateString = year + '-' + month + '-' + day;
    let event = new Date(dateString);
    event.setDate(day - 1);

    console.log(event.getFullYear() + '-' + (Number(event.getMonth()) + 1) + '-' + event.getDate());

}

console.log(nextDay2(2016, 9, 30));