/// <reference path="../_references.js" />

window.viewModelsFactory = (function () {
    var data = null;

    // Login
    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: null,
            password: null,
            errMsg: "",
            login: function () {
                var self = this;
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					    window.location.href = "#/accounts";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Register
    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: null,
            password: null,
            firstName: null,
            lastName: null,
            errMsg: "",
            register: function () {
                var self = this;
                var userData = {
                    username: this.get("username"),
                    password: this.get("password"),
                    firstName: this.get("firstName"),
                    lastName: this.get("lastName"),
                }

                data.users.register(userData)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }

					    //window.location.href = "#/accounts";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Public Main Page
    function getMainPageViewModel() {
        var viewModel = {
            home: function () {
                window.location.href = "#/home";
            },
            login: function () {

                window.location.href = "#/login";
            },
            register: function () {

                window.location.href = "#/register";
            }
        }

        return kendo.observable(viewModel);
    }

    // Logout
    function getLogoutViewModel() {
        var viewModel = {
            errMsg: "",
            logout: function () {
                var self = this;
                data.users.logout()
					.then(function () {
					    window.location.href = "#/home";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    return {
        getLoginVM: getLoginViewModel,
        getMainPageViewModel: getMainPageViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getUserPageViewModel: getUserPageViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());