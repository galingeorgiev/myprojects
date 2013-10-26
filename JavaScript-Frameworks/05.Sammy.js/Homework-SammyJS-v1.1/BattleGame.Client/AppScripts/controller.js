/// <reference path="../Scripts/require.js" />
/// <reference path="../Scripts/sammy-0.7.4.js" />

define(['jquery', 'sammy', 'persister', 'ui', 'validationControler'], function ($, Sammy, persister, ui, validationControler) {
    function addElementsEvents(persister) {
        var cache;
        var app = Sammy('#wrapper', function () {
            // Logout
            this.get('#/user/logout', function () {
                $('#login-container').empty();
                $('#left-side-bar').empty();
                $('#right-side-bar').empty();
                $('#main-game-container').empty();
                $('#main-game-container').append($('<div />').attr('id', 'error-messages'));
                $('#main-game-container').append($('<div />').attr('id', 'messages'));
                $('#login-container').html(ui.drawLogIn());
            });

            // Login
            this.get('#/login', function (context) {
                ui.clearErrorMessage();
                $('#login-container').html(ui.drawLoggedIn());
                $('#main-game-container').html(ui.drawUserInteraction());
                $('#left-side-bar').html(ui.drawSidebars(persister));
            });

            // Register now
            this.get('#/register', function () {
                $('#login-container').html(ui.drawRegister());
            });

            // Register back
            this.get('#/loginform', function () {
                $('#login-container').html(ui.drawLogIn());
            });

            // Send register request
            this.get('#/user/register', function () {
                $('#login-container').html(ui.drawLoggedIn());
                $('#main-game-container').html(ui.drawUserInteraction());
                $('#left-side-bar').html(ui.drawSidebars(persister));
                ui.clearErrorMessage();
            });

            // Create new game
            this.get('#/creategame', function () {
                $('#user-loged-in').html(ui.drawCreateGameMenu());
            });

            // Create new game confirm
            this.get('#/game/create', function () {
                ui.clearErrorMessage;
                ui.drawSidebars(persister);
                ui.showMessage('Game created');
            });

            // Confirm join in game
            this.get('#/game/join', function () {
                ui.clearErrorMessage;
                $('#left-side-bar').html(ui.drawSidebars(persister));
            });

            // Start game new version
            this.get('#/game/start', function () {
                ui.clearErrorMessage;
                $('#left-side-bar').html(ui.drawSidebars(persister));
            });

            // View current game state
            this.get('#/game/state/:gameID', function (context) {
                var gameID = this.params['gameID'];
                persister.game.field(gameID, function (data) {
                    ui.clearErrorMessage();
                    $('#game-state-container').empty();
                    $('#game-state-container').load('HTMLs/game-field.html', function () {
                        ui.drawCurrentGameState(data);
                    });
                }, ui.showErrorMessage);
            });
        });

        app.run('#/loginform');

        // logout
        $('#wrapper').on('click', '#user-loged-in #button-logout', function () {
            persister.user.logout(function () {
                window.location = '#/user/logout';
            },
            function (err) {
                console.log(err);
            });
        });

        // login
        $('#wrapper').on('click', '#button-log-in', function () {
            var username = $('#login-user-nickname').val();
            var password = $('#login-user-password').val();
            persister.user.login(username, password, function () {
                window.location = '#/login';
            },
            ui.showErrorMessage);
        });

        // register now
        $('#wrapper').on('click', '#register-now', function () {
            window.location = '#/register';
        });

        // register back
        $('#wrapper').on('click', '#back-to-homepage', function () {
            window.location = '#/loginform';
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
                persister.user.register(username, nickname, password, function () {
                    window.location = '#/user/register';
                },
                ui.showErrorMessage);
            }
            else {
                ui.showAppErrorMessage('Invalid username or password! Check you account information and try again.');
            }
        });

        // Create new game
        $('#wrapper').on('click', '#user-loged-in #button-create-new-game', function () {
            window.location = '#/creategame';
        });

        // Create new game confirm
        $('#wrapper').on('click', '#confirm-create-game', function () {
            var gameName = $('#create-game-name').val();
            var gamePassword = $('#create-game-password').val();
            $('#game-user-create').remove();
            $('#login-container').html(ui.drawLoggedIn());

            persister.game.create(gameName, gamePassword, function () {
                window.location = '#/game/create';
            },
            ui.showErrorMessage);
        });

        // Confirm join in game
        $('#wrapper').on('click', '.button-join', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            var gamePassword;
            persister.game.join(gameID, gamePassword, function () {
                window.location = '#/game/join';
            },
            function () {
                ui.showMessage('You joined in game.');
            });
        });

        // Start game new version
        $('#wrapper').on('click', '.button-start', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            persister.game.start(gameID, function () {
                window.location = '#/game/start'
            }, function () {
                ui.showMessage('Game is started.');
            });
        });

        // View current game state
        $('#wrapper').on('click', '.button-view-state', function () {
            var gameID = $(this).parent('li').attr('data-game-id');
            window.location = '#/game/state/' + gameID;
        });


        // Move or attack
        $('#wrapper').on('click', '#game-state-container table tr td', function () {
            var currentState = $('#game-state-container table').attr('data-is-attacing');
            var currentGameId = $('#game-state-container table').attr('data-game-id');
            var currentUnitId = $(this).attr('data-unit-id');
            var currentUnitPosX = $(this).attr('data-pos-x');
            var currentUnitPosY = $(this).attr('data-pos-y');
            var currentPosition = { x: currentUnitPosX, y: currentUnitPosY };

            if (currentState == 'true') {
                currentUnitId = localStorage.getItem('unit-id');

                var attackerRange = localStorage.getItem('attacer-range');
                var attackerPosX = localStorage.getItem('attacer-pos-x');
                var attackerPosY = localStorage.getItem('attacer-pos-y');

                var currentAttackRange = Math.abs(attackerPosX - currentUnitPosX) + Math.abs(attackerPosY - currentUnitPosY);
                var isAttackPosible = attackerRange >= currentAttackRange;
                var isOpponentUnit = $(this).attr('data-unit-id') != undefined;

                if (isAttackPosible && isOpponentUnit) {
                    persister.battle.attack(currentGameId, currentUnitId, currentPosition, function () {
                        ui.showMessage('Attack is success.');

                        persister.game.field(currentGameId, function (data) {
                            ui.clearErrorMessage();
                            $('#game-state-container').empty();
                            $('#game-state-container').load('HTMLs/game-field.html', function () {
                                ui.drawCurrentGameState(data);
                            });
                        }, ui.showErrorMessage);
                    },
                    function (err) {
                        ui.showErrorMessage(err);
                    });
                }
                else {
                    persister.battle.move(currentGameId, currentUnitId, currentPosition, function () {
                        ui.showMessage('Move is success.');

                        persister.game.field(currentGameId, function (data) {
                            ui.clearErrorMessage();
                            $('#game-state-container').empty();
                            $('#game-state-container').load('HTMLs/game-field.html', function () {
                                ui.drawCurrentGameState(data);
                            });
                        }, ui.showErrorMessage);
                    },
                    function (err) {
                        ui.showErrorMessage(err);
                    });
                }

                $('#game-state-container table').attr('data-is-attacing', 'false');
                localStorage.setItem('unit-id', '');
                localStorage.setItem('unit-id', '');
                localStorage.setItem('attacer-pos-x', '');
                localStorage.setItem('attacer-pos-y', '');
                localStorage.setItem('attacer-range', '');
            }
            else {
                $('#game-state-container table').attr('data-is-attacing', 'true');
                localStorage.setItem('unit-id', currentUnitId);

                localStorage.setItem('attacer-pos-x', currentUnitPosX);
                localStorage.setItem('attacer-pos-y', currentUnitPosY);

                if ($(this).text() == 'W') {
                    localStorage.setItem('attacer-range', '1');
                }
                else if ($(this).text() == 'R') {
                    localStorage.setItem('attacer-range', '3');
                }
            }

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
    }

    return {
        addEvents: addElementsEvents
    }
});