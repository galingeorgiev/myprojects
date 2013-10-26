/// <reference path="../jquery-1.7.1.js" />
/// <reference path="http-requester.js" />
/// <reference path="Class.js" />

var persister = (function () {
    var mainUrl = '';

    var mainPersister = Class.create({
        init: function (url) {
            this.url = url;
            mainUrl = url;
            this.messages = new messages();
        }
    });

    var messages = Class.create({
        init: function () {
            this.url = mainUrl + '/messages';
        },
        all: function (success, error) {
            var url = this.url;
            console.log(url)
            httpRequester.getJson(url, success, function (err) { console.log(err); });
        },
        post: function (success, error) {
            var url = this.url;

            httpRequester.getJson(url, success, function (err) { console.log(err); });
        }
    });

    return {
        mainPersister: function (url) { return new mainPersister(url) }
    }
}());