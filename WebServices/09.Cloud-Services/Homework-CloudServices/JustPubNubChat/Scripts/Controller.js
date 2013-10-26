var eventControler = (function () {
    var channelID = 'JustPubNubChat';

    var pubnub = PUBNUB.init({
        publish_key: 'pub-c-434977fa-1ea8-46dc-a69f-4b320b1ccc34',
        subscribe_key: 'sub-c-834dd9e0-04b8-11e3-8dc9-02ee2ddab7fe',
        origin: 'pubsub.pubnub.com',
        ssl: 'off'
    })


    $('#send').on('click', function () {
        // SEND
        pubnub.publish({
            channel: channelID,
            message: $('#message-content').val()
        });

        $('#message-content').val('');
    });

    //LISTEN
    pubnub.subscribe({
        channel: channelID,
        message: function (m) {
            $('#messages-conatiner').append($('<p />').text(m));
        }
    })
})();