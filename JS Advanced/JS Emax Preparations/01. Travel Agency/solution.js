window.addEventListener('load', solution);

function solution() {

	let fullNameInputElement = document.getElementById('fname');
	let emailInputElement = document.getElementById('email');
	let phoneInputElement = document.getElementById('phone');
	let addresInputElement = document.getElementById('address');
	let posteCodeInputElement = document.getElementById('code');

	let ulPreviewElement = document.getElementById('infoPreview');

	let editButton = document.getElementById('editBTN');
	let continiunButton = document.getElementById('continueBTN');

	let button = document.getElementById('submitBTN');

	button.addEventListener('click', function(e){

		if(fullNameInputElement.value == '' || emailInputElement.value == ''){
			return;
		}

		let nameLi = document.createElement('li');
		nameLi.textContent = 'Full Name: ' + fullNameInputElement.value;
		ulPreviewElement.appendChild(nameLi);

		let emailLi = document.createElement('li');
		emailLi.textContent = 'Email: ' + emailInputElement.value;
		ulPreviewElement.appendChild(emailLi);

		let phoneLi = document.createElement('li');
		phoneLi.textContent = 'Phone Number: ' + phoneInputElement.value;
		ulPreviewElement.appendChild(phoneLi);

		let addresLi = document.createElement('li');
		addresLi.textContent = 'Address: ' + addresInputElement.value;
		ulPreviewElement.appendChild(addresLi);

		let posteCodeLi = document.createElement('li');
		posteCodeLi.textContent = 'Postal Code: ' + posteCodeInputElement.value;
		ulPreviewElement.appendChild(posteCodeLi);

		fullNameInputElement.value = '';
		emailInputElement.value = '';
		phoneInputElement.value = '';
		addresInputElement.value = '';
		posteCodeInputElement.value = '';

		button.disabled = true;
		editButton.disabled = false;
		continiunButton.disabled = false;

	})

	editButton.addEventListener('click', function(e){
		let arr = [];
		let li = Array.from(ulPreviewElement.querySelectorAll('li'));
		
		for (const item of li) {
			let needed = item.textContent.split(': ');
			arr.push(needed[1]);
		}

		fullNameInputElement.value = arr.shift();
		emailInputElement.value = arr.shift();
		phoneInputElement.value = arr.shift();
		addresInputElement.value = arr.shift();
		posteCodeInputElement.value = arr.shift();

		ulPreviewElement.innerHTML = '';

		button.disabled = false;
		editButton.disabled = true;
		continiunButton.disabled = true;
		
	})


	continiunButton.addEventListener('click', function(e){

		let div	 = document.getElementById('block');
		div.innerHTML = '';

		let h3 = document.createElement('h3');
		h3.textContent = 'Thank you for your reservation!';

		div.appendChild(h3);
	})
}
