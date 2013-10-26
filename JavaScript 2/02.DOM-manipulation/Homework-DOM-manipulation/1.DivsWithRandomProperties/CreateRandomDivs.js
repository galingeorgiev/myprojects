function createRandomDivs(numberOfDivs) {
    var i;
    for (i = 0; i < numberOfDivs; i++) {
        var divElement = document.createElement('div');
        divElement.style.cssText = 'width: ' + getRandomSize() +
            'height: ' + getRandomSize() +
            'background-color: ' + getRandomColor() +
            'position: absolute; left: ' + getRandomPositionLeft() +
            'top: ' + getRandomPositionTop() +
            'border-radius: ' + getRandomSize() +
            'border-color: ' + getRandomColor() +
            'border-width: ' + getRandomBorderWidth() +
            'border-style: solid;';
        divElement.innerHTML = getStrongElementWithText();
        document.body.appendChild(divElement);
    }
}

function getRandomSize() {
    //width is between 20px and 100px
    var width = Math.floor((Math.random() * 100) + 1);
    if (width < 20) {
        width = width + 20;
    }
    else if (width > 100) {
        //Without this does not work correct, in one off 200 cases this return number bigger from 100.
        //With this line work perfect
        getRandomWidth();
    }

    return width + 'px; ';
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.round(Math.random() * 15)];
    }

    return color + '; ';
}

function getRandomPositionTop() {
    var positionTop = Math.round(Math.random() * 768);
    return positionTop + 'px; ';
}

function getRandomPositionLeft() {
    var positionLeft = Math.round(Math.random() * 1024);
    return positionLeft + 'px; ';
}

function getStrongElementWithText() {
    var elementWithText = '<strong style="padding: 10px;">div</strong>';
    return elementWithText;
}

function getRandomBorderWidth() {
    var borderWidth = Math.round((Math.random() * 19) + 1);
    return borderWidth + 'px; ';
}