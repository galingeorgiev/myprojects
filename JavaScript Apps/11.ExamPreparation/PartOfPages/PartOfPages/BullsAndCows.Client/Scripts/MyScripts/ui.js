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
               '<label for="player-guess-text">Enter guess number: </label>' +
               '<input id="player-guess-text" type="text" name="name" value="" />' +
               '<div id="game-state-container"></div>';
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
        drawUserInteraction: drawUserInteraction,
        showAppErrorMessage: showAppErrorMessage,
        showErrorMessage: showErrorMessage,
        showMessage: showMessage,
        clearErrorMessage: clearErrorMessage
    };
}());