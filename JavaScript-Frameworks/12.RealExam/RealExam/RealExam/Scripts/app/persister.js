/// <reference path="../_references.js" />
window.persisters = (function () {

    function saveUserData(userData) {
        localStorage.setItem("firstName", userData.firstName);
        localStorage.setItem("lastName", userData.lastName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        localStorage.setItem("role", userData.role.Name);
    }
    function clearUserData() {
        localStorage.removeItem("firstName");
        localStorage.removeItem("lastName");
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("role");
    }

    var Users = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                password: CryptoJS.SHA1(password).toString()
            };

            // api/users/login
            return httpRequester.postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);
				});
        },
        register: function (userData) {
            var user = {
                username: userData.username,
                password: CryptoJS.SHA1(userData.password).toString(),
                firstName: userData.firstName,
                lastName: userData.lastName
            };

            // api/users/register
            return httpRequester.postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveUserData(data);
				});
        },
        logout: function () {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Missing session key.');
            }

            var logoutHeaders = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/users/logout
            return httpRequester.postJSON(this.apiUrl + "logout", "", logoutHeaders)
                .then(function () {
                    clearUserData();
                },
                function (err) {
                    console.log(err);
                });
        },
        profile: function () {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Missing session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/users/profile
            return httpRequester.getJSON(this.apiUrl + "current", headers);
        },
        currentUser: function () {
            return localStorage.getItem("sessionKey");
        },
        currentUserRole: function () {
            return localStorage.getItem("role");
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new Users(apiUrl + "users/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());