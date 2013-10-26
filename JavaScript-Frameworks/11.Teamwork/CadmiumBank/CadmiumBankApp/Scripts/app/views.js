/// <reference path="../_references.js" />

window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterView() {
        return getTemplate("register-form");
    }

    function getAccountView() {
        return getTemplate("account-info");
    }

    function getAccountDetailsView() {
        return getTemplate("account-details");
    }

    function getPublicMenuView() {
        return getTemplate("public-menu");
    }


    function getUserMenuView() {
        return getTemplate("user-menu");
    }

    function getHomeView() {
        return getTemplate("home");
    }

    function getTransactionsView() {
        return getTemplate("transaction-logs");
    }

    function getCreateAccountView() {
        return getTemplate("create-account-form");
    }

    function getTransferView() {
        return getTemplate("transfer");
    }

    function getTransferFromCurrentAccountView() {
        return getTemplate("transfer-from-current-account");
    }

    function getProfileView() {
        return getTemplate("profile");
    }

    return {
        getLoginView: getLoginView,
        getAccountView: getAccountView,
        getAccountDetailsView: getAccountDetailsView,
        getPublicMenuView: getPublicMenuView,
        getRegisterView: getRegisterView,
        getHomeView: getHomeView,
        getUserMenuView: getUserMenuView,
        getTransactionsView: getTransactionsView,
        getCreateAccountView: getCreateAccountView,
        getTransferView: getTransferView,
        getProfileView: getProfileView,
        getTransferFromCurrentAccountView: getTransferFromCurrentAccountView
    };
}());