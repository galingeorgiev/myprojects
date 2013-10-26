/// <reference path="../jquery-2.0.2.js" />
/// <reference path="http-requester.js" />
/// <reference path="Class.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

var persister = (function () {
    var authCode = localStorage.getItem('authCode');
    var mainUrl = '';

    var mainPersister = Class.create({
        init: function (url) {
            this.url = url;
            mainUrl = url;
            this.user = new user(this.url);
            this.game = new game();
            this.guess = new guess();
            this.messages = new messages();
        },
        isUserLoggedIn: function () {
            isLoggedIn = (localStorage.getItem('authCode') != '' && localStorage.getItem('authCode') != undefined);
            return isLoggedIn;
        }
    });

    var user = Class.create({
        init: function (url) {
            this.url = url + '/user'
        },
        register: function (username, nickname, password, error) {
            var userData = {
                "username": username,
                "nickname": nickname,
                "authCode": CryptoJS.SHA1(password).toString()
            };

            var url = this.url + '/register';

            httpRequester.postJson(url, userData,
                function (data) {
                    localStorage.setItem('authCode', data.sessionKey);
                    localStorage.setItem('userNickname', data.nickname);
                },
                error);
        },
        login: function (username, password, error) {
            var userData = {
                "username": username,
                "authCode": CryptoJS.SHA1(password).toString()
            };
            var url = this.url + '/login';

            httpRequester.postJson(url, userData,
                function (data) {
                    localStorage.setItem('authCode', data.sessionKey);
                    localStorage.setItem('userNickname', data.nickname);
                },
                error);
        },
        logout: function () {
            var url = this.url + '/logout/';

            if (true) {
                url = url + localStorage.getItem('authCode');
            }

            httpRequester.getJson(url,
                function () {
                    localStorage.setItem('authCode', '');
                    localStorage.setItem('userNickname', '');
                },
                function () { console.log('Try again') });
        },
        scores: function () {
            var url = this.url + '/scores/';

            if (true) {
                url = url + localStorage.getItem('authCode');
            }

            httpRequester.getJson(url,
                function (data) {
                    console.log('OK');
                    console.log(data);
                },
                function () { console.log('Try again') });
        }
    });

    var game = Class.create({
        init: function () {
            this.url = mainUrl + '/game'
        },
        create: function (title, number, password, success, error) {
            var gameData = {
                title: title,
                number: number
            };

            if (password) {
                gameData.password = password;
            }

            var url = this.url + '/create/' + localStorage.getItem('authCode');

            httpRequester.postJson(url, gameData, success, error);
        },
        join: function (gameID, number, password, success, error) {
            var gameData = {
                gameId: gameID,
                number: number
            };

            if (password) {
                gameData.password = password;
            }

            var url = this.url + '/join/' + localStorage.getItem('authCode');

            httpRequester.postJson(url, gameData, success, error);
        },
        start: function (gameID,success, error) {
            var url = this.url + '/' +gameID + '/start/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, error);
        },
        open: function (success, error) {
            var url = this.url + '/open/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, error);
        },
        myActive: function (success, error) {
            var url = this.url + '/my-active/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, function (err) { console.log(err); });
        },
        state: function (gameID, success, error) {
            var url = this.url + '/' + gameID + '/state/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, error);
        }
    });

    var guess = Class.create({
        init: function () {
            this.url = mainUrl + '/guess';
        },
        make: function (number, gameId, success, error) {
            var guessData = {
                number: number,
                gameId: gameId
            };

            var url = this.url + '/make/' + localStorage.getItem('authCode');

            httpRequester.postJson(url, guessData, success, error);
        }
    });

    var messages = Class.create({
        init: function () {
            this.url = mainUrl + '/messages';
        },
        all: function (success, error) {
            var url = this.url + '/all/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, function (err) { console.log(err); });
        },
        unread: function (success, error) {
            var url = this.url + '/unread/' + localStorage.getItem('authCode');

            httpRequester.getJson(url, success, function (err) { console.log(err); });
        }
    });

    return {
        mainPersister: function (url) { return new mainPersister(url) },
        nickname:  localStorage.getItem('userNickname'),
        authCode: localStorage.getItem('authCode')
    }
}());

//var myMainPersister = persister.mainPersister('http://localhost:40643/api');
//myMainPersister.user.register('gali', 'georgiev', '12345');
//myMainPersister.user.login('gali', '12345');
//myMainPersister.user.scores();
//myMainPersister.user.logout();
//myMainPersister.game.create('TestgameGGG', 1234);
//myMainPersister.game.open();
//myMainPersister.guess.make(4321);
//myMainPersister.messages.unread();
//myMainPersister.messages.all();
//myMainPersister.game.join(4, 9876);