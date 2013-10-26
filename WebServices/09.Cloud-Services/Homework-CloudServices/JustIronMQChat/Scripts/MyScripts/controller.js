/// <reference path="validation-controler.js" />
/// <reference path="Class.js" />
/// <reference path="../jquery-1.7.1.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

$(document).ready(function () {
    var url = 'http://localhost:58484/api/messages';

    setInterval(function () {
        httpRequester.getJson(url, function (m) {
            if (m != 'empty' && m != '') {
                $('#messages-conatiner').append($('<p />').text('Other: ' + m));
                console.log(m);
            }
        },
        function (err) { console.log(err); });
    }, 1000);

    $('#send').on('click', function () {
        var data = { value: $('#message-content').val() };

        httpRequester.postJson(url, data,
            function () {
                $('#messages-conatiner').append($('<p />').text('You: ' + $('#message-content').val()));
                $('#message-content').val('');
            },
            function (error) {
                console.log(error);
            })
    });
});