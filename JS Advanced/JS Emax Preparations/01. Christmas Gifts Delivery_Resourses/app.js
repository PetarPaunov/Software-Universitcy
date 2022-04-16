function solution() {
    let sectionElements = Array.from(document.querySelectorAll(".card"));

    let sendGiftElement = sectionElements[0];
    let listOfGiftsElement = sectionElements[1];
    let sendedGiftElement = sectionElements[2];
    let discardGiftElement = sectionElements[3];

    let addGiftButton = sendGiftElement.querySelector("button");

    addGiftButton.addEventListener("click", function (e) {
        let inputElement = sendGiftElement.querySelector("input");

        let liEelement = document.createElement("li");
        liEelement.textContent = inputElement.value;
        let elementName = liEelement.textContent;
        liEelement.className = "gift";
        let sendButton = document.createElement("button");
        sendButton.id = "sendButton";
        sendButton.textContent = "Send";
        sendButton.addEventListener('click', function(e){
            liEelement.remove();
            let ul = sendedGiftElement.querySelector('ul');
            let li = document.createElement('li');
            li.textContent = elementName;
            ul.appendChild(li);
        });
        let discardButton = document.createElement("button");
        discardButton.id = "discardButton";
        discardButton.textContent = "Discard";
        discardButton.addEventListener('click', function(e){
            liEelement.remove();
            let ul = discardGiftElement.querySelector('ul');
            let li = document.createElement('li');
            li.textContent = elementName;
            ul.appendChild(li);
        })
        liEelement.appendChild(sendButton);
        liEelement.appendChild(discardButton);

        let ulElement = listOfGiftsElement.querySelector("ul");

        ulElement.appendChild(liEelement);

        sortedGifts(ulElement);

        inputElement.value = "";
    });

    function sortedGifts(ul) {
        Array.from(ul.getElementsByTagName("LI"))
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach((li) => ul.appendChild(li));
    }

}
