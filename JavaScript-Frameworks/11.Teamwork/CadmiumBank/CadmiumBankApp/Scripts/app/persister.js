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
        firstName = "";
        lastName = "";
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

    var Accounts = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        getAllAccounts: function () {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }
            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts
            return httpRequester.getJSON(this.apiUrl, headers);
        },
        getAccountById: function (accountId) {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }
            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts/:id
            return httpRequester.getJSON(this.apiUrl + accountId, headers);
        },
        getAccountTransactions: function (accountId) {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts/:id/transactionlogs
            return httpRequester.getJSON(this.apiUrl + accountId + '/transactionlogs', headers);
        },
        getAccountByIdForTransfer: function (accountId) {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts/:id/transfer
            return httpRequester.getJSON(this.apiUrl + accountId + '/transfer/', headers);
        },
        putTransfer: function (data) {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }
            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts/:id/transfer
            return httpRequester.putJSON(this.apiUrl, data, headers);
        },
        createAccount: function (accountData) {
            var account = {
                balance: accountData.balance,
                description: accountData.description,
                typeId: accountData.type,
                currencyId: accountData.currency
            };

            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accounts/create
            return httpRequester.postJSON(this.apiUrl, account, headers);
        }
    });

    var AccountTypes = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        getAll: function () {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accountTypes
            return httpRequester.getJSON(this.apiUrl, headers);
        }
    });

    var Currencies = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        getAll: function () {
            if (!localStorage.getItem("sessionKey")) {
                console.log('Invalid session key.');
            }

            var headers = {
                "X-SessionKey": localStorage.getItem("sessionKey")
            };

            // api/accountTypes
            return httpRequester.getJSON(this.apiUrl, headers);
        }
    });

    var Calculator = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        get: function () {
            // api/calculator
            return httpRequester.getJSON(this.apiUrl);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new Users(apiUrl + "users/");
            this.accounts = new Accounts(apiUrl + "accounts/");
            this.accountTypes = new AccountTypes(apiUrl + "accounttypes/");
            this.currencies = new Currencies(apiUrl + "currencies/");
            this.calculator = new Calculator(apiUrl + "calculator/")
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());