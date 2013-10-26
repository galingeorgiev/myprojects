function drawCanvas() {
    // Draw bicycle
    var canvas = document.getElementById("bicycle");
    var ctx = canvas.getContext("2d");

    ctx.fillStyle = "#90cad7";
    ctx.strokeStyle = "#4f95a6";
    ctx.lineWidth = 3;
    ctx.beginPath();

    // Draw beck circle
    ctx.arc(58, 156, 55, 0, 2 * Math.PI, false);
    ctx.fill();

    // Draw frame
    ctx.moveTo(58, 156);
    ctx.lineTo(127, 83);
    ctx.lineTo(272, 83);
    ctx.lineTo(163, 153);
    ctx.lineTo(58, 156);
    ctx.stroke();

    // Draw pedals
    ctx.beginPath();
    ctx.arc(163, 153, 15, 0, 2 * Math.PI, false);
    ctx.moveTo(171, 165);
    ctx.lineTo(182, 178);
    ctx.moveTo(151, 142);
    ctx.lineTo(140, 128);
    ctx.stroke();

    // Draw seat
    ctx.beginPath();
    ctx.moveTo(163, 153);
    ctx.lineTo(113, 54);
    ctx.moveTo(87, 54);
    ctx.lineTo(136, 54);
    ctx.stroke();

    // Draw front circle
    ctx.beginPath();
    ctx.arc(285, 153, 55, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();

    // Draw stern
    ctx.beginPath();
    ctx.moveTo(285, 153);
    ctx.lineTo(266, 39);
    ctx.lineTo(219, 54);
    ctx.moveTo(266, 39);
    ctx.lineTo(297, 1);
    ctx.stroke();

    // Draw house
    canvas = document.getElementById("house");
    ctx = canvas.getContext("2d");

    ctx.strokeStyle = '#000';
    ctx.fillStyle = '#975b5b';
    ctx.lineWidth = 3;

    // Draw roof
    ctx.beginPath();
    ctx.moveTo(145, 1);
    ctx.lineTo(290, 161);
    ctx.lineTo(1, 161);
    ctx.lineTo(145, 1);
    ctx.fill();
    ctx.stroke();

    // Draw house body
    ctx.fillRect(1, 161, 289, 215);
    ctx.strokeRect(1, 161, 289, 215);
    
    // Draw windows
    ctx.fillStyle = '#000';
    ctx.fillRect(22, 188, 100, 70);
    ctx.fillRect(162, 188, 100, 70);
    ctx.fillRect(162, 279, 100, 70);
    ctx.beginPath();
    ctx.strokeStyle = '#975b5b';
    // Window 1
    ctx.moveTo(22, 221);
    ctx.lineTo(122, 221);
    ctx.moveTo(74, 188);
    ctx.lineTo(74, 258);
    // Window 2
    ctx.moveTo(162, 221);
    ctx.lineTo(265, 221);
    ctx.moveTo(213, 188);
    ctx.lineTo(213, 258);
    // Window 3
    ctx.moveTo(162, 313);
    ctx.lineTo(262, 313);
    ctx.moveTo(213, 279);
    ctx.lineTo(213, 349);
    ctx.stroke();

    ctx.strokeStyle = '#000';
    ctx.fillStyle = '#975b5b';

    // draw chimney
    ctx.beginPath();
    ctx.moveTo(202, 43);
    ctx.lineTo(202, 121);
    ctx.moveTo(234, 121);
    ctx.lineTo(234, 43);
    ctx.lineTo(202, 43);
    ctx.stroke();
    ctx.fillRect(203, 44, 30, 81);
    ctx.save();
    ctx.scale(1, 0.5);
    ctx.beginPath();
    ctx.arc(218, 83, 16, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    // Draw door
    ctx.beginPath();
    ctx.moveTo(33, 377);
    ctx.lineTo(33, 303);
    ctx.moveTo(73, 377);
    ctx.lineTo(73, 282);
    ctx.moveTo(113, 377);
    ctx.lineTo(113, 303);
    ctx.stroke();
    ctx.save();
    ctx.scale(1, 0.5);
    ctx.beginPath();
    ctx.arc(73, 606, 40, 0, Math.PI, true);
    ctx.stroke();
    ctx.restore();
    ctx.beginPath();
    ctx.arc(62, 348, 5, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.beginPath();
    ctx.arc(85, 348, 5, 0, 2 * Math.PI, false);
    ctx.stroke();

    // Draw face
    canvas = document.getElementById("face");
    ctx = canvas.getContext("2d");

    ctx.fillStyle = "#90cad7";
    ctx.strokeStyle = "#22545f";
    ctx.lineWidth = 3;

    // Draw main face
    ctx.save();
    ctx.scale(1, 0.8);
    ctx.beginPath();
    ctx.arc(85, 200, 70, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    // Draw nose
    ctx.beginPath();
    ctx.moveTo(70, 171);
    ctx.lineTo(54, 171);
    ctx.lineTo(70, 140);
    ctx.stroke();

    // Draw eyes
    // Left
    ctx.save();
    ctx.scale(1, 0.8);
    ctx.beginPath();
    ctx.arc(42, 175, 10, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.restore();

    ctx.save();
    ctx.scale(0.5, 1);
    ctx.fillStyle = "#22545f";
    ctx.beginPath();
    ctx.arc(75, 140, 4, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    // Right
    ctx.save();
    ctx.scale(1, 0.8);
    ctx.beginPath();
    ctx.arc(100, 175, 10, 0, 2 * Math.PI, false);
    ctx.stroke();
    ctx.restore();

    ctx.save();
    ctx.scale(0.5, 1);
    ctx.fillStyle = "#22545f";
    ctx.beginPath();
    ctx.arc(190, 140, 4, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    // Draw lips
    ctx.save();
    ctx.scale(1, 0.5);
    ctx.beginPath();
    ctx.arc(70, 390, 25, 0, 2 * Math.PI, false);
    //ctx.moveTo(70, 390);
    //ctx.rotate(2 * Math.PI / 3);
    ctx.stroke();
    ctx.restore();

    // Draw had
    ctx.fillStyle = "#396693";
    ctx.strokeStyle = '#000';
    ctx.save();
    ctx.scale(1, 0.3);
    ctx.beginPath();
    ctx.arc(80, 350, 75, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    ctx.save();
    ctx.scale(1, 0.3);
    ctx.beginPath();
    ctx.arc(85, 315, 40, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    ctx.fillRect(44, 15, 82, 80);

    ctx.save();
    ctx.scale(1, 0.3);
    ctx.beginPath();
    ctx.arc(85, 60, 40, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
    ctx.restore();

    ctx.beginPath();
    ctx.moveTo(45, 95);
    ctx.lineTo(45, 17);
    ctx.moveTo(125, 95);
    ctx.lineTo(125, 17);
    ctx.stroke();
} 