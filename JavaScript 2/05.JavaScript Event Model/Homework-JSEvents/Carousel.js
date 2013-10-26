function carousel() {
    hideImages();
}

var startImage = 0;
var numberOfImages = 3;

function getCarousel(direction) {
    var carouselImages = document.getElementsByClassName('carousel');

    if (direction === 'left') {
        if (startImage === (carouselImages.length - numberOfImages - 1)) {
            startImage = 0;
        }
        else {
            startImage++;
        }

        hideImages();
    }  
    else if (direction === 'right') {
        if (startImage === 0) {
            startImage = carouselImages.length - numberOfImages - 1;

            if (startImage === carouselImages.length - 1) {
                startImage = 0;
            }
        }
        else {
            startImage--;
        }

        hideImages();
    }
}

function hideImages() {
    var i = 0;
    var carouselImages = document.getElementsByClassName('carousel');

    for (i = 0; i < carouselImages.length; i++) {
        if (i <= startImage || i > (startImage + numberOfImages)) {
            carouselImages[i].className = 'carousel carousel-unvisible';
        }
        else {
            carouselImages[i].className = 'carousel';
        }
    }
}

function goLeft() {
    var leftButton = document.getElementById('left-arrow');
    leftButton.setAttribute('width', '40');
    leftButton.setAttribute('height', '40');
    leftButton.style.cssText = 'margin: 83px 5px 0 5px;';
    getCarousel('left');
}

function goRight() {
    var rightButton = document.getElementById('right-arrow');
    rightButton.setAttribute('width', '40');
    rightButton.setAttribute('height', '40');
    rightButton.style.cssText = 'margin: 83px 5px 0 5px;';
    getCarousel('right');
}

function makeButtonNormal() {
    var leftButton = document.getElementById('left-arrow');
    leftButton.setAttribute('width', '50');
    leftButton.setAttribute('height', '50');
    leftButton.style.cssText = 'margin-top: 78px;';

    var rightButton = document.getElementById('right-arrow');
    rightButton.setAttribute('width', '50');
    rightButton.setAttribute('height', '50');
    rightButton.style.cssText = 'margin-top: 78px;';
}