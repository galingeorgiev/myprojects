/// <reference path="../jquery-2.0.2.js" />

var httpRequester = (function(){
    function getJson(url, success, error) {
        $.ajax({
            url: url,
            type: 'GET',
            //async: false,
            timeout:5000,
            contentType: 'application/json',
            success: success,
            error: error
        });
    }

    function postJson(url, data, success, error) {
        $.ajax({
            url: url,
            type: 'POST',
            //async: false,
            timeout: 5000,
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: success,
            error: error
        });
    }

    return {
        getJson: getJson,
        postJson: postJson
    }
}());