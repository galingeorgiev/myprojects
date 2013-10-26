/// <reference path="../jquery-2.0.2.js" />
/// <reference path="persister.js" />

var ui = (function () {
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
               '<label for="player-guess-text">Enter guess number: </label>' +
               '<input id="player-guess-text" type="text" name="name" value="" />' +
               '<div id="game-state-container"></div>';
    }

    function drawListOfGames(myActiveGames, container, conatinerTitle, type) {
        $(container)
            .append($('<h2 />').attr('id', 'games-' + type).text(conatinerTitle))
            .append($('<ul />').attr({ 'id': 'games-' + type + '-list', 'class': 'show' }));

        var elementsContainer = $(container + ' #' + 'games-' + type + '-list');

        for (var i = 0; i < myActiveGames.length; i++) {
            var currentLi = $('<li />').attr('data-game-id', myActiveGames[i].id)
                .append($('<a />').attr('href', '#').text(myActiveGames[i].title))
                .append($('<span />').text('by ' + myActiveGames[i].creatorNickname));
            //.append($('<button />').addClass('button-view-state').text('Game state'));

            if (myActiveGames[i].status === 'in progress') {
                currentLi.append($('<button />').addClass('button-view-state').text('Game state'));
                currentLi.append($('<button />').text('Guess').addClass('button-guess'));
            }

            if (myActiveGames[i].status === 'full' && localStorage.getItem('userNickname') == myActiveGames[i].creatorNickname) {
                currentLi.append($('<button />').text('Start').addClass('button-start'));
            }
            else if (myActiveGames[i].status === 'full') {
                currentLi.append($('<p />').text('Waiting for ' + myActiveGames[i].creatorNickname + ' response.'));
            }

            if (myActiveGames[i].status === 'open') {
                currentLi.append($('<button />').text('Join').addClass('button-join'));
            }

            elementsContainer.append(currentLi);
        }
    }

    function drawListOfMessages(messages, container, conatinerTitle, type) {
        $(container)
            .append($('<h2 />').attr('id', 'games-' + type).text(conatinerTitle))
            .append($('<ul />').attr({ 'id': 'games-' + type + '-list', 'class': 'show' }));

        var elementsContainer = $(container + ' #' + 'games-' + type + '-list');

        for (var i = 0; i < messages.length; i++) {
            elementsContainer
                .append($('<li />').attr('data-game-id', messages[i].gameId).append($('<a />').attr('href', '#').text(messages[i].text))
                .append($('<span />').text('state ' + messages[i].state)));
        }
    }

    function drawCreateGameMenu() {
        return '<div id="game-user-create">' +
                    '<label for="create-game-name">Game name </label>' +
                    '<input id="create-game-name" type="text" name="name" value="" placeholder="Enter game name" />' +
                    '<label for="create-game-number">Number </label>' +
                    '<input id="create-game-number" type="text" name="name" value="" placeholder="Enter your number" />' +
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

    function drawCurrentGameState(currentState) {
        $('#game-state-container').empty();

        var inTurn;
        var blueUser = currentState.blue;
        var redUser = currentState.red;

        if (currentState.inTurn == 'blue') {
            inTurn = 'In turn is: ' + blueUser;
        }
        else if (currentState.inTurn == 'red') {
            inTurn = 'In turn is: ' + redUser;
        }

        $('#game-state-container')
            .append($('<p />').attr('id', 'game-state-text').text(inTurn))
            .append($('<p />').attr('id', 'game-name').text('Game name: ' + currentState.title))
            .append($('<table />')
            .append($('<thead />')
            .append($('<tr />')
            .append($('<th />').text(blueUser))
            .append($('<th />').text('Bulls'))
            .append($('<th />').text('Cows'))
            .append($('<th />').text(redUser))
            .append($('<th />').text('Bulls'))
            .append($('<th />').text('Cows')))));

        var container = $('#game-state-container table');

        if (currentState.blueGuesses[currentState.blueGuesses.length - 1].bulls == 4) {
            $('#game-state-container').append($('<div />').attr('id', 'win-game-container').text('Congratulations, YOU WIN'));
        }

        if (currentState.redGuesses[currentState.redGuesses.length - 1].bulls == 4) {
            $('#game-state-container').append($('<div />').attr('id', 'win-game-container').text('Congratulations, YOU WIN'));
        }

        var minTurns = Math.min(currentState.blueGuesses.length, currentState.redGuesses.length);

        for (var i = 0; i < minTurns; i++) {
            container.append($('<tr />').append($('<td />').text(currentState.blueGuesses[i].number))
                .append($('<td />').text(currentState.blueGuesses[i].bulls))
                .append($('<td />').text(currentState.blueGuesses[i].cows))
                .append($('<td />').text(currentState.redGuesses[i].number))
                .append($('<td />').text(currentState.redGuesses[i].bulls))
                .append($('<td />').text(currentState.redGuesses[i].cows)));

            //container.append($('<li />')
            //.append($('<span />').addClass('blue-guesses').text(currentState.blueGuesses[i].number + ' ' + currentState.blueGuesses[i].bulls + ' ' + currentState.blueGuesses[i].cows))
            //.append($('<span />').addClass('red-guesses').text(currentState.redGuesses[i].number + ' ' + currentState.blueGuesses[i].bulls + ' ' + currentState.redGuesses[i].cows)));
        }

        if (currentState.redGuesses.length > currentState.blueGuesses.length) {
            container.append($('<tr />').append($('<td />').text('empty'))
                .append($('<td />').text('empty'))
                .append($('<td />').text('empty'))
                .append($('<td />').text(currentState.redGuesses[currentState.redGuesses.length - 1].number))
                .append($('<td />').text(currentState.redGuesses[currentState.redGuesses.length - 1].bulls))
                .append($('<td />').text(currentState.redGuesses[currentState.redGuesses.length - 1].cows)));
        }
        else if (currentState.redGuesses.length < currentState.blueGuesses.length) {
            container.append($('<tr />').append($('<td />').text(currentState.blueGuesses[currentState.blueGuesses.length - 1].number))
                .append($('<td />').text(currentState.blueGuesses[currentState.blueGuesses.length - 1].bulls))
                .append($('<td />').text(currentState.blueGuesses[currentState.blueGuesses.length - 1].cows))
                .append($('<td />').text('empty'))
                .append($('<td />').text('empty'))
                .append($('<td />').text('empty')));
        }
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

    function showAppErrorMessage(message) {
        $('#error-messages').text(message);

        setTimeout(function () {
            $('#error-messages').text('');
        }, 30000);
    }

    function showErrorMessage(err) {
        $('#error-messages').text(err.responseJSON.errCode + ': ' + err.responseJSON.Message);

        setTimeout(function () {
            $('#error-messages').text('');
        }, 30000);
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

    function isUsernameCorrect(username) {
        var isCorrect = true;

        if (username.length < 4 || username.length > 30) {
            isCorrect = false;
        }

        return isCorrect;
    }

    function isPasswordCorrect(password) {
        var isCorrect = true;

        if (password.length < 4 || password.length > 30) {
            isCorrect = false;
        }

        return isCorrect;
    }

    function isGuessNumberCorrect(guessNumber) {
        var isCorrect = true;
        var validNumbers = [true, true, true, true, true, true, true, true, true, true]
        if (guessNumber.length == 4) {
            for (var i = 0; i < 4; i++) {
                var currentDigit = parseInt(guessNumber[i]);
                if (!validNumbers[currentDigit] || currentDigit == 0) {
                    isCorrect = false;
                    break;
                }
                else {
                    validNumbers[currentDigit] = false;
                }
            }
        }
        else {
            isCorrect = false;
        }

        return isCorrect;
    }

    function logIn(persister) {
        var username = $('#login-user-nickname').val();
        var password = $('#login-user-password').val();

        var isUsernameValid = isUsernameCorrect(username);
        var isPasswordValid = isPasswordCorrect(password);

        if (isUsernameValid && isPasswordValid) {
            clearErrorMessage();
            persister.user.login(username, password, showErrorMessage);

            if (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined) {
                clearErrorMessage();

                persister.game.myActive(function (data) {
                    $('#left-side-bar').empty();
                    drawListOfGames(data, '#left-side-bar', 'My active games', 'active');
                });

                persister.game.open(function (data) {
                    drawListOfGames(data, '#left-side-bar', 'Open games', 'open');
                });

                persister.messages.all(function (data) {
                    $('#right-side-bar').empty();
                    drawListOfMessages(data, '#right-side-bar', 'Messages', 'messages');
                });

                $('#login-container').html(drawLoggedInForm());
                $('#make-guess').html(drawUserInteraction());
            }
        }
        else {
            showAppErrorMessage('Invalid username or password! Check you account information and try again.');
        }
    }

    function addElementsEvents(persister) {
        // Logout
        $('#wrapper').on('click', '#user-loged-in #button-logout', function () {
            $('#login-container').empty();
            $('#left-side-bar').empty();
            $('#right-side-bar').empty();
            $('#make-guess').empty();
            $('#make-guess').append($('<div />').attr('id', 'error-messages'));
            $('#make-guess').append($('<div />').attr('id', 'messages'));
            $('#login-container').html(drawLogInForm());

            persister.user.logout();
        });

        // Create new game
        $('#wrapper').on('click', '#user-loged-in #button-create-new-game', function () {
            $('#user-loged-in').html(drawCreateGameMenu());
        });

        // Create new game confirm
        $('#wrapper').on('click', '#confirm-create-game', function () {
            var gameName = $('#create-game-name').val();
            var gameNumber = $('#create-game-number').val();
            var gamePassword = $('#create-game-password').val();
            $('#game-user-create').remove();
            $('#login-container').html(ui.drawLoggedIn());

            var isNumberValid = isGuessNumberCorrect(gameNumber);

            if (isNumberValid) {
                clearErrorMessage();
                showMessage('Game created');
                persister.game.create(gameName, gameNumber, gamePassword, clearErrorMessage, showErrorMessage);
            }
            else {
                showAppErrorMessage('Your guess number is invalid. Please enter four diffrent digits.');
            }


        });

        // Log in
        $('#wrapper').on('click', '#button-log-in', function () {
            logIn(persister);
        });

        // Register now
        $('#wrapper').on('click', '#register-now', function () {
            $('#login-container').html(drawRegisterForm());
        });

        // Send register request
        $('#wrapper').on('click', '#button-register', function () {
            var username = $('#register-user-nickname').val();
            var nickname = $('#register-user-nickname').val();
            var password = $('#register-user-password').val();
            var passwordRe = $('#register-user-password-re').val();

            var isUsernameValid = isUsernameCorrect(username);
            var isPasswordValid = isPasswordCorrect(password);
            var isPasswordsEqual = password === passwordRe;

            if (isUsernameValid && isPasswordValid && isPasswordsEqual) {
                persister.user.register(username, nickname, password, showErrorMessage);

                //persister.game.myActive(function (data) {
                //    drawListOfGames(data, '#left-side-bar', 'My active games');
                //});
                if (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined) {
                    $('#login-container').html(drawLoggedInForm());
                    clearErrorMessage();
                }
            }
            else {
                showAppErrorMessage('Invalid username or password! Check you account information and try again.');
            }
        });

        // Show or hide list of my games
        $('#wrapper').on('click', '#games-active', function () {
            showOrHideElements('#games-active');
        });

        $('#wrapper').on('click', '#games-open', function () {
            showOrHideElements('#games-open');
        });

        $('#wrapper').on('click', '#games-messages', function () {
            showOrHideElements('#games-messages');
        });

        // Draw menu to join in game
        $('#wrapper').on('click', '#games-open-list li a', function () {
            $('#user-loged-in').html(drawJoinGameMenu());
        });

        // Join in game
        $('#wrapper').on('click', '.button-join', function () {
            $('#user-loged-in').html(drawJoinGameMenu());
        });

        // Confirm join in game
        $('#wrapper').on('click', '#confirm-join-game', function () {
            var gameID = $('#games-open-list li').attr('data-game-id');
            var gameNumber = $('#join-game-number').val();
            var gamePassword = $('#join-game-password').val();

            persister.game.join(gameID, gameNumber, gamePassword, clearErrorMessage, showErrorMessage);
            $('#login-container').html(drawLoggedInForm());
        });

        //// Draw my active games
        //$('#wrapper').on('click', '#my-active-games li', function () {
        //    var gameID = $('#games-active-list li').attr('data-game-id');

        //    $('#wrapper').on('click', '#button-player-guess', function () {
        //        var gameNumber = $('#player-guess-text').val();

        //        persister.guess.make(gameNumber, gameID, clearErrorMessage, showErrorMessage);
        //    });
        //});

        // Make guess new version
        $('#wrapper').on('click', '.button-guess', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            var gameNumber = $('#player-guess-text').val();

            isNumberValid = isGuessNumberCorrect(gameNumber);
            if (isNumberValid) {
                clearErrorMessage();
                $('#player-guess-text').val('');
                persister.guess.make(gameNumber, gameID, clearErrorMessage, showErrorMessage);

                persister.game.state(gameID, function (data) {
                    clearErrorMessage();
                    $('#game-state-container').empty();
                    $('#game-state-container').html(drawCurrentGameState(data));
                }, showErrorMessage);
            }
            else {
                showAppErrorMessage('Your guess number is invalid. Please enter four diffrent digits.');
            }
        });

        // Start game new version
        $('#wrapper').on('click', '.button-start', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            //var gameNumber = $('#player-guess-text').val();
            //drawSidebars(persister);
            persister.game.start(gameID, clearErrorMessage, showErrorMessage);
        });

        // View current game state
        $('#wrapper').on('click', '.button-view-state', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            //var gameNumber = $('#player-guess-text').val();
            persister.game.state(gameID, function (data) {
                clearErrorMessage();
                $('#game-state-container').empty();
                $('#game-state-container').html(drawCurrentGameState(data));
            }, showErrorMessage);
        });

        // Bind keybord events
        $('#wrapper').bind('keypress', '#login-user-password', function (e) {
            if (e.keyCode == 13) {
                logIn(persister);
            }
        });
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

    return {
        drawLogIn: drawLogInForm,
        drawRegister: drawRegisterForm,
        drawLoggedIn: drawLoggedInForm,
        drawListOfGames: drawListOfGames,
        addEvents: addElementsEvents,
        drawSidebars: drawSidebars,
        drawUserInteraction: drawUserInteraction
    };
}());