function testMovingShapes() {
    var movingShapes = (function () {
        function add(movementType) {
            var element = generateDiv();

            if (movementType === 'rect') {
                element.className = 'rect';
            }
            else if (movementType === 'ellipse') {
                element.className = 'ellipse';
            }

            document.body.appendChild(element);
            ellipseMovement();
            rectMovement();

            function ellipseMovement() {
                var ellipseMovementElements = document.querySelectorAll('.ellipse');
                ellipseMovementElements[0].setAttribute("angleAttr", "0");
                ellipseMovementElements[0].style.left = "650px";
                ellipseMovementElements[0].style.top = "200px";

                setInterval(function () {
                    var angleInRadians = (element.getAttribute("angleAttr")) * (Math.PI / 180);
                    var left = 150 * Math.cos(angleInRadians) + 500;
                    var top = 150 * Math.sin(angleInRadians) + 200;
                    console.log(angleInRadians);
                    element.style.left = left + "px";
                    element.style.top = top + "px";
                    element.attributes.angleAttr.nodeValue++;
                }, 10);
            }

            function rectMovement() {
                var ellipseMovementElements = document.querySelectorAll('.rect');
                var top = 50;
                var left = 50;
                setInterval(function () {
                    if (top <= 200 && left == 50) {
                        top++;
                    }
                    else if (left <= 200 && top > 199) {
                        left++;
                    }
                    else if (left > 199 && top >= 50) {
                        top--;
                    }

                    else if (top < 51 && left >= 50) {
                        left--;
                    }
                    ellipseMovementElements[0].style.top = top + "px";
                    ellipseMovementElements[0].style.left = left + "px";
                }, 10);
            }
            
            function generateDiv() {
                var div = document.createElement('div');
                
                div.style.cssText =
                'background-color: ' + getRandomColor() +
                'color: ' + getRandomColor() +
                'border: 2px solid ' + getRandomColor() +
                'border-radius: 10px;' +
                'width:20px; height: 20px;' + 
                'position: absolute;';

                div.className = 'ellipse';
                
                return div;
            }

            function getRandomColor() {
                var letters = '0123456789ABCDEF'.split('');
                var color = '#';
                for (var i = 0; i < 6; i++) {
                    color += letters[Math.round(Math.random() * 15)];
                }

                return color + '; ';
            }
        }

        return {
            add: add
        };
    })();

    movingShapes.add('ellipse');
    movingShapes.add('rect');
}