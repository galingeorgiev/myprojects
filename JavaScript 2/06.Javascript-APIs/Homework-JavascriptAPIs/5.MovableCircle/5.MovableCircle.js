function movableCircle() {
    var x = 30 | 0;
    var y = 30 | 0;
    var dx = 10 | 0;
    var dy = 10 | 0;
    var radius = 5;

    setInterval(move, 20);

    function move() {
        var canvas = document.getElementById("mainCanvas");
        var ctx = canvas.getContext("2d");
        var width = canvas.width;
        var height = canvas.height;

        ctx.clearRect(0, 0, canvas.width, canvas.height);

        if (x >= width || x < 0) {
            dx = -dx;
        }
        if (y >= height || y < 0) {
            dy = -dy;
        }

        ctx.fillStyle = "#90cad7";
        ctx.strokeStyle = "#4f95a6";

        ctx.beginPath();
        ctx.arc(x, y, radius, 0, 2 * Math.PI, false);
        ctx.fill();
        ctx.stroke();

        x = x + dx;
        y = y + dy;
    }
}