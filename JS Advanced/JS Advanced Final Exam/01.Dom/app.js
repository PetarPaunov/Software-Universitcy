function solve() {
    let firstNameElement = document.getElementById('fname');
    let lastNameElemement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthDateElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');

    let bugetElement = document.getElementById('sum');

    let tBodyElement = document.getElementById('tbody');

    let addWorkerButton = document.getElementById('add-worker');

    addWorkerButton.addEventListener('click', function(e){
        e.preventDefault();
        if(firstNameElement.value == '' || lastNameElemement.value == '' || emailElement.value == ''
        || birthDateElement.value == '' || positionElement.value == '' || salaryElement.value == ''){
            return;
        }

        let trElemet = document.createElement('tr');

        let firstNameTd = document.createElement('td');
        firstNameTd.textContent = firstNameElement.value;
        trElemet.appendChild(firstNameTd);

        let lastNameTd = document.createElement('td');
        lastNameTd.textContent = lastNameElemement.value;
        trElemet.appendChild(lastNameTd);

        let emailTd = document.createElement('td');
        emailTd.textContent = emailElement.value;
        trElemet.appendChild(emailTd);

        let birthDateTd = document.createElement('td');
        birthDateTd.textContent = birthDateElement.value;
        trElemet.appendChild(birthDateTd);

        let positionTd = document.createElement('td');
        positionTd.textContent = positionElement.value;
        trElemet.appendChild(positionTd);

        let salaryTd = document.createElement('td');
        salaryTd.textContent = salaryElement.value;
        trElemet.appendChild(salaryTd);

        let buttonsTd = document.createElement('td');

        let firedButtun = document.createElement('button');
        firedButtun.setAttribute('class', 'fired');
        firedButtun.textContent = 'Fired';

        firedButtun.addEventListener('click', function(e){
            let elementsToEdit = e.target;
            let elements = elementsToEdit.parentElement.parentElement

            elements1 = Array.from(elements.querySelectorAll('td'));

            let curentSum = Number(bugetElement.textContent);
            curentSum -= Number(elements1[5].textContent);
            bugetElement.textContent = `${curentSum.toFixed(2)}`;

            tBodyElement.removeChild(trElemet);

        })

        buttonsTd.appendChild(firedButtun);

        let editButton = document.createElement('button');
        editButton.setAttribute('class', 'edit');
        editButton.textContent = 'Edit';
        
        editButton.addEventListener('click', function(e){
            let elementsToEdit = e.target;
            let elements = elementsToEdit.parentElement.parentElement

            elements1 = Array.from(elements.querySelectorAll('td'));

            firstNameElement.value = elements1[0].textContent;
            lastNameElemement.value = elements1[1].textContent;
            emailElement.value = elements1[2].textContent;
            birthDateElement.value = elements1[3].textContent;
            positionElement.value = elements1[4].textContent;
            salaryElement.value = elements1[5].textContent;

            let curentSum = Number(bugetElement.textContent);
            curentSum -= Number(elements1[5].textContent);
            bugetElement.textContent = `${curentSum.toFixed(2)}`;
            
            tBodyElement.removeChild(trElemet);
            
        })

        buttonsTd.appendChild(editButton);


        trElemet.appendChild(buttonsTd);
        tBodyElement.appendChild(trElemet);

        let curentSum = Number(bugetElement.textContent);
        curentSum += Number(salaryElement.value);
        bugetElement.textContent = `${curentSum.toFixed(2)}`;

        firstNameElement.value = '';
        lastNameElemement.value = '';
        emailElement.value = '';
        birthDateElement.value = '';
        positionElement.value = '';
        salaryElement.value = '';
    })
}
solve()