function rotateDivs() {
    createElements();
    degrees = 0;
    setInterval(function () {
        rotate()
    }, 100);
}

function rotate() {
    mainDiv.style.cssText = '-webkit-transform: rotate(' + degrees + 'deg);' + 
        '-moz-transform: rotate(' + degrees + 'deg);' + 
        '-o-transform: rotate(' + degrees + 'deg);' + 
        'transform: rotate(' + degrees + 'deg);';
    degrees++;
}

function createElements() {
    var mainDiv = document.createElement('div');
    ;
    var firstDiv = document.createElement('div');
    var secondDiv = document.createElement('div');
    var thirdDiv = document.createElement('div');
    var fourthDiv = document.createElement('div');
    var fifthDiv = document.createElement('div');

    var mainDivElement = document.body.appendChild(mainDiv);
    mainDivElement.id = 'mainDiv';
    mainDivElement.appendChild(firstDiv);
    mainDivElement.appendChild(secondDiv);
    mainDivElement.appendChild(thirdDiv);
    mainDivElement.appendChild(fourthDiv);
    mainDivElement.appendChild(fifthDiv);

    firstDiv.style.cssText = 'top: 10px; left: 138px;';
    secondDiv.style.cssText = 'top: 82px; left: 362px;';
    thirdDiv.style.cssText = 'top: 200px; left: 0;';
    fourthDiv.style.cssText = 'top: 317px; left: 362px;';
    fifthDiv.style.cssText = 'top: 390px; left: 138px;';
}