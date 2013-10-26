$(document).ready(function () {
    var imagesSource = [
        'images/thumbnailImage1.jpg',
        'images/thumbnailImage2.jpg',
        'images/thumbnailImage3.jpg',
        'images/thumbnailImage4.jpg',
        'images/thumbnailImage5.jpg'];

    var counter = 0;
    var interval = 5000;

    var sliderContainer = $("#sliderContainer");
    var $image = $('<img />').attr({ 'id': 'Myid', 'src': imagesSource[counter], 'alt': 'Sunshine', 'width': '200', 'height': '150' });
    var $imageContainer = $("<div id='imageContainer'></div>").append($image);

    sliderContainer.append("<div><span><</span></div>", $imageContainer, "<div><span>></span></div>");
    $("#sliderContainer > div:first-of-type").bind("click", changeImage);
    $("#sliderContainer > div:last-of-type").bind("click", changeImage);
    $("#imageContainer").fadeOut(interval).fadeIn(interval);

    setInterval(changeImage, interval);

    function changeImage() {
        if (counter >= imagesSource.length - 1) {
            counter = -1;
        }
        counter++;
        $("#sliderContainer img").attr({ 'src': imagesSource[counter] });
        $("#imageContainer").load();
        $("#imageContainer").fadeOut(interval).fadeIn(interval);
    }
});