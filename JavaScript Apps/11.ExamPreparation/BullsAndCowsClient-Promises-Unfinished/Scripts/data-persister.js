/// <reference path="class.js" />
/// <reference path="http-requester.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.persisters = (function () {

    var sessionKey = localStorage.getItem("sessionKey");

    var BasePersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
            this.users = new UserPersister(serviceUrl + "user/");
        },

        isLoggedIn: function () {
            var sessionKey = localStorage.getItem("sessionKey");
            console.log(sessionKey);
            if (sessionKey) {
                if (sessionKey != "") {
                    return true;
                }
            }
            return false;
        }

    });

    var UserPersister = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },

        register: function (username, nickname, password) {
            var hash = CryptoJS.SHA1(password).toString()

            return httpRequester.httpPost(this.serviceUrl + "register", {
                username: username,
                nickname: nickname,
                authCode: hash
            }).then(function (data) {
                localStorage.setItem("sessionKey", data.sessionKey);
                localStorage.setItem("nickname", data.nickname);
                sessionKey = data.sessionKey;
            }, function (error) {
                console.log(error);
            });
        },

        login: function (username, password) {
            var hash = CryptoJS.SHA1(password).toString();

            return httpRequester.httpPost(this.serviceUrl + "login", {
                username: username,
                authCode: hash
            }).then(function (data) {
                localStorage.setItem("sessionKey", data.sessionKey);
                sessionKey = data.sessionKey;
            }, function (error) {
                console.log(error);
            });
        },

        logout: function () {
            httpRequester.httpGet(this.serviceUrl + "logout/" + sessionKey).
                then(function (data) {
                    localStorage.setItem("sessionKey", "");
                    localStorage.setItem("nickname", "");
                    sessionKey = "";
                });
        },

        scores: function () {
        }
    });

    return {
        getPersister: function (url) { return new BasePersister(url); },
    }
}());

//var localPersister = BullsAndCows.persisters.getPersister("http://localhost:40643/api/");
////localPersister.users.register("Kiro2", "Kiro Motikata", "teslata");
//localPersister.users.login("Kiro2", "some text");