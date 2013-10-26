/// <reference path="validation-controler.js" />
/// <reference path="Class.js" />
/// <reference path="../jquery-2.0.2.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

$(document).ready(function () {
    var myMainPersister = persister.mainPersister('http://localhost:49657/api');//47655

    // Check is user logged in
    if (localStorage.getItem('authCode') == '' || localStorage.getItem('authCode') == null || localStorage.getItem('authCode') == undefined) {
        $('#login-container').html(ui.drawLogIn());
    }
    else {
        $('#login-container').html(ui.drawLoggedIn());
        $('#main-game-container').html(ui.drawUserInteraction());
        $('#left-side-bar').html(ui.drawSidebars(myMainPersister));
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
                $('#main-game-container').empty();
                $('#main-game-container').append($('<div />').attr('id', 'error-messages'));
                $('#main-game-container').append($('<div />').attr('id', 'messages'));
                $('#login-container').html(ui.drawLogIn());

                persister.user.logout();
            });

            // Log in
            $('#wrapper').on('click', '#button-log-in', function () {
                var username = $('#login-user-nickname').val();
                var password = $('#login-user-password').val();

                ui.clearErrorMessage();
                persister.user.login(username, password, ui.showErrorMessage);
                setTimeout(function () {
                    if (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined) {
                        ui.clearErrorMessage();
                        $('#login-container').html(ui.drawLoggedIn());
                        $('#main-game-container').html(ui.drawUserInteraction());
                        $('#left-side-bar').html(ui.drawSidebars(myMainPersister));
                    }
                }, 500);
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
                    $('#login-container').html(ui.drawLoggedIn());
                    ui.clearErrorMessage();
                }
                else {
                    ui.showAppErrorMessage('Invalid username or password! Check you account information and try again.');
                }
            });

            // Create new game
            $('#wrapper').on('click', '#user-loged-in #button-create-new-game', function () {
                $('#user-loged-in').html(ui.drawCreateGameMenu());
            });

            // Create new game confirm
            $('#wrapper').on('click', '#confirm-create-game', function () {
                var gameName = $('#create-game-name').val();
                var gamePassword = $('#create-game-password').val();
                $('#game-user-create').remove();
                $('#login-container').html(ui.drawLoggedIn());

                ui.clearErrorMessage();
                ui.showMessage('Game created');
                persister.game.create(gameName, gamePassword, ui.clearErrorMessage, ui.showErrorMessage);
            });

            // Show or hide list of my games
            $('#wrapper').on('click', '#games-active', function () {
                ui.showOrHideElements('#games-active');
            });

            $('#wrapper').on('click', '#games-open', function () {
                ui.showOrHideElements('#games-open');
            });

            $('#wrapper').on('click', '#games-messages', function () {
                ui.showOrHideElements('#games-messages');
            });

            // Confirm join in game
            $('#wrapper').on('click', '.button-join', function () {
                var gameID = $(this).parent('li').attr('data-game-id');
                var gamePassword;
                persister.game.join(gameID, gamePassword, function () {
                    ui.clearErrorMessage;
                    $('#left-side-bar').html(ui.drawSidebars(myMainPersister));
                }, ui.showErrorMessage);

                ui.showMessage('You joined in game.');
            });

            // Start game new version
            $('#wrapper').on('click', '.button-start', function () {
                var gameID = $(this).parent('li').attr('data-game-id');
                //var gameNumber = $('#player-guess-text').val();
                //drawSidebars(persister);
                persister.game.start(gameID, function () {
                    ui.clearErrorMessage;
                    $('#left-side-bar').html(ui.drawSidebars(myMainPersister));
                }, ui.showErrorMessage);
                ui.showMessage('Game is started.');
            });

            // View current game state
            $('#wrapper').on('click', '.button-view-state', function () {
                var gameID = $(this).parent('li').attr('data-game-id');
                //var gameNumber = $('#player-guess-text').val();
                persister.game.field(gameID, function (data) {
                    ui.clearErrorMessage();
                    $('#game-state-container').empty();
                    $('#game-state-container').load('game-field.html', function () {
                        ui.drawCurrentGameState(data);
                    });
                }, ui.showErrorMessage);
            });

            // Move or attack
        //    $('#wrapper').on('click', '#game-state-container table tr td', function () {
        //        var currentState = $('#game-state-container table').attr('data-is-attacing');
        //        var currentGameId = $('#game-state-container table').attr('data-game-id');
        //        var currentUnitId = $(this).attr('data-unit-id');
        //        var currentUnitPosX = $(this).attr('data-pos-x');
        //        var currentUnitPosY = $(this).attr('data-pos-y');
        //        var currentPosition = { x: currentUnitPosX, y: currentUnitPosY };

        //        if (currentState == 'true') {
        //            currentUnitId = localStorage.getItem('unit-id');

        //            var attackerRange = localStorage.getItem('attacer-range');
        //            var attackerPosX = localStorage.getItem('attacer-pos-x');
        //            var attackerPosY = localStorage.getItem('attacer-pos-y');

        //            var currentAttackRange = Math.abs(attackerPosX - currentUnitPosX) + Math.abs(attackerPosY - currentUnitPosY);
        //            var isAttackPosible = attackerRange >= currentAttackRange;
        //            var isOpponentUnit = $(this).attr('data-unit-id') != undefined;

        //            if (isAttackPosible && isOpponentUnit) {
        //                persister.battle.attack(currentGameId, currentUnitId, currentPosition, function () {
        //                    ui.showMessage('Attack is success.');

        //                    persister.game.field(currentGameId, function (data) {
        //                        ui.clearErrorMessage();
        //                        $('#game-state-container').empty();
        //                        $('#game-state-container').load('game-field.html', function () {
        //                            ui.drawCurrentGameState(data);
        //                        });
        //                    }, ui.showErrorMessage);
        //                },
        //                function (err) {
        //                    ui.showErrorMessage(err);
        //                });
        //            }
        //            else {
        //                persister.battle.move(currentGameId, currentUnitId, currentPosition, function () {
        //                    ui.showMessage('Move is success.');

        //                    persister.game.field(currentGameId, function (data) {
        //                        ui.clearErrorMessage();
        //                        $('#game-state-container').empty();
        //                        $('#game-state-container').load('game-field.html', function () {
        //                            ui.drawCurrentGameState(data);
        //                        });
        //                    }, ui.showErrorMessage);
        //                },
        //                function (err) {
        //                    ui.showErrorMessage(err);
        //                });
        //            }

        //            $('#game-state-container table').attr('data-is-attacing', 'false');
        //            localStorage.setItem('unit-id', '');
        //            localStorage.setItem('unit-id', '');
        //            localStorage.setItem('attacer-pos-x', '');
        //            localStorage.setItem('attacer-pos-y', '');
        //            localStorage.setItem('attacer-range', '');
        //        }
        //        else {
        //            $('#game-state-container table').attr('data-is-attacing', 'true');
        //            localStorage.setItem('unit-id', currentUnitId);

        //            localStorage.setItem('attacer-pos-x', currentUnitPosX);
        //            localStorage.setItem('attacer-pos-y', currentUnitPosY);

        //            if ($(this).text() == 'W') {
        //                localStorage.setItem('attacer-range', '1');
        //            }
        //            else if ($(this).text() == 'R') {
        //                localStorage.setItem('attacer-range', '3');
        //            }
        //        }
        //    });
        }

        return {
            addEvents: addElementsEvents
        }
    }());

    eventControler.addEvents(myMainPersister);
});