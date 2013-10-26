/// <reference path="../../libs/_references.js" />

window.persisters = (function () {

    var username = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");
    var amount = localStorage.getItem("amount");

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        localStorage.setItem("amount", userData.amount);
        username = userData.nickname;
        sessionKey = userData.sessionKey;
        amount = userData.amount;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("amount");
        username = null;
        sessionKey = null;
        amount = null;
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJSON(this.apiUrl + "login", user)
                .then(function (data) {
                    saveUserData(data);
                    return data;
                });
        },

        register: function (username, password, nickname) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString(),
                nickname: nickname
            };

            return httpRequester.postJSON(this.apiUrl + "register", user)
                .then(function (data) {
                    saveUserData(data);
                    return data.nickname;
                });
        },

        logout: function () {
            var headers;
            if (!sessionKey) {

                alert("You are not logged in!");
            } else {
                headers = {
                    "X-sessionKey": sessionKey
                };
                return httpRequester.putJSON(this.apiUrl + "logout", "", headers)
                    .then(function (response) {
                        clearUserData();
                        return response;
                    });
            }
        }
    });

    var CarsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        all: function () {
            return httpRequester.getJSON(this.apiUrl + "GetAllFree");
        },

        getById: function (id) {
            return httpRequester.getJSON(this.apiUrl + "GetById/" + id);
        },

        rent: function (carData) {
            headers = {
                "X-sessionKey": sessionKey
            };
            return httpRequester.putJSON(this.apiUrl + "rent", carData, headers)
        }
    });

    var StoresPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        all: function () {
            return httpRequester.getJSON(this.apiUrl);
        },

        getById: function (id) {
            return httpRequester.getJSON(this.apiUrl + id);
        }
    });

    var MainPersister = Class.create({
        init: function (apiUrl) {
            this.users = new UsersPersister(apiUrl + "users/");
            this.cars = new CarsPersister(apiUrl + "cars/");
            this.stores = new StoresPersister(apiUrl + "stores/");
        },

        isUserLoggedIn: function () {
            var isLoggedIn = username != null && sessionKey != null;
            return isLoggedIn;
        },

        getUsername: function () {
            return username;
        }
    });

    return {
        getPersister: function (apiUrl) {
            return new MainPersister(apiUrl);
        }
    };

}());