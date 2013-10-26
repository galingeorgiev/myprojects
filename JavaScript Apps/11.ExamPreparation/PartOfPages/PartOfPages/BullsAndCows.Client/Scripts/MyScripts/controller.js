/// <reference path="validation-controler.js" />
/// <reference path="Class.js" />
/// <reference path="../jquery-2.0.2.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

$(document).ready(function () {
    var myMainPersister = persister.mainPersister('http://localhost:40643/api');
    //var myMainPersister = persister.mainPersister('http://bullsandcows.apphb.com/api');
    //ui.addEvents(myMainPersister);
    //myMainPersister.user.logout();
    //myMainPersister.user.login('lidia', '12345');
    var sesionKey = localStorage.getItem('authCode');
    
    // Check is user logged in
    if (localStorage.getItem('authCode') == '' || localStorage.getItem('authCode') == null || localStorage.getItem('authCode') == undefined) {
        $('#login-container').html(ui.drawLogIn());
    }
    else {
        $('#login-container').html(ui.drawLoggedIn());
        $('#make-guess').html(ui.drawUserInteraction());
    }

    var int = self.setInterval(function () {
        if (localStorage.getItem('authCode') != '') {
        }
        else {
            window.clearInterval(int);
        }
    }, 5000);

    var eventControler = (function () {
        function addElementsEvents(persister) {
            // Logout
            $('#wrapper').on('click', '#user-loged-in #button-logout', function () {
                $('#login-container').empty();
                $('#left-side-bar').empty();
                $('#right-side-bar').empty();
                $('#make-guess').empty();
                $('#make-guess').append($('<div />').attr('id', 'error-messages'));
                $('#make-guess').append($('<div />').attr('id', 'messages'));
                $('#login-container').html(ui.drawLogIn());

                persister.user.logout();
            });

            // Log in
            $('#wrapper').on('click', '#button-log-in', function () {
                var username = $('#login-user-nickname').val();
                var password = $('#login-user-password').val();

                var isUsernameValid = validationControler.isUsernameCorrect(username);
                var isPasswordValid = validationControler.isPasswordCorrect(password);

                if (isUsernameValid && isPasswordValid) {
                    ui.clearErrorMessage();
                    persister.user.login(username, password, ui.showErrorMessage);

                    if (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined) {
                        ui.clearErrorMessage();

                        $('#login-container').html(ui.drawLoggedIn());
                        $('#make-guess').html(ui.drawUserInteraction());
                    }
                }
                else {
                    ui.showAppErrorMessage('Invalid username or password! Check you account information and try again.');
                }
            });

            // Register now
            $('#wrapper').on('click', '#register-now', function () {
                $('#login-container').html(ui.drawRegister());
            });

            // Register back
            $('#wrapper').on('click', '#back-to-homepage', function () {
                $('#login-container').html(ui.drawLogIn());
            });

            // Send register request
            $('#wrapper').on('click', '#button-register', function () {
                var username = $('#register-user-nickname').val();
                var nickname = $('#register-user-nickname').val();
                var password = $('#register-user-password').val();
                var passwordRe = $('#register-user-password-re').val();

                var isUsernameValid = validationControler.isUsernameCorrect(username);
                var isPasswordValid = validationControler.isPasswordCorrect(password);
                var isPasswordsEqual = password === passwordRe;

                if (isUsernameValid && isPasswordValid && isPasswordsEqual) {
                    persister.user.register(username, nickname, password, ui.showErrorMessage);

                    if (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined) {
                        $('#login-container').html(ui.drawLoggedIn());
                        ui.clearErrorMessage();
                    }
                }
                else {
                    ui.showAppErrorMessage('Invalid username or password! Check you account information and try again.');
                }
            });
        }

        return {
            addEvents: addElementsEvents
        }
    }());

    eventControler.addEvents(myMainPersister);
});