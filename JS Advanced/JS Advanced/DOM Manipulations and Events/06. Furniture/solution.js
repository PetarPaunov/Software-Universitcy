function solve() {
	let textAreas = document.querySelectorAll("textarea");
	let buttons = document.querySelectorAll("button");
	let tbodyElement = document.querySelector("tbody");

	buttons[0].addEventListener("click", function (e) {
		if (textAreas[0].value == "") {
			return;
		}
		let arr = JSON.parse(textAreas[0].value);
		let tbodyElement = document.querySelector("tbody");

		for (const el of arr) {
			let trElement = document.createElement("tr");

			let tdImg = document.createElement("td");
			let img = document.createElement('img');
			img.setAttribute('src', el.img)
			tdImg.appendChild(img);
			trElement.appendChild(tdImg);

			let tdName = document.createElement("td");
			let pName = document.createElement('p');
			pName.textContent = el.name;
			tdName.appendChild(pName);
			trElement.appendChild(tdName);
			
			let tdPrice = document.createElement("td");
			let pPrice = document.createElement('p');
			pPrice.textContent = el.price;
			tdPrice.appendChild(pPrice);
			trElement.appendChild(tdPrice);

			let tdFactor = document.createElement("td");
			let pFactor = document.createElement('p');
			pFactor.textContent = el.decFactor;
			tdFactor.appendChild(pFactor);
			trElement.appendChild(tdFactor);

			let tdCheckBox = document.createElement("td");
			let input = document.createElement('input');
			input.setAttribute('type', 'checkbox');
			tdCheckBox.appendChild(input);
			trElement.appendChild(tdCheckBox);

			tbodyElement.appendChild(trElement);
		}
	});

	buttons[1].addEventListener('click', function(e){

		let furnicher = Array.from(tbodyElement.querySelectorAll('input[type=checkbox]:checked'))
		.map(x => x.parentNode.parentNode);


		let result = {
			bouth:[],
			totalPrice: 0,
			decFactorSum: 0
		}

		for (const row of furnicher) {
			
			let cell = row.children;

			let name = cell[1].children[0].textContent;
			result.bouth.push(name);

			let price = Number(cell[2].children[0].textContent);
			result.totalPrice += price;

			let factor = Number(cell[3].children[0].textContent);
			result.decFactorSum += factor;
		}

		textAreas[1].value = `Bought furniture: ${result.bouth.join(', ')}\nTotal price: ${result.totalPrice.toFixed(2)}\nAverage decoration factor: ${result.decFactorSum / furnicher.length}`
	})
}
