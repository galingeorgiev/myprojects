/// <reference path="data-persister.js" />
/// <reference path="ui.js" />
/// <reference path="class.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.controller = (function () {
    var AccessController = Class.create({
        init: function (dataPersister) {
            this.persister = dataPersister;

            if (this.persister.isLoggedIn()) {
                this.loadGame();
            }
            else {
                this.loadLogin("#main-content");
            }
        },

        loadLogin: function (selector) {
            var loginHtml = BullsAndCows.ui.loginHtml();
            $(selector).html(loginHtml);


        },

        loadGame: function (selector) {
        }
    });

    return {
        getAccessController: function (dataPersister) { return new AccessController(dataPersister); }
    }
}());