/// <reference path="../../libs/_references.js" />

window.httpRequester = (function () {

    function getJSON(url, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function postJSON(url, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(data),
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function putJSON(url,data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: "PUT",
                dataType: "json",
                data: JSON.stringify(data),
                contentType: "application/json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON
    };

}());