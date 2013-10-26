window.fbAsyncInit = function () {
    FB.init({
        appId: '207212666093569', // App ID
        channelUrl: '//http://localhost:50989/channel.html', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

function postToFeed() {
    var obj = {
        method: 'feed',
        link: 'http://localhost:20511/post.html',
        picture: 'http://www.design.bg/bglogo/pics/logo.gif',
        name: 'Tic tac toe game',
        caption: 'That I\'m playing',
        description: 'Some more cool info here.'
    };
    FB.ui(obj);
}