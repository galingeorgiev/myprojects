function moveTrash() {
    generateTrashItems();
    createBucket();
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

function createBucket(){
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
    var randomPosition = Math.floor(Math.random() * 900);
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

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function drop(ev, bucketID) {
    ev.preventDefault();
    var trashItem = ev.dataTransfer.getData("dragged-id");
    document.body.removeChild(document.getElementById(trashItem));
    var bucket = document.getElementById(bucketID);
    bucket.setAttribute('src', 'Images\\Trash-Close.png');
}
