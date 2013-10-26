function showMenu(currentElementID) {
    var currentElement = document.getElementById(currentElementID);
    var childElement = currentElement.nextElementSibling;

    if (childElement.className == 'visible') {
        childElement.className = '';
    }
    else {
        childElement.className = 'visible';
    }
}