let tbodyElement = document.querySelector('#results tbody');
document.getElementById('form').addEventListener('submit', addNewStudent);
getExistiongStudents();
class Student{
    constructor(firstName , lastName, facultyNumber, grade){
        this.firstName = firstName;
        this.lastName = lastName;
        this.facultyNumber = facultyNumber;
        this.grade = grade;
    }
}

async function addNewStudent(e){
    e.preventDefault();
    let newForm = new FormData(e.target);
    let firstName = newForm.get('firstName');
    let lastName = newForm.get('lastName');
    let facultyNumber = newForm.get('facultyNumber');
    let grade = newForm.get('grade');

    if(firstName == '' || lastName == ''|| 
        facultyNumber == '' || grade == ''){
            return;
        }

    let student = new Student(firstName, lastName, facultyNumber, grade);

    let url = `http://localhost:3030/jsonstore/collections/students`;
    let resposnse = await fetch(url,{
        method: 'POST',
        headers:{
            'Content-Type': 'aplication/json'
        },
        body: JSON.stringify(student)
    });
    let result = await resposnse.json();
    createStudents(result);
}

async function getExistiongStudents(){
    let url = `http://localhost:3030/jsonstore/collections/students`;
    let resposnse = await fetch(url);
    let data = await resposnse.json();

    console.log(data);

    Object.values(data).forEach(x => createStudents(x));
}

function createStudents(student){
    let trElement = document.createElement('tr');

    let thFirstNameElement = document.createElement('td');
    thFirstNameElement.textContent = student.firstName;
    trElement.appendChild(thFirstNameElement);

    let thLastNameElement = document.createElement('td');
    thLastNameElement.textContent = student.lastName;
    trElement.appendChild(thLastNameElement);

    let thFacultyNumberElement = document.createElement('td');
    thFacultyNumberElement.textContent = student.facultyNumber;
    trElement.appendChild(thFacultyNumberElement);

    let thGradeElement = document.createElement('td');
    thGradeElement.textContent = student.grade;
    trElement.appendChild(thGradeElement);

    tbodyElement.appendChild(trElement);

}