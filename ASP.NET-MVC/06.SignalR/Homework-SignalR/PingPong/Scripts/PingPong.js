/// <reference path="jquery.signalR-1.1.3.js" />

var pingpong = $.connection.pingPong;
$.connection.hub.start();

function rect(x, y, w, h) {
    return {
        x: x,
        y: y,
        width: w,
        height: h
    };
}

var canvas = document.getElementById("drawing-area"),
        context = canvas.getContext("2d");
var paddle = rect(10, canvas.height / 2 - 35, 10, 70);
var paddleSecondPlayer = rect(canvas.width - 20, canvas.height / 2 - 35, 10, 70);
var ball = rect(canvas.width / 2, canvas.height / 2, 15, 15);
ball.dx = 4;
ball.dy = 4;

var keys = { w: 87, s: 83, up: 38, down: 40 }, keyboard = [];

var requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame ||
                  window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;
var scoreLeft = 0, scoreRight = 0, playing = false;
var timeout;

window.onkeydown = function (ev) {
    keyboard[ev.which] = true;
};

window.onkeyup = function (ev) {
    keyboard[ev.which] = false;
};

function render() {
    context.fillStyle = "black";
    context.fillRect(0, 0, canvas.width, canvas.height);

    context.fillStyle = "white";
    context.fillRect(paddle.x, paddle.y, paddle.width, paddle.height);
    context.fillRect(paddleSecondPlayer.x, paddleSecondPlayer.y, paddleSecondPlayer.width, paddleSecondPlayer.height);

    context.fillRect(ball.x, ball.y, ball.width, ball.height);

    context.font = "72px MSComicSans";
    context.fillText(scoreLeft, canvas.width / 4, 60);
    context.fillText(scoreRight, (3 * canvas.width )/ 4, 60);

    requestAnimationFrame(render);
}

function update() {
    if (!playing) {
        return;
    }

    if (keyboard[keys.w] && paddle.y - 6 >= 0) {
        paddle.y -= 6;
    }
    else if (keyboard[keys.s] && paddle.y + paddle.height + 6 <= canvas.height) {
        paddle.y += 6;
    }
    else if (keyboard[keys.up] && paddleSecondPlayer.y - 6 >= 0) {
        paddleSecondPlayer.y -= 6;
    }
    else if (keyboard[keys.down] && paddleSecondPlayer.y + paddleSecondPlayer.height + 6 <= canvas.height) {
        paddleSecondPlayer.y += 6;
    }

    //win conditions
    if (ball.x + 5 < paddle.x + paddle.width) {
        playing = false;
        setTimeout(pingpong.server.reset, 1000);
        scoreRight++;
        return;
    } else if (ball.x - 5 > paddleSecondPlayer.x - paddleSecondPlayer.width) {
        playing = false;
        setTimeout(pingpong.server.reset, 1000);
        scoreLeft++;
        return;
    }

    pingpong.server.update(ball.x, ball.y, paddle.x, paddle.y, paddleSecondPlayer.x, paddleSecondPlayer.y, ball.dx, ball.dy, scoreLeft, scoreRight);
    timeout = setTimeout(update, 30);
}

function reset() {
    playing = true;

    ball.x = canvas.width / 2;
    ball.y = canvas.height / 2;

    clearTimeout(timeout);
    update();
    requestAnimationFrame(render);
}

pingpong.client.updateBoard = function (bx, by, px, py, psx, psy, dx, dy, scoreLeft, scoreRight) {
    ball.x = bx;
    ball.y = by;
    paddle.x = px;
    paddle.y = py;
    paddleSecondPlayer.x = psx;
    paddleSecondPlayer.y = psy;
    ball.dx = dx;
    ball.dy = dy;
    scoreLeft = scoreLeft;
    scoreRight = scoreRight;
}

pingpong.client.resetBoard = reset;

$('#start-game').click(function (e) {
    e.preventDefault();
    e.stopPropagation();
    $.connection.hub.start().done(function () {
        pingpong.server.startGame();
    })
    return false;
});

pingpong.client.startGame = function () {
    render();
    update();
    reset();
}