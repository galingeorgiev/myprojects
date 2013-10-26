/// <reference path="../Scripts/mustache.js" />
/// <reference path="../Scripts/require.js" />
define(['jquery', 'mustache'], function ($, mustache) {
    function drawLogInForm() {
        return '<fieldset id="login-user-container">' +
                    '<legend>Log In</legend>' +
                    '<label for="login-user-nickname">Nickname</label>' +
                    '<input id="login-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" autofocus="true" />' +
                    '<label for="login-user-password">Password</label>' +
                    '<input id="login-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                    '<button id="button-log-in">Log In</button>' +
                    '<a id="register-now" href="#">Register now</a>' +
                '</fieldset>';
    }

    function drawRegisterForm() {
        return '<fieldset id="register-user-container">' +
                    '<legend>Register</legend>' +
                    '<label for="register-user-name">Name</label>' +
                    '<input id="register-user-name" type="text" name="name" value="" placeholder="Enter your first and last name" autofocus="true" />' +
                    '<label for="register-user-nickname">Nickname</label>' +
                    '<input id="register-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" />' +
                    '<label for="register-user-password">Password</label>' +
                    '<input id="register-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                    '<label for="register-user-password-re">Password</label>' +
                    '<input id="register-user-password-re" type="password" name="name" value="" placeholder="Confirm your password" />' +
                    '<a id="back-to-homepage" href="#" >Back</a>' +
                    '<button id="button-register">Register</button>' +
                '</fieldset>';
    }

    function drawLoggedInForm() {
        return '<div id="user-loged-in">' +
                    '<p id="greetings">Hello, ' + localStorage.getItem('userNickname') + '</p>' +
                    '<p>Let\'s play ...</p>' +
                    '<button id="button-logout">Log out</button>' +
                    '<button id="button-create-new-game">Create new game</button>' +
                '</div>';
    }

    function drawUserInteraction() {
        return '<div id="error-messages"></div>' +
               '<div id="messages"></div>' +
               '<div id="game-state-container"></div>';
    }

    function showAppErrorMessage(message) {
        $('#error-messages').text(message);

        setTimeout(function () {
            $('#error-messages').text('');
        }, 15000);
    }

    function showErrorMessage(err) {
        $('#error-messages').text(err.responseJSON.Message);

        setTimeout(function () {
            $('#error-messages').text('');
        }, 15000);
    }

    function showMessage(message) {
        $('#messages').text(message);

        setTimeout(function () {
            $('#messages').text('');
        }, 15000);
    }

    function clearErrorMessage() {
        $('#error-messages').text('');
    }

    function showOrHideElements(elementID) {
        if ($(elementID + '-list').hasClass('show')) {
            $(elementID + '-list').hide(1500);
            $(elementID + '-list').removeClass('show');
        }
        else {
            $(elementID + '-list').show(1500);
            $(elementID + '-list').addClass('show');
        }

        return false;
    }

    function drawListOfGames(myActiveGames, container, conatinerTitle, type) {
        $(container)
            .append($('<h2 />').attr('id', 'games-' + type).text(conatinerTitle))
            .append($('<ul />').attr({ 'id': 'games-' + type + '-list', 'class': 'show' }));

        var elementsContainer = $(container + ' #' + 'games-' + type + '-list');

        for (var i = 0; i < myActiveGames.length; i++) {
            var currentLi = $('<li />').attr('data-game-id', myActiveGames[i].id)
                .append($('<a />').attr('href', '#').text(myActiveGames[i].title))
                .append($('<span />').text('by ' + myActiveGames[i].creator));

            if (type == 'open') {
                currentLi.append($('<button />').text('Join').addClass('button-join'));
            }

            if (myActiveGames[i].status === 'in-progress') {
                currentLi.append($('<button />').addClass('button-view-state').text('Game state'));
            }

            if (myActiveGames[i].status === 'full' && localStorage.getItem('userNickname') == myActiveGames[i].creator) {
                currentLi.append($('<button />').text('Start').addClass('button-start'));
            }
            else if (myActiveGames[i].status === 'full') {
                currentLi.append($('<p />').text('Waiting for ' + myActiveGames[i].creator + ' response.'));
            }

            if (myActiveGames[i].status === 'open' && localStorage.getItem('userNickname') != myActiveGames[i].creator) {
                currentLi.append($('<button />').text('Join').addClass('button-join'));
            }

            elementsContainer.append(currentLi);
        }
    }

    function drawListOfMessages(messages, container, conatinerTitle, type) {
        var messagesTemplate =
            '<h2 id=games-' + type + '>' + conatinerTitle + '</h2>' +
            '<ul id="games-' + type + '-list" class="show">' +
            '{{#.}}<li data-game-id="{{gameId}}"><a href="#">{{text}}</a><span>State: {{state}}</span></li>{{/.}}' +
            '</ul>';

        var messagesHtml = mustache.render(messagesTemplate, messages);
        $(container).html(messagesHtml);
    }

    function drawCreateGameMenu() {
        return '<div id="game-user-create">' +
                    '<label for="create-game-name">Game name </label>' +
                    '<input id="create-game-name" type="text" name="name" value="" placeholder="Enter game name" />' +
                    '<label for="create-game-password">Pasword </label>' +
                    '<input id="create-game-password" type="password" name="name" value="" placeholder="Enter game password" />' +
                    '<button id="confirm-create-game">OK</button>' +
                '</div>';
    }

    function drawJoinGameMenu() {
        return '<div id="game-user-join">' +
                    '<label for="join-game-number">Number </label>' +
                    '<input id="join-game-number" type="text" name="name" value="" placeholder="Enter your number" />' +
                    '<label for="join-game-password">Pasword </label>' +
                    '<input id="join-game-password" type="password" name="name" value="" placeholder="Enter game password" />' +
                    '<button id="confirm-join-game">OK</button>' +
                '</div>';
    }

    function drawSidebars(persister) {
        $('#left-side-bar').empty();
        $('#right-side-bar').empty();
        persister.game.myActive(function (data) {
            drawListOfGames(data, '#left-side-bar', 'My active games', 'active');
        });

        persister.game.open(function (data) {
            drawListOfGames(data, '#left-side-bar', 'Open games', 'open');
        });

        persister.messages.all(function (data) {
            drawListOfMessages(data, '#right-side-bar', 'Messages', 'messages');
        });
    }

    function drawCurrentGameState(currentState) {
        var inTurn;

        if (currentState.inTurn == 'blue') {
            inTurn = 'In turn is: ' + currentState.blue.nickname;
        }
        else if (currentState.inTurn == 'red') {
            inTurn = 'In turn is: ' + currentState.red.nickname;
        }

        $('#game-state-container table').attr('data-game-id', currentState.gameId);

        var gameInfoTemplate =
            '<p id="game-name">{{red.nickname}} vs. {{blue.nickname}}</p>' +
            '<p id="game-state-text">' + inTurn + '</p>' +
            '<p id="game-name">' + 'Game name: {{title}}</p>' +
            '<p id="game-state-turn">Turn: {{turn}}</p>';

        var gameInfoHtml = mustache.render(gameInfoTemplate, currentState);
        $('#game-state-container').append(gameInfoHtml);

        var i = 0;

        for (i = 0; i < currentState.red.units.length; i++) {
            var redPosX = currentState.red.units[i].position.x;
            var redPosY = currentState.red.units[i].position.y;
            var redUnitType = currentState.red.units[i].type;
            var redUnitID = currentState.red.units[i].id;

            if (redUnitType == 'warrior') {
                $('#game-state-container table tr td[data-pos-x=' + redPosX + '][data-pos-y=' + redPosY + ']')
                    .addClass('red')
                    .attr('data-unit-id', redUnitID).text('W');
            }
            else if (redUnitType == 'ranger') {
                $('#game-state-container table tr td[data-pos-x=' + redPosX + '][data-pos-y=' + redPosY + ']')
                    .addClass('red')
                    .attr('data-unit-id', redUnitID).text('R');
            }

        }

        for (i = 0; i < currentState.blue.units.length; i++) {
            var bluePosX = currentState.blue.units[i].position.x;
            var bluePosY = currentState.blue.units[i].position.y;
            var blueUnitType = currentState.blue.units[i].type;
            var blueUnitID = currentState.blue.units[i].id;

            if (blueUnitType == 'warrior') {
                $('#game-state-container table tr td[data-pos-x=' + bluePosX + '][data-pos-y=' + bluePosY + ']')
                    .addClass('blue')
                    .attr('data-unit-id', blueUnitID).text('W');
            }
            else if (blueUnitType == 'ranger') {
                $('#game-state-container table tr td[data-pos-x=' + bluePosX + '][data-pos-y=' + bluePosY + ']')
                    .addClass('blue')
                    .attr('data-unit-id', blueUnitID).text('R');
            }
        }
    }

    return {
        drawLogIn: drawLogInForm,
        drawRegister: drawRegisterForm,
        drawLoggedIn: drawLoggedInForm,
        drawUserInteraction: drawUserInteraction,
        showAppErrorMessage: showAppErrorMessage,
        showErrorMessage: showErrorMessage,
        showMessage: showMessage,
        clearErrorMessage: clearErrorMessage,
        drawListOfGames: drawListOfGames,
        drawListOfMessages: drawListOfMessages,
        drawCreateGameMenu: drawCreateGameMenu,
        drawJoinGameMenu: drawJoinGameMenu,
        drawSidebars: drawSidebars,
        drawCurrentGameState: drawCurrentGameState,
        showOrHideElements: showOrHideElements
    };
});