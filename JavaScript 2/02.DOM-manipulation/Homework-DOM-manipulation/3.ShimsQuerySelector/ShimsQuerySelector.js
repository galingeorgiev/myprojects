if (typeof document.querySelector === 'undefined') {
    document.querySelectorAll = querySelectorAll;
    document.querySelector = querySelector;
}

function querySelectorAll(selector) {
    var selectors = wrapSelector(selector);
    var selectedElements = executeSelectors(selectors);
    return selectedElements;
}

function querySelector(selectors) {
    var selectors = wrapSelector(selector);
    var selectedElements = executeSelectors(selectors);
    return selectedElements[0];
}

/*We call this function from html file*/
function onTestQuerySelector() {
    var selectedElements = document.querySelectorAll('#wrapper span');
    /*Print content of all elements with ID wrapper and tag name span*/
    for (var i = 0; i < selectedElements.length; i++) {
        console.log(selectedElements[i].innerHTML);
    }
}

function wrapSelector(selector) {
    var selectors = selector.split(' ');
    return selectors;
}

function executeSelectors(selectors) {
    var i = 0;
    var selectedElements = document;
    for (i = 0; i < selectors.length; i++) {
        var currentSelector = selectors[i];
        if (currentSelector.charAt(0) === '#') {
            selectedElements = selectedElements.getElementById(currentSelector.substring(1));
        }
        else if (currentSelector.charAt(0) === '.') {
            selectedElements = selectedElements.getElementsByClassName(currentSelector.substring(1));
        }
        else {
            selectedElements = selectedElements.getElementsByTagName(currentSelector);
        }
    }

    return selectedElements;
}
