/// <reference path="../Scripts/class.js" />
/// <reference path="../Scripts/require.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />
define(['httpRequester', 'Class', 'cryptoJS'], function (httpRequester, Class) {
    var authCode = localStorage.getItem('authCode');
    var mainUrl = '';

    var mainPersister = Class.create({
        init: function (url) {
            this.url = url;
            mainUrl = url;
            this.user = new user(this.url);
            this.game = new game();
            this.battle = new battle();
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
        register: function (username, nickname, password, success, error) {
            var userData = {
                "username": username,
                "nickname": nickname,
                "authCode": CryptoJS.SHA1(password).toString()
            };

            var url = this.url + '/register';

            httpRequester.postJSON(url, userData)
                .then(function (data) {
                    localStorage.setItem('authCode', data.sessionKey);
                    localStorage.setItem('userNickname', data.nickname);
                    success();
                },
                error);
        },
        login: function (username, password, success, error) {
            var userData = {
                "username": username,
                "authCode": CryptoJS.SHA1(password).toString()
            };
            var url = this.url + '/login';

            httpRequester.postJSON(url, userData)
                .then(function (data) {
                    localStorage.setItem('authCode', data.sessionKey);
                    localStorage.setItem('userNickname', data.nickname);
                    success(data);
                },
                function (err) {
                    error(err);
                });
        },
        logout: function (success, error) {
            var url = this.url + '/logout/';

            if (true) {
                url = url + localStorage.getItem('authCode');
            }

            httpRequester.putJSON(url)
                .then(function () {
                    localStorage.setItem('authCode', '');
                    localStorage.setItem('userNickname', '');
                },
                function (err) {
                    localStorage.setItem('authCode', '');
                    localStorage.setItem('userNickname', '');
                    success(err);
                    //console.log(err)
                });
        },
        scores: function () {
            var url = this.url + '/scores/';

            if (true) {
                url = url + localStorage.getItem('authCode');
            }

            httpRequester.getJSON(url)
                .then(function (data) {
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
        create: function (title, password, success, error) {
            var gameData = {
                title: title
            };

            if (password) {
                gameData.password = password;
            }

            var url = this.url + '/create/' + localStorage.getItem('authCode');

            httpRequester.postJSON(url, gameData).then(success, error);
        },
        join: function (gameID, password, success, error) {
            var gameData = {
                id: gameID
            };

            if (password) {
                gameData.password = password;
            }

            var url = this.url + '/join/' + localStorage.getItem('authCode');

            httpRequester.postJSON(url, gameData).then(success, error);
        },
        start: function (gameID, success, error) {
            var url = this.url + '/' + gameID + '/start/' + localStorage.getItem('authCode');

            httpRequester.putJSON(url).then(success, error);
        },
        open: function (success, error) {
            var url = this.url + '/open/' + localStorage.getItem('authCode');

            httpRequester.getJSON(url).then(success, error);
        },
        myActive: function (success, error) {
            var url = this.url + '/my-active/' + localStorage.getItem('authCode');

            httpRequester.getJSON(url).then(success, function (err) { console.log(err); });
        },
        field: function (gameID, success, error) {
            var url = this.url + '/' + gameID + '/field/' + localStorage.getItem('authCode');

            httpRequester.getJSON(url).then(success, error);
        }
    });

    var battle = Class.create({
        init: function () {
            this.url = mainUrl + '/battle';
        },
        move: function (gameID, currentUnitId, currentUnitPosition, success, error) {
            var gameData = {
                unitId: currentUnitId,
                position: currentUnitPosition
            };

            var url = this.url + '/' + gameID + '/move/' + localStorage.getItem('authCode');

            httpRequester.postJSON(url, gameData).then(success, error);
        },
        attack: function (gameID, currentUnitId, currentUnitPosition, success, error) {
            var gameData = {
                unitId: currentUnitId,
                position: currentUnitPosition
            };

            var url = this.url + '/' + gameID + '/attack/' + localStorage.getItem('authCode');

            httpRequester.postJSON(url, gameData).then(success, error);
        },
        defend: function (gameID, currentUnitId, success, error) {
            var url = this.url + '/' + gameID + '/defend/' + localStorage.getItem('authCode');

            httpRequester.postJSON(url, currentUnitId)
                .then(success, error);
        },
    });

    var messages = Class.create({
        init: function () {
            this.url = mainUrl + '/messages';
        },
        all: function (success, error) {
            var url = this.url + '/all/' + localStorage.getItem('authCode');

            httpRequester.getJSON(url)
                .then(success, function (err) { console.log(err); });
        },
        unread: function (success, error) {
            var url = this.url + '/unread/' + localStorage.getItem('authCode');

            httpRequester.getJSON(url)
                .then(success, function (err) { console.log(err); });
        }
    });

    return {
        mainPersister: function (url) { return new mainPersister(url) },
        nickname: localStorage.getItem('userNickname'),
        authCode: localStorage.getItem('authCode')
    }
});