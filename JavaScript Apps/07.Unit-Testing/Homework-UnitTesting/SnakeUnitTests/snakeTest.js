module("Snake.init");

test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.changeDirection");
test("When  direction is 0, change direction to 0",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 0);

         snake.head.changeDirection(0);
         deepEqual(snake.head.direction, 0);
     });
test("When  direction is 0, change direction to 1",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 0);

         snake.head.changeDirection(1);
         deepEqual(snake.head.direction, 1);
     });
test("When  direction is 0, change direction to 2 but this is not allowed",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 0);

         snake.head.changeDirection(2);
         deepEqual(snake.head.direction, 0);
     });
test("When  direction is 0, change direction to 3",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 0);

         snake.head.changeDirection(3);
         deepEqual(snake.head.direction, 3);
     });

test("When  direction is 1, change direction to 0",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 1);

         snake.head.changeDirection(0);
         deepEqual(snake.head.direction, 0);
     });
test("When  direction is 1, change direction to 1",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 1);

         snake.head.changeDirection(1);
         deepEqual(snake.head.direction, 1);
     });
test("When  direction is 1, change direction to 2",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 1);

         snake.head.changeDirection(2);
         deepEqual(snake.head.direction, 2);
     });
test("When  direction is 1, change direction to 3 but this is not allowed",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 1);

         snake.head.changeDirection(3);
         deepEqual(snake.head.direction, 1);
     });

test("When  direction is 2, change direction to 0 but this is not allowed",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 2);

         snake.head.changeDirection(0);
         deepEqual(snake.head.direction, 2);
     });
test("When  direction is 2, change direction to 1",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 2);

         snake.head.changeDirection(1);
         deepEqual(snake.head.direction, 1);
     });
test("When  direction is 2, change direction to 2",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 2);

         snake.head.changeDirection(2);
         deepEqual(snake.head.direction, 2);
     });
test("When  direction is 2, change direction to 3",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 2);

         snake.head.changeDirection(3);
         deepEqual(snake.head.direction, 3);
     });

test("When  direction is 3, change direction to 0",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.head.changeDirection(0);
         deepEqual(snake.head.direction, 0);
     });
test("When  direction is 3, change direction to 1 but this is not allowed",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.head.changeDirection(1);
         deepEqual(snake.head.direction, 3);
     });
test("When  direction is 3, change direction to 2",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.head.changeDirection(2);
         deepEqual(snake.head.direction, 2);
     });
test("When  direction is 3, change direction to 3",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.head.changeDirection(3);
         deepEqual(snake.head.direction, 3);
     });

test("When  direction is 3, change direction to 5 (invalid number)",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.head.changeDirection(5);
         deepEqual(snake.head.direction, 3);
     });
test("When  direction is 3, change direction to 6 (invalid number)",
     function () {
         var snake = new snakeGame.Snake({
             x: 150,
             y: 150
         }, 15, 3);

         snake.changeDirection(6);
         deepEqual(snake.direction, 3);
     });

module("Snake.move");
test("When  direction is 0, decrease update x",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 1);

         snake.move();
         position.x - 15;
         deepEqual(snake.position, position);
     });
test("When direction is 1, decrease update y",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 1);

         snake.move();
         position.x - 15;
         deepEqual(snake.position, position);
     });
test("When direction is 2, increase x",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 2);

         snake.move();
         position.x + 15;
         deepEqual(snake.position, position);
     });
test("When direction is 3, should increase y",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 3);

         snake.move();
         position.y + 15;
         deepEqual(snake.position, position);
     });

module("Snake.grow");
test("When init new snake size is 5",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 3);

         deepEqual(snake.size, 5);
     });
test("When init new snake and call grow() size is 6",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 3);

         snake.grow();
         deepEqual(snake.size, 6);
     });
test("When init new snake and call grow() two times size is 7",
     function () {
         var position = { x: 150, y: 150 };
         var snake = new snakeGame.Snake(position, 15, 3);

         snake.grow();
         snake.grow();
         deepEqual(snake.size, 7);
     });

module("Snake.checkSelfEating");

test("The snake must die, when it bites itself", function () {
    var iniposition = {
        x: 1,
        y: 3
    }
    var snake = new snakeGame.Snake(iniposition, 8, 0);
    snake.pieces[4].position.x = iniposition.x;
    snake.pieces[4].position.y = iniposition.y;
    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.checkSelfEating();
    ok(isDead, "The snake is dead");
});