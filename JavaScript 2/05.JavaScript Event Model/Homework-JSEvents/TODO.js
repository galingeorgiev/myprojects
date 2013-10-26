function addNewItem() {
    var fragment = document.createDocumentFragment();
    var todoList = document.getElementById('TODOList');

    var newLiElement = document.createElement('li');

    var newDivElement = document.createElement('div');
    var divContent = addText();
    newDivElement.style.cssText = 'height: 1.1em; overflow: hidden;';
    newDivElement.innerHTML = divContent;
    fragment.appendChild(newDivElement);

    var newDeleteElement = document.createElement('img');
    newDeleteElement.setAttribute('src', 'Images/deleteTODO.png');
    newDeleteElement.setAttribute('width', '30');
    newDeleteElement.setAttribute('height', '30');
    newDeleteElement.addEventListener('click', removeItem, false);
    fragment.appendChild(newDeleteElement);

    var newAElement = document.createElement('a');
    newAElement.innerHTML = 'Show';
    newAElement.addEventListener("click", showContent, false);
    newAElement.href = '#';
    fragment.appendChild(newAElement);

    todoList.appendChild(newLiElement);
    var newItem = todoList.lastChild;
    newItem.appendChild(fragment);
}

function showContent(event) {
    var currentElement = event.target;
    var currentParent = currentElement.parentNode;
    currentItem = currentParent.getElementsByTagName('div');

    if (currentElement.innerHTML === 'Hide') {
        currentElement.innerHTML = 'Show';
        currentItem[0].style.cssText = 'height: 1.1em; overflow: hidden;';
    }
    else {
        currentElement.innerHTML = 'Hide';
        currentItem[0].style.cssText = 'height: auto;';
    }
}

function removeItem(event) {
    var currentElement = event.target;
    var currentParent = currentElement.parentNode;
    console.log(currentParent);
    currentParent.parentNode.removeChild(currentParent);
    console.log(currentParent);
}

function addText() {
    var itemContent = prompt('Enter item content here.');
    return itemContent;
}