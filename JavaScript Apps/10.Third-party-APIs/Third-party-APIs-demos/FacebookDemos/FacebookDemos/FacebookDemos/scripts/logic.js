var player = 0;
var tableArray = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
var player1Symbol = "X";
var player2Symbol = "O";

function checkStatus(table) {
    if (checkHorizontals(player1Symbol) || checkVerticals(player1Symbol) ||
        checkDiagonals(player1Symbol)) {
        postToFeed();
    }
    if (checkHorizontals(player2Symbol) || checkVerticals(player2Symbol) ||
        checkDiagonals(player2Symbol)) {
        postToFeed();
    }
}

function checkHorizontals(symbol) {
    for (var col = 0; col < tableArray[0].length; col++) {
        var check = true;
        for (var row = 0; row < tableArray.length; row++) {
            if (tableArray[row][col] != symbol) {
                check = false;
                break;
            }
        }
        if (check) {
            return true;
        }
    }
    return false;
}

function checkDiagonals(symbol) {
    var check = true;
    for (var index = 0; index < tableArray[0].length; index++) {
        if (tableArray[index][index] != symbol) {
            check = false;
            break;
        }
    }

    if (check) {
        return true;
    }
    check = true;
    for (var secondIndex = 0; secondIndex < tableArray.length; secondIndex++) {
        if (tableArray[secondIndex][tableArray.length - secondIndex - 1] != symbol) {
            check = false;
            break;
        }
    }

    if (check) {
        return true;
    }

    return false;
}

function checkVerticals(symbol) {
    for (var row = 0; row < tableArray.length; row++) {
        var check = true;
        for (var col = 0; col < tableArray[row].length; col++) {
            if (tableArray[row][col] != symbol) {
                check = false;
                break;
            }
        }
        if (check) {
            return true;
        }
    }
    return false;
}

function fillCell(selector, symbol) {
    var row = $('tr').index(selector.parentNode);
    var col = ($('td').index(selector)) - (row * 3);
    tableArray[row][col] = symbol;
}

$("td").click(function () {
    if (player % 2 == 0) {
        if (this.innerHTML != player2Symbol) {
            this.innerHTML = player1Symbol;
            fillCell(this, player1Symbol);
        }
    }
    else {
        if (this.innerHTML != player1Symbol) {
            this.innerHTML = player2Symbol;
            fillCell(this, player2Symbol);
        }
    }
    player++;
    checkStatus(); //tr -> tbody -> table
}
);