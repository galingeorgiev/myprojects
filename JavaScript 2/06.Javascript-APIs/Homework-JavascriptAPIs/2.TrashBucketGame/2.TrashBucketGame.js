function moveTrash() {
    generateTrashItems();
    createBucket();
    orderResults();
}

function generateTrashItems() {
    var i = 0;
    for (i = 0; i < 10; i++) {
        var image = document.createElement('img');
        image.setAttribute('id', 'trashItem' + i);
        image.setAttribute('src', 'Images\\Trash-Item.png');
        image.setAttribute('draggable', 'true');
        image.setAttribute('ondragstart', 'drag(event)');
        image.style.cssText =
        'position: absolute; ' +
        'top: ' + generateRandomPosition() +
        'left: ' + generateRandomPosition();
        document.body.appendChild(image);
    }
}

function createBucket() {
    var bucket = document.createElement('img');
    bucket.setAttribute('src', 'Images\\Trash-Close.png');
    bucket.setAttribute('id', 'bucket');
    bucket.setAttribute('ondragleave', 'restoreBucket(this.id)');
    bucket.setAttribute('ondrop', 'drop(event, this.id)');
    bucket.setAttribute('ondragover', 'allowDrop(event, this.id)');
    document.body.appendChild(bucket);
}

function restoreBucket(bucketID) {
    var bucket = document.getElementById(bucketID);
    bucket.setAttribute('src', 'Images\\Trash-Close.png');
}

function generateRandomPosition() {
    var randomPosition = Math.floor(Math.random() * 600);
    if (randomPosition < 100) {
        randomPosition = randomPosition + 100;
    }
    return randomPosition + 'px;';
}

function allowDrop(ev, bucketID) {
    ev.preventDefault();
    var bucket = document.getElementById(bucketID);
    bucket.setAttribute('src', 'Images\\Trash-Open.png');
}

var isTimerStart = false;

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);

    if (!isTimerStart) {
        isTimerStart = true;
        callTimer = setInterval(function () {
            myTimer()
        }, 1000);
    }
}

function drop(ev, bucketID) {
    ev.preventDefault();
    var trashItem = ev.dataTransfer.getData("dragged-id");
    document.body.removeChild(document.getElementById(trashItem));
    var bucket = document.getElementById(bucketID);
    bucket.setAttribute('src', 'Images\\Trash-Close.png');

    var numberOfImgs = document.querySelectorAll('img').length;
    if (numberOfImgs === 1) {
        myStopFunction();
        document.getElementById('getResult').style.display = 'block';
    }
}

var callTimer;
var secondsTimer = 0;

function myTimer() {
    secondsTimer++;
    document.getElementById("demo").innerHTML = 'Time: ' + secondsTimer;
}

function myStopFunction() {
    window.clearInterval(callTimer);
}

function saveResult() {
    document.getElementById('getResult').style.display = 'none';
    var name = document.getElementById('playerName').value;
    localStorage.setItem(name, secondsTimer);
    orderResults();
}

function orderResults() {
    var bestResults = [];

    for (var key in localStorage) {
        bestResults.push({ name: key, result: localStorage.getItem(key) });
    }

    bestResults.sort(function (a, b) { return (parseInt(a.result) - parseInt(b.result)) });
    
    drawResult(bestResults);
}

function drawResult(bestResults) {
    var resultHTML = 'Best results: <br /><ol>';

    var lenghtOfLoop = bestResults.length;
    if (lenghtOfLoop > 5) {
        lenghtOfLoop = 5;
    }

    for (var i = 0; i < lenghtOfLoop; i++) {
        resultHTML = resultHTML + '<li>' + bestResults[i].name + ' - ' + bestResults[i].result + 'sec.</li>';
    }

    resultHTML = resultHTML + '</ol>';
    document.getElementById('result').innerHTML = resultHTML;
}
