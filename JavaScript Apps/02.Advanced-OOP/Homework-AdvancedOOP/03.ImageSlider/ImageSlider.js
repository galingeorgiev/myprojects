(function () {
    /*---------------------------Create classes --------------------------*/
    var ImageSlider = {
        init: function (sliderHolderSelector, setOfImages) {
            this.sliderHolderSelector = sliderHolderSelector;
            this.setOfImages = setOfImages;
            this.currentImageIndex = 2;
            this.currentImage;
            this.changeLargeImage();
            this.initElements();
        },
        nextImage: function () {
            //this.currentImage = this.setOfImages[this.currentImageIndex++].largeImageURL;
            //console.log(this.setOfImages);
            //console.log(this.currentImageIndex);
        },
        prevImage: function () {
            this.currentImage = this.setOfImages[this.currentImageIndex++].largeImageURL;
            console.log(this.setOfImages);
            console.log(this.currentImageIndex);
        },
        initElements: function () {
            var that = this;
            var i = 0;

            var sliderHolder = document.querySelector(this.sliderHolderSelector);
            sliderHolder.innerHTML = "";
            sliderHolder.style.cssText = "width: 850px; margin: 0 auto;";

            var nextButton = document.createElement("button");
            var prevButton = document.createElement("button");

            nextButton.innerHTML = "Next";
            prevButton.innerHTML = "Prev";

            nextButton.style.cssText = "display: inline-block;";
            prevButton.style.cssText = "display: inline-block;";

            prevButton.addEventListener("click", function () {
                that.currentImageIndex--;
                if (that.currentImageIndex == -1) {
                    that.currentImageIndex = that.setOfImages.length - 1;
                }
                that.changeLargeImage();
            }, false);

            nextButton.addEventListener("click", function () {
                that.currentImageIndex++;
                if (that.currentImageIndex == that.setOfImages.length) {
                    that.currentImageIndex = 0;
                }
                that.changeLargeImage();
            }, false);


            var image = document.createElement("img");
            image.src = this.currentImage;
            image.style.cssText = "display: inline-block; margin: 0 auto; width:750px; height:500px;";

            var thumbHolder = document.createElement("div");
            thumbHolder.style.cssText = "width: 760px; margin: 0 auto;";

            for (i = 0; i < 5; i++) {
                var imageThumb = document.createElement("img");
                imageThumb.src = this.setOfImages[i].thumbnailURL;
                imageThumb.style.cssText = "display: inline-block; width: 150px; height: 100px;";
                imageThumb.addEventListener("click", function () {
                    var str = event.target.src;
                    var number = str.charAt(str.length - 5);
                    that.currentImageIndex = (number || 1) - 1;
                    that.changeLargeImage();
                }, false);
                thumbHolder.appendChild(imageThumb);
            }

            sliderHolder.appendChild(thumbHolder);
            sliderHolder.appendChild(prevButton);
            sliderHolder.appendChild(image);
            sliderHolder.appendChild(nextButton);
        },
        changeLargeImage: function () {
            this.currentImage = this.setOfImages[this.currentImageIndex].largeImageURL;
            this.initElements();
        }
    };

    var Image = {
        init: function (title, largeImageURL, thumbnailURL) {
            this.title = title;
            this.largeImageURL = largeImageURL;
            this.thumbnailURL = thumbnailURL;
        }
    };

    /*---------------------------Test classes functionality --------------------------*/
    var img1 = Object.create(Image);
    img1.init("Sunshine1", "images/image1.jpg", "images/thumbnailImage1.jpg");
    var img2 = Object.create(Image);
    img2.init("Sunshine2", "images/image2.jpg", "images/thumbnailImage2.jpg");
    var img3 = Object.create(Image);
    img3.init("Sunshine3", "images/image3.jpg", "images/thumbnailImage3.jpg");
    var img4 = Object.create(Image);
    img4.init("Sunshine4", "images/image4.jpg", "images/thumbnailImage4.jpg");
    var img5 = Object.create(Image);
    img5.init("Sunshine5", "images/image5.jpg", "images/thumbnailImage5.jpg");

    var imagesSet = [img1, img2, img3, img4, img5];

    var slider = Object.create(ImageSlider);
    slider.init("#slideHolder", imagesSet);
}());