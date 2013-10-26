// position, size, fcolor, scolor, speed, direction
module("MovingGameObject.init");
test("should set correct values",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);
         equal(movingGameObject.position, position)
         equal(movingGameObject.size, 15);
         equal(movingGameObject.fcolor, fillColor);
         equal(movingGameObject.scolor, strokeColor);
         equal(movingGameObject.speed, speed);
         equal(movingGameObject.direction, dir);
     });

module("MovingGameObject.move");
test("When  direction is 1, decrease update y",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.move();
         position.x - speed;
         deepEqual(movingGameObject.position, position);
     });
test("When  direction is 1, decrease update y",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.move();
         position.y - speed;
         deepEqual(movingGameObject.position, position);
     });
test("When  direction is 2, increase x",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.move();
         position.x + speed;
         deepEqual(movingGameObject.position, position);
     });
test("When  direction is 3, should increase x",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.move();
         position.y + speed;
         deepEqual(movingGameObject.position, position);
     });

module("MovingGameObject.changeDirection");
test("When  direction is 0, change direction to 0",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(0);
         deepEqual(movingGameObject.direction, 0);
     });
test("When  direction is 0, change direction to 1",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(1);
         deepEqual(movingGameObject.direction, 1);
     });
test("When  direction is 0, change direction to 2 but this is not allowed",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(2);
         deepEqual(movingGameObject.direction, 0);
     });
test("When  direction is 0, change direction to 3",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 0;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(3);
         deepEqual(movingGameObject.direction, 3);
     });

test("When  direction is 1, change direction to 0",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 1;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(0);
         deepEqual(movingGameObject.direction, 0);
     });
test("When  direction is 1, change direction to 1",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 1;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(1);
         deepEqual(movingGameObject.direction, 1);
     });
test("When  direction is 1, change direction to 2",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 1;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(2);
         deepEqual(movingGameObject.direction, 2);
     });
test("When  direction is 1, change direction to 3 but this is not allowed",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 1;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(3);
         deepEqual(movingGameObject.direction, 1);
     });

test("When  direction is 2, change direction to 0 but this is not allowed",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 2;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(0);
         deepEqual(movingGameObject.direction, 2);
     });
test("When  direction is 2, change direction to 1",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 2;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(1);
         deepEqual(movingGameObject.direction, 1);
     });
test("When  direction is 2, change direction to 2",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 2;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(2);
         deepEqual(movingGameObject.direction, 2);
     });
test("When  direction is 2, change direction to 3",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 2;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(3);
         deepEqual(movingGameObject.direction, 3);
     });

test("When  direction is 3, change direction to 0",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(0);
         deepEqual(movingGameObject.direction, 0);
     });
test("When  direction is 3, change direction to 1 but this is not allowed",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(1);
         deepEqual(movingGameObject.direction, 3);
     });
test("When  direction is 3, change direction to 2",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(2);
         deepEqual(movingGameObject.direction, 2);
     });
test("When  direction is 3, change direction to 3",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(3);
         deepEqual(movingGameObject.direction, 3);
     });

test("When  direction is 3, change direction to 5 (invalid number)",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(5);
         deepEqual(movingGameObject.direction, 3);
     });
test("When  direction is 3, change direction to 6 (invalid number)",
     function () {
         var position = { x: 150, y: 150 }, size = 15, fillColor = '#00000', strokeColor = '#ffffff', speed = 5, dir = 3;
         var movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, dir);

         movingGameObject.changeDirection(6);
         deepEqual(movingGameObject.direction, 3);
     });